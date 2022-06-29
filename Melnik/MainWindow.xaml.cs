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
using System.IO;

namespace Melnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new();
            if (openFile.ShowDialog() == true)
            {
                path = openFile.FileName;
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, (int)fs.Length);
                fs.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < bt.Length; i++)
                {
                    bt[i] = (byte)~bt[i];
                }
                fs.Write(bt, 0, (int)fs.Length);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new(path, FileMode.OpenOrCreate))
            {
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, (int)fs.Length);
                fs.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < bt.Length; i++)
                {
                    bt[i] = (byte)(bt[i] << 4 | bt[i] >> 4);
                }
                fs.Write(bt, 0, (int)fs.Length);
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, (int)fs.Length);
                fs.Seek(0, SeekOrigin.Begin);
                for (int i = 1; i < bt.Length / 2; i++)
                {
                    int centr = bt.Length / 2;
                    byte s = bt[centr - i];
                    bt[centr - i] = bt[centr + i];
                    bt[centr + i] = s;
                    
                }
                fs.Write(bt, 0, (int)fs.Length);
            }
        }
    }
}
