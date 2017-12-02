using Microsoft.Win32;
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

namespace AdventOfCodeDay2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SpreadsheetChecksum SpreadsheetParser;

        public MainWindow()
        {
            InitializeComponent();

            this.SpreadsheetParser = new SpreadsheetChecksum();
        }

        private void bOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                this.SpreadsheetParser.LoadFile(openFileDialog1.FileName);
                tbFileName.Text = openFileDialog1.FileName;

                this.SpreadsheetParser.ParseFile();

                var calculations = this.SpreadsheetParser.GetResults();

                tbSum.Text = calculations[0];
                tbTotal.Text = calculations[1];
            }
        }
    }
}
