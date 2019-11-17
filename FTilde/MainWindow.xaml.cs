using System;
using System.Collections.Generic;

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
using TBKMath;
using System.IO;

namespace FTilde
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FTildeDriver ftd;
        public MainWindow()
        {
            InitializeComponent();
            NBox.Text = 1000.ToString();
            KBox.Text = 50.ToString();
            ZetaBox.Text = 1.ToString();
            nRepBox.Text = 10000.ToString();
        }

        private void GoButton_Handler(object sender, RoutedEventArgs e)
        {
            ftd = new FTildeDriver();
            ftd.N = int.Parse(NBox.Text);
            ftd.K = int.Parse(KBox.Text);
            ftd.zeta = int.Parse(ZetaBox.Text);
            int nRep = int.Parse(nRepBox.Text);

            double[] samples = ftd.GenerateSamples(nRep);
            string[] output = Array.ConvertAll(samples, x=>x.ToString());
            File.WriteAllLines("sample.txt", output);
        }
    }
}
