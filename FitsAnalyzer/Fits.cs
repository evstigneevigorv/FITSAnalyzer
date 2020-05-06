using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using nom.tam.fits;
using nom.tam.util;

namespace FitsAnalyzer
{
    enum BitPix { Bits8, Bits16, Bits32, Unknown }
    class FitsWrapper
    {
        private Fits fits = null;
        private BasicHDU[] hdus = null;

        public void OpenFile(string fileName, out int hduNum)
        {
            fits = new Fits(fileName, FileAccess.Read);
            hduNum = fits.Size();
        }

        public bool ReadHeader(int index, out List<string[]> table, out bool hasImage)
        {
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
    }

}