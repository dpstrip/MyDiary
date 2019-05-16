using MyDiary.Model;
using MyDiary.ViewModel;
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

namespace MyDiary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewPage vp;
        public MainWindow()
        {
            InitializeComponent();
            vp = new ViewPage();
            DataContext = vp;
            UpdateCalendarWithEntryDates();
        }

        private void UpdateCalendarWithEntryDates()
        {
            calendar.SelectedDates.Add(DateTime.Today.Date);
            if (vp.ListOfDateEntry != null)
            {
                foreach (PageDate pd in vp.ListOfDateEntry)
                    calendar.SelectedDates.Add(pd.EntryDate);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(vp.Title + ",  " + vp.Thought);
            if (calendar.SelectedDate == null)
            {
                vp.EntryDate = DateTime.Today.Date;
            }
            else
            {
                vp.EntryDate = (DateTime)calendar.SelectedDate;
            }
            vp.SaveText();
        }


    }
}
