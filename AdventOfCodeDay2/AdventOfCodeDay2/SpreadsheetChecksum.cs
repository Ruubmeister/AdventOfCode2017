using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay2
{
    class SpreadsheetChecksum
    {

        private List<string> lines = new List<string>();

        private List<int> diffPerRow = new List<int>();


        public void LoadFile(string fileName)
        {
            StreamReader reader = File.OpenText(fileName);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                this.lines.Add(line);
            }
        }

        private int ParseLine(string line)
        {
            int min = 0;
            int max = 0;

            var numbers = line.Split('\t').Select(Int32.Parse).ToList();

            foreach(int number in numbers)
            {
                if(number < min || min == 0)
                {
                    min = number;
                }

                if (number > max || max == 0)
                {
                    max = number;
                }
            }

            return max - min;
        }

        public void ParseFile()
        {
            foreach (string line in this.lines)
            {
                this.diffPerRow.Add(this.ParseLine(line));
            }
        }

        public string[] GetResults()
        {
            string resultString = String.Join(" + ", this.diffPerRow.Select(x => x.ToString()).ToArray());

            int sum = this.diffPerRow.Sum();

            string[] result = new string[] { "Sum: " + resultString, "Total: " + sum };


            return result;
        }
    }
}
