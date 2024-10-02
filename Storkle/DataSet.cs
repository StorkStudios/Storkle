using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Storkle
{
    class DataSet
    {
        private Image[] pictures;
        private string[] headers;
        private string[][] data;

        public string[] GetHeroes()
        {
            string[] output = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                output[i] = data[i][1];
            }
            return output;
        }
        public Image[] GetPictures()
        {
            return pictures;
        }
        public string[] GetHeaders()
        {
            return headers;
        }
        public string[][] GetData()
        {
            return data;
        }

        public DataSet(string path)
        {
            List<Image> pictureReader = new List<Image>();
            List<string> reader;
            string[] input = File.ReadAllLines(path, System.Text.Encoding.GetEncoding("utf-8"));
            if (input.Length > 0)
            {
                headers = input[0].Split(new char[] { ',' });
                data = new string[input.Length - 1][];
                for (int i = 1; i < input.Length; i++)
                {
                    data[i - 1] = input[i].Split(new char[] { ',' });
                    pictureReader.Add(Image.FromFile(data[i - 1][0]));
                }
            }
            pictures = pictureReader.ToArray();
        }
    }
}
