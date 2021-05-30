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
using System.Windows.Shapes;

namespace MIETHac2021_MIET_CASE
{
    /// <summary>
    /// Логика взаимодействия для Test2.xaml
    /// </summary>
    public partial class Test2 : Window
    {
        public Test2(MainWindow wd, List<Window> windows, int num)
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
            //gd_show.MaxHeight = mainInfoGrid.ActualHeight - 2*nextbtn.ActualHeight;
        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            foreach(var el in DataClass.GetDc)
            {
                foreach(var elSec in el.Value)
                {
                    if (elSec.Chosen_index != -1)
                        counter += elSec.DataKey[elSec.Chosen_index];
                }
            }
            DataClass.CountValue = counter;
            this.Hide();
            switch (counter)
            {
                case >= 60:
                    MessageBox.Show("Ваша нервная система испытывает чрезмерные нагрузки. Ваш уровень стресса сильно завышен. Ваш уровень осознанности очень низкий, что не позволяет вам понять истинных причин постоянного напряжения, а также управлять собственным состоянием. Постоянное напряжение вызывает также сложности во взаимодействии с другими, зачастую не позволяет принять поддержку или попросить о ней, что только подливает масла в огонь. Вам требуется психологическая поддержка, а ваше эмоциональное состояние требует немедленной корректировки."
                        , "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case <= 59 and >= 45:
                    MessageBox.Show("Ваш уровень стресса высокий, однако вы в состоянии контролировать напряжение. Вы способны обратить внимание на свое состояние и понять причину своих эмоциональных реакций. Свойства вашей нервной системы позволяют сохранять приемлемую работоспособность. Однако высокий уровень напряжения истощает и, в какой-то момент чаша может оказаться переполненной. Вероятно, вам не хватает знаний и навыков для полноговладения своим психическим состоянием в ряде ситуаций. Такие навыки вы можете приобрести на специальных психологических тренингах, а также на индивидуальных консультациях с психологом."
                        , "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case >= 16 and <= 44:
                    MessageBox.Show("У вас хорошие адаптивные возможности. Ваша психика успешно справляется с требованиями окружающей среды. Вы способны контролировать эмоциональное состояние в разнообразных условиях. В то же время, если вы все же чувствуете внутреннюю неудовлетворенность происходящим в вашей жизни, пожалуйста обратите должное внимание на это ощущение. На индивидуальной консультации с психологом вы всегда можете поделиться любыми происходящими внутри вас процессами."
                        , "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case <= 15:
                    MessageBox.Show("Ваш уровень напряжения близок к нулевой отметке. Такой результат может говорить о том, что вы либо уделили вопросам недостаточно внимания, либо вы крайне плохо осознаете происходящие с вами процессы. Рекомендуем вам пройти опросник позднее повторно более внимательно или обратиться за консультацией к психологу.",
                        "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
            string group;
            switch (counter)
            {
                case >= 60:
                    group = "группа A «повышенного риска». Снижение адаптивных способностей, вероятен риск развития невроза, депрессии, аутоагрессивного, поведения. Требуются коррекционные псих. меры, при необходимости направление к медикам.";
                    break;
                case >= 53 and <= 59:
                    group = "группа B «латентная». Студент испытывает максимальное напряжение и нагрузки на нервную систему. Требуются наблюдение, профилактические, поддерживающие меры со стороны социально-психологической службы.";
                    break;
                case < 15:
                    group = "группа C - вероятны скрытые проблемы/ потенциальные проблемы с дисциплиной/проявления асоциального поведения. Требуются коррекционно-воспитательные меры по профилактики агрессии и асоциального поведения.";
                    break;
                default:
                    group = "OK";
                    break;

            }
            File.AppendAllText("output.csv", mw.FIO.Text + ";" + mw.Group.Text + ";" + group);
            Application.Current.Shutdown();
        }
    }
}
