using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdventOfCodeDay3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpiralMemoryLibrary SpiralMemory;
        public MainWindow()
        {
            InitializeComponent();

            this.SpiralMemory = new SpiralMemoryLibrary();
        }

        private void bCalculateNumber(object sender, RoutedEventArgs e)
        {

            string input = tbNumber.Text;

            int number;

            bool success = int.TryParse(input, out number);

            if (success && number > 0)
            {
                SpiralMemory.setNumber(number);
                double answer = SpiralMemory.GetStepsFromCenter();

                tbAnswer.Text = answer.ToString();
            }
        }
    }
}
