using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MIETHac2021_MIET_CASE
{
    class DataClass
    {

        private string Path { get; }
        private readonly MainWindow mw;
        private static Dictionary<int, List<OneElem>> Dc { get; set; }
        public static Dictionary<int, List<OneElem>> GetDc => Dc;
        public static int CountValue { get; set; }
        private List<Window> lWindow;
        //private List<OneElem> Arr_str { get; }
        public class OneElem
        {
            public string Description { get; }
            public List<int> DataKey { get; }
            public int Chosen_index { get; set; }

            public void index_choose(int chs)
            {
                Chosen_index = chs;
            }

            public OneElem(string str)
            {
                Chosen_index = -1;
                string[] astr = str.Split(';');
                DataKey = new();
                Description = astr[0];
                int n = int.Parse(astr[1]);
                for(int i = 2; i < 2 + n; ++i)
                {
                    DataKey.Add(int.Parse(astr[i]));
                }
            }

        }

        public void makeWindow()
        {
            int counter = 1;
            foreach(var elem in Dc)
            {
                counter++;
                switch (elem.Key)
                {
                    case 2:
                        {
                            Test t = new(mw, lWindow, counter);
                            int counter2 = 0;
                            foreach(var el in elem.Value)
                            {
                                counter2++;
                                Grid grid = new();
                                ColumnDefinition cw1 = new();
                                cw1.Width = new GridLength(4,GridUnitType.Star);
                                ColumnDefinition cw2 = new();
                                cw2.Width = new GridLength(1, GridUnitType.Star);
                                ColumnDefinition cw3 = new();
                                cw3.Width = new GridLength(1, GridUnitType.Star);
                                grid.ColumnDefinitions.Add(cw1);
                                grid.ColumnDefinitions.Add(cw2);
                                grid.ColumnDefinitions.Add(cw3);
                                TextBox l = new();
                                l.Text = el.Description;
                                l.BorderBrush = Brushes.Black;
                                l.BorderThickness = new(1);
                                l.SetValue(Grid.ColumnProperty, 0);
                                l.IsReadOnly = true;
                                l.TextWrapping = TextWrapping.Wrap;
                                grid.Children.Add(l);
                                RadioButton rb1 = new RadioButton();
                                rb1.HorizontalAlignment = HorizontalAlignment.Center;
                                rb1.VerticalAlignment = VerticalAlignment.Center;
                                rb1.GroupName = "radioButton" + ":" + counter.ToString() + ":" + counter2.ToString();
                                rb1.SetValue(Grid.ColumnProperty, 1);
                                rb1.BorderBrush = Brushes.Black;
                                rb1.BorderThickness = new(2);
                                rb1.Checked += (sender, e) => {
                                    RadioButton li = (sender as RadioButton);
                                    var str = li.GroupName.Split(':');
                                    Dc[int.Parse(str[1])][int.Parse(str[2])-1].index_choose(0);
                                    return;
                                };
                                grid.Children.Add(rb1);
                                RadioButton rb2 = new RadioButton();
                                rb2.HorizontalAlignment = HorizontalAlignment.Center;
                                rb2.VerticalAlignment = VerticalAlignment.Center;
                                rb2.GroupName = "radioButton" + ":" + counter.ToString() + ":" + counter2.ToString();
                                rb2.SetValue(Grid.ColumnProperty, 2);
                                rb2.BorderBrush = Brushes.Black;
                                rb2.BorderThickness = new(2);
                                rb2.Checked += (sender, e) => {
                                    RadioButton li = (sender as RadioButton);
                                    var str = li.GroupName.Split(':');
                                    Dc[int.Parse(str[1])][int.Parse(str[2]) - 1].index_choose(1);
                                    return;
                                };
                                grid.Children.Add(rb2);
                                t.dataPanel.Children.Add(grid);
                            }
                            t.Show();
                            break;
                        }
                    case 3:
                        {
                            Test2 t = new(mw, lWindow, counter);
                            int counter2 = 0;
                            foreach (var el in elem.Value)
                            {
                                counter2++;
                                Grid grid = new();
                                ColumnDefinition cw1 = new();
                                cw1.Width = new GridLength(4, GridUnitType.Star);
                                ColumnDefinition cw2 = new();
                                cw2.Width = new GridLength(1, GridUnitType.Star);
                                ColumnDefinition cw3 = new();
                                cw3.Width = new GridLength(1, GridUnitType.Star);
                                ColumnDefinition cw4 = new();
                                cw4.Width = new GridLength(1, GridUnitType.Star);
                                grid.ColumnDefinitions.Add(cw1);
                                grid.ColumnDefinitions.Add(cw2);
                                grid.ColumnDefinitions.Add(cw3);
                                grid.ColumnDefinitions.Add(cw4);
                                TextBox l = new();
                                l.Text = el.Description;
                                l.BorderBrush = Brushes.Black;
                                l.BorderThickness = new(1);
                                l.SetValue(Grid.ColumnProperty, 0);
                                l.IsReadOnly = true;
                                l.TextWrapping = TextWrapping.Wrap;
                                grid.Children.Add(l);
                                RadioButton rb1 = new RadioButton();
                                rb1.HorizontalAlignment = HorizontalAlignment.Center;
                                rb1.VerticalAlignment = VerticalAlignment.Center;
                                rb1.GroupName = "radioButton2"+ ":" + counter.ToString() + ":" + counter2.ToString();
                                rb1.SetValue(Grid.ColumnProperty, 1);
                                rb1.BorderBrush = Brushes.Black;
                                rb1.BorderThickness = new(2);
                                rb1.Checked += (sender, e) => {
                                    RadioButton li = (sender as RadioButton);
                                    var str = li.GroupName.Split(':');
                                    Dc[int.Parse(str[1])][int.Parse(str[2]) - 1].index_choose(0);
                                    return;
                                };
                                grid.Children.Add(rb1);
                                RadioButton rb2 = new RadioButton();
                                rb2.HorizontalAlignment = HorizontalAlignment.Center;
                                rb2.VerticalAlignment = VerticalAlignment.Center;
                                rb2.GroupName = "radioButton2" + ":" + counter.ToString() + ":" + counter2.ToString();
                                rb2.SetValue(Grid.ColumnProperty, 2);
                                rb2.BorderBrush = Brushes.Black;
                                rb2.BorderThickness = new(2);
                                rb2.Checked += (sender, e) => {
                                    RadioButton li = (sender as RadioButton);
                                    var str = li.GroupName.Split(':');
                                    Dc[int.Parse(str[1])][int.Parse(str[2]) - 1].index_choose(1);
                                    return;
                                };
                                grid.Children.Add(rb2);
                                RadioButton rb3 = new RadioButton();
                                rb3.HorizontalAlignment = HorizontalAlignment.Center;
                                rb3.VerticalAlignment = VerticalAlignment.Center;
                                rb3.GroupName = "radioButton2" + ":" + counter.ToString() + ":" + counter2.ToString();
                                rb3.SetValue(Grid.ColumnProperty, 3);
                                rb3.BorderBrush = Brushes.Black;
                                rb3.BorderThickness = new(2);
                                rb3.Checked += (sender, e) => {
                                    RadioButton li = (sender as RadioButton);
                                    var str = li.GroupName.Split(':');
                                    Dc[int.Parse(str[1])][int.Parse(str[2]) - 1].index_choose(2);
                                    return;
                                };
                                grid.Children.Add(rb3);
                                t.dataPanel.Children.Add(grid);
                            }
                            t.Show();
                            break;
                        }
                }
            }
        }
        public DataClass(MainWindow wd, string path)
        {
            this.Path = path;
            Dc = new();
            lWindow = new();
            List<OneElem> Arr_str = new(); 
            foreach (var s in File.ReadAllText(path).Split('\n'))
            {
                if (s.Length > 0)
                {
                    Arr_str.Add(new OneElem(s));
                }
            }
            Arr_str.Sort((c1, c2) =>
            {
                if (c1.DataKey.Count == c2.DataKey.Count)
                {
                    return c1.Description.CompareTo(c2.Description);
                }
                return c1.DataKey.Count.CompareTo(c2.DataKey.Count);
            });
            mw = wd;
            foreach(var el in Arr_str)
            {
                if(!Dc.TryGetValue(el.DataKey.Count,out _))
                {
                    Dc.Add(el.DataKey.Count, new());
                }
                Dc[el.DataKey.Count].Add(el);
            }
        }
    }
}
