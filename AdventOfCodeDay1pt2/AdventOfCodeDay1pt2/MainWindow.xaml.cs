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

namespace AdventOfCodeDay1pt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int captcha { get; set; }
        public int answer { get; set; }

        private CaptchaDecoder decoder = new CaptchaDecoder();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Captcha_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.decoder.ResetSum();

            this.decoder.SetCaptcha(captchaTextbox.Text);
            this.decoder.ParseCaptcha();

            answerTextbox.Text = this.decoder.GetResult().ToString();
        }
    }
}
