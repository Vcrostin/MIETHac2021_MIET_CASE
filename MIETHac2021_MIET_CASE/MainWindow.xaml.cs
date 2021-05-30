using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MIETHac2021_MIET_CASE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            FIOl.MinWidth = GroupL.ActualWidth;
            FIO.MinWidth = TextBlockMainText.ActualWidth - FIOl.ActualWidth;
            FIO.MaxWidth = TextBlockMainText.ActualWidth - FIOl.ActualWidth;

            Group.MinWidth = TextBlockMainText.ActualWidth - GroupL.ActualWidth;
            Group.MaxWidth = TextBlockMainText.ActualWidth - GroupL.ActualWidth;
        }

        private static bool FIO_Check(string str)
        {
            if (str.Split(' ').Length == 3)
                return true;
            return false;
        }

        private string path;

        private void OnStartClick(object sender, RoutedEventArgs e)
        {
            if ((bool)AgreedRB.IsChecked && FIO_Check(FIO.Text) && Group_Check(Group.Text))
            {
                //this.Hide();
                MessageBox.Show(
                    "Пожалуйста вздохните глубоко, выдохните и настройтесь на 15-20 минут рефлексивной работы. " +
                    "Внимательно читайте вопрос и соотносите его с вашим преобладающим состоянием. Постарайтесь отвечать " +
                    "по возможности быстро. Некоторые вопросы могут вызывать затруднение или сопротивление, однако постарайтесь " +
                    "и на них не задерживаться слишком долго.", "Инструкция",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                if (path.Length == 0)
                {
                    MessageBox.Show("Выберите файл данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Show();
                    return;
                }
                this.Hide();
                DataClass dc = new(this, path);
                dc.makeWindow();
            }
            else
            {
                MessageBox.Show("Введите ФИО в формати Фамилия Имя Отчество, группу в формате П-11 и согласитесь на прохождение тестирования"
                    , "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static bool Group_Check(string text)
        {
            if (text.Split('-').Length == 2)
            {
                string[] str_arr = text.Split('-');
                if(str_arr[0].Length < 5)
                {
                    if(str_arr[1][0]>'0' && str_arr[1][0] < '5')
                    {
                        if (int.TryParse(str_arr[1], out _))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                fileName.Content = path.Split('\\').Last();
            }
        }
    }
}
