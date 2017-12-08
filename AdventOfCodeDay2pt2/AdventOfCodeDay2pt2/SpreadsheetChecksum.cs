using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay2pt2
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

            var numbers = line.Split('\t').Select(Int32.Parse).ToList();
            int numbers_length = numbers.Count;

            int row_sum = 0;

            for (int i = 0; i < numbers_length; i++ )
            {
                for (int j = 0; j < numbers_length; j++)
                {
                    if (i != j && (numbers[i] % numbers[j]) == 0)
                    {
                        row_sum += numbers[i] / numbers[j];
                    }
                }
            }

            return row_sum;

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