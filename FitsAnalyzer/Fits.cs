using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using nom.tam.fits;
using nom.tam.util;

namespace FitsAnalyzer
{
    public enum BitPix { Bits8, Bits16, Bits32, Unknown }
    public class FitsWrapper
    {
        private Fits fits = null;
        private BasicHDU[] hdus = null;

        public void OpenFile(string fileName, out int hduNum)
        {
            fits = new Fits(fileName, FileAccess.Read);
            hduNum = fits.Size();
        }

        public bool ReadHeader(string file, int index, out List<string[]> table, out bool hasImage)
        {
            fits = new Fits(file, FileAccess.Read);
            hdus = fits.Read();

            if (hdus == null) { table = null; hasImage = false; return false; }

            table = new List<string[]> { };
            var hdr = hdus[index].Header;

            for (int j = 0; j < hdr.NumberOfCards; j++)
            {
                var hc = new HeaderCard(hdr.GetCard(j));
                var sa = new string[3] { hc.Key, hc.Value, hc.Comment };
                table.Add(sa);
            }

            int naxis = 0;
            if (hdr.ContainsKey("SIMPLE"))
            {
                // Простой HDU
                if (hdr.ContainsKey("NAXIS"))
                    naxis = hdr.GetIntValue("NAXIS");
                
            }
            else if (hdr.ContainsKey("XTENSION"))
            {
                // HDU-расширение
                if (hdr.ContainsKey("ZNAXIS"))
                    naxis = hdr.GetIntValue("ZNAXIS");
            }
            hasImage = (naxis == 2);
            return (table.Count != 0);
        }

        public void ReadData(int index, out Array[] data, out BitPix bitpix)
        {
            int bits = hdus[index].BitPix;
            switch (bits)
            {
                case 8:  bitpix = BitPix.Bits8; break;
                case 16: bitpix = BitPix.Bits16; break;
                case 32: bitpix = BitPix.Bits32; break;
                default: bitpix = BitPix.Unknown; break;
            }
            if (bitpix != BitPix.Unknown) data = (Array[])hdus[index].Kernel;
            else data = null;
        }

        public void Free()
        {
            if (fits != null) fits.Close();
        }

        internal void GetAmplitudeSpan(string file, out double minAmpl, out double maxAmpl,
                                       out DateTime minDateTime, out DateTime maxDateTime)
        {
            fits = new Fits(file, FileAccess.Read);
            hdus = fits.Read();

            minAmpl = double.MaxValue;
            maxAmpl = double.MinValue;
            minDateTime = DateTime.MaxValue;
            maxDateTime = DateTime.MinValue;
            if (hdus == null) return;

            int naxis = 0;
            for (int i = 0; i < hdus.Length; i++)
            {
                var hdr = hdus[i].Header;
                if (!hdr.ContainsKey("SIMPLE")) break;

                // Определение границ для дат наблюдения
                    
                minDateTime = DateTime.MaxValue;
                maxDateTime = DateTime.MinValue;

                if (!hdr.ContainsKey("DATE-OBS")) break;
                DateTime dateTime;
                if (!DateTime.TryParse(hdr.GetStringValue("DATE-OBS"), out dateTime))
                    break;
                if (dateTime < minDateTime) minDateTime = dateTime;
                if (dateTime > maxDateTime) maxDateTime = dateTime;

                // Определение границ для амплитудных значений

                if (hdr.ContainsKey("NAXIS"))
                    naxis = hdr.GetIntValue("NAXIS");
                if (naxis != 2) break;

                int bits = hdus[i].BitPix;
                BitPix bitpix = BitPix.Unknown;

                switch (bits)
                {
                    case 8: bitpix = BitPix.Bits8; break;
                    case 16: bitpix = BitPix.Bits16; break;
                    case 32: bitpix = BitPix.Bits32; break;
                    default: bitpix = BitPix.Unknown; break;
                }
                Array[] data;
                if (bitpix != BitPix.Unknown)
                    data = (Array[])hdus[i].Kernel;
                else
                    break;

                int width = data[0].GetLength(0);
                int height = data.GetLength(0);

                if (!hdr.ContainsKey("BSCALE") ||
                    !hdr.ContainsKey("BZERO"))
                    break;
                var bscale = hdus[i].BScale;
                var bzero = hdus[i].BZero;

                var minValue = Int32.MaxValue;
                var maxValue = Int32.MinValue;

                // Определение значения для прозрачного фона
                Int32 trnValue = 0;
                if (bitpix == BitPix.Bits8) trnValue = byte.MinValue;
                else if (bitpix == BitPix.Bits16) trnValue = Int16.MinValue;
                else if (bitpix == BitPix.Bits32) trnValue = Int32.MinValue;

                // Определение значений для максиммума и
                // минимума амплитуды
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        Int32 value = 0;
                        if (bitpix == BitPix.Bits8) value = ((byte[])data[y])[x];
                        else if (bitpix == BitPix.Bits16) value = ((Int16[])data[y])[x];
                        else if (bitpix == BitPix.Bits32) value = ((Int32[])data[y])[x];
                        if (value > maxValue) maxValue = value;
                        if ((value < minValue) && (value != trnValue)) minValue = value;
                    }

                double crtMinAmpl = bscale * minValue + bzero;
                double crtMaxAmpl = bscale * maxValue + bzero;
                if (crtMinAmpl < minAmpl) minAmpl = crtMinAmpl;
                if (crtMaxAmpl > maxAmpl) maxAmpl = crtMaxAmpl;
            }
        }

