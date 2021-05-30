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
using System.Windows.Shapes;

namespace MIETHac2021_MIET_CASE
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test(MainWindow wd,List<Window> windows, int num)
        {
            mw = wd;
            InitializeComponent();
        }

        private readonly MainWindow mw;

        private void Window_Closed(object sender, EventArgs e)
        {
            mw.Show();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //gd_show.MaxHeight = mainInfoGrid.ActualHeight - nextbtn.ActualHeight;
        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
