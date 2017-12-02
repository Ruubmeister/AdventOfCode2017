using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay1pt2
{
    class CaptchaDecoder
    {

        private string captcha;
        private int sum = 0;

        private int EvaluateNumber(int FirstNumber, int SecondNumber)
        {
            int result = 0;

            if (FirstNumber == SecondNumber)
            {
                result = FirstNumber;
            }

            return result;
        }

        public void SetCaptcha(string captcha)
        {
            this.captcha = captcha;
        }

        public void ResetSum()
        {
            this.sum = 0;
        }

        public void ParseCaptcha()
        {
            int last = this.captcha.Length - 1;
            int steps = (last + 1) / 2;

            if (this.captcha.Length > 1)
            {
                for (int loop = 0; loop < last; loop++)
                {
                    int CurrNumber = (int)Char.GetNumericValue(captcha[loop]);
                    int NextStep = loop + steps;

                    if (NextStep > last)
                    {
                        NextStep -= (last + 1);
                    }

                    int NextNumber = (int)Char.GetNumericValue(captcha[NextStep]);

                    this.sum += this.EvaluateNumber(CurrNumber, NextNumber);
                }

                this.sum += this.EvaluateNumber((int)Char.GetNumericValue(captcha[last]), (int)Char.GetNumericValue(captcha[last - steps]));
            }
        }

        public int GetResult()
        {
            return this.sum;
        }
    
}
}