        public void CalcDependency(string file, double min, double max, out List<DateValue> points)
        {
            fits = new Fits(file, FileAccess.Read);
            hdus = fits.Read();

            points = new List<DateValue> { };
            if (hdus == null) return;

            int naxis = 0;
            for (int i = 0; i < hdus.Length; i++)
            {
                DateTime dateTime;
                double sum = 0.0;

                var hdr = hdus[i].Header;
                if (!hdr.ContainsKey("SIMPLE")) break;

                // Определение границ для амплитудных значений

                if (hdr.ContainsKey("NAXIS"))
                    naxis = hdr.GetIntValue("NAXIS");
                if (naxis != 2) break;

                if (!hdr.ContainsKey("DATE-OBS")) break;
                if (!DateTime.TryParse(hdr.GetStringValue("DATE-OBS"), out dateTime))
                    break;

                int bits = hdus[i].BitPix;
                BitPix bitpix = BitPix.Unknown;

                switch (bits)
                {
                    case 8: bitpix = BitPix.Bits8; break;
                    case 16: bitpix = BitPix.Bits16; break;
                    case 32: bitpix = BitPix.Bits32; break;
                    default: bitpix = BitPix.Unknown; break;
                }
                Array[] data;
                if (bitpix != BitPix.Unknown)
                    data = (Array[])hdus[i].Kernel;
                else
                    break;

                int width = data[0].GetLength(0);
                int height = data.GetLength(0);

                if (!hdr.ContainsKey("BSCALE") ||
                    !hdr.ContainsKey("BZERO"))
                    break;
                var bscale = hdus[i].BScale;
                var bzero = hdus[i].BZero;

                // Определение значения для прозрачного фона
                Int32 trnValue = 0;
                if (bitpix == BitPix.Bits8) trnValue = byte.MinValue;
                else if (bitpix == BitPix.Bits16) trnValue = Int16.MinValue;
                else if (bitpix == BitPix.Bits32) trnValue = Int32.MinValue;

                // Расчет суммарного значения
                int pointCount = 0;
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        Int32 value = 0;
                        if (bitpix == BitPix.Bits8) value = ((byte[])data[y])[x];
                        else if (bitpix == BitPix.Bits16) value = ((Int16[])data[y])[x];
                        else if (bitpix == BitPix.Bits32) value = ((Int32[])data[y])[x];

                        if (value != trnValue)
                        {
                            double ampl = bscale * value + bzero;
                            if ((ampl > min) && (ampl < max))
                            {
                                sum += ampl;
                                pointCount++;
                            }
                        }
                    }

                if (pointCount != 0)
                    points.Add(new DateValue(dateTime, sum / pointCount));
            }
        }

    }

    public struct DateValue
    {
        public DateTime Date;
        public double Value;

        public DateValue(DateTime date, double value)
        {
            this.Date = date;
            this.Value = value;
        }
    }
}