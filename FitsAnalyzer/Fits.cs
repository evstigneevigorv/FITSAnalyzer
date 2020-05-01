using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using nom.tam.fits;
using nom.tam.util;

namespace FitsAnalyzer
{
    class FitsWrapper
    {
        private Fits fits = null;
        private BasicHDU[] hdus = null;

        public void OpenFile(string fileName)
        {
            fits = new Fits(fileName, FileAccess.Read);
        }

        public bool ReadHeader(int index, out List<string[]> table)
        {
            hdus = fits.Read();

            if (hdus == null) { table = null; return false; }

            table = new List<string[]> { };
            var hdr = hdus[index].Header;

            for (int j = 0; j < hdr.NumberOfCards; j++)
            {
                var hc = new HeaderCard(hdr.GetCard(j));
                var sa = new string[3] { hc.Key, hc.Value, hc.Comment };
                table.Add(sa);
            }
            return (table.Count != 0);
        }

        public void ReadData(int index, out Array[] data)
        {
            data = (Array[])hdus[0].Kernel;
        }
    }

}