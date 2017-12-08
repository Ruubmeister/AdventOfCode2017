using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay3
{
    class SpiralMemoryLibrary
    {
        private int startNumber;
        private double step;
        private double root;

        private string x;
        private string y;

        private double stepsFromCenter;
            
        public void setNumber(int number)
        {
            startNumber = number;
        }

        private void CalculateRoot()
        {
            root = Math.Ceiling(Math.Sqrt(startNumber));

            if(root%2 == 0)
            {
                root++;
            }
        }

        private void CalculateStep()
        {
            step = Math.Ceiling(root);
        }

        private void ProcessSteps()
        {

            double blockCalc = Math.Pow(step, 2);

            while ((blockCalc - (step-1)) > startNumber)
            {
                blockCalc -= (step-1);
            }

            double centerNumber = blockCalc - Math.Floor(step / 2);

            double outerStep = (step - 1) / 2;

            double sideStep = Math.Abs(centerNumber - startNumber);

            stepsFromCenter = outerStep + sideStep;
        }

        public double GetStepsFromCenter()
        {
            CalculateRoot();
            CalculateStep();
            ProcessSteps();

            return stepsFromCenter;
        }
    }
}
