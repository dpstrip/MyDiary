using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyDiary.Model;

namespace MyDiary.ViewModel
{
    public class ViewPage : ObservableObject
    {
        //I need to set up a list of page.
        //
        private Page page;
        private List<PageDate> listOfPages;

        public ViewPage()
        {
            this.page = new Page();
            this.page.Title = "A thought";
            this.page.Thought = "A deep one";
            this.page.EntryDate = new DateTime(2019, 5, 15);

            //Create list of pages to be placed on calendar
            listOfPages = new List<PageDate>();
            PageDate pd = new PageDate();
            pd.EntryDate = new DateTime(2019, 5, 4);
            pd.id = 1;
            listOfPages.Add(pd);

            PageDate pd1 = new PageDate();
            pd1.EntryDate = new DateTime(2019, 5, 5);
            pd1.id = 2;
            listOfPages.Add(pd1);

            PageDate pd2 = new PageDate();
            pd2.EntryDate = new DateTime(2019, 5, 14);
            pd2.id = 3;
            listOfPages.Add(pd2);

        }

        public List<PageDate> ListOfDateEntry
        {
            get { return listOfPages; }
            set { listOfPages = value; }
        }

        public string Title {
            get { return page.Title; }
            set
            {
                {
                    if (page.Title != value)
                    {
                        page.Title = value;
                        //OnPropertyChange("Title");
                    }
                }
            }
        }
        public string Thought {
            get { return page.Thought; }
            set{
                {
                    if (page.Thought != value)
                    {
                        page.Thought = value;
                        //OnPropertyChange("Thought");
}
                }
            }
        }
        public DateTime EntryDate {
            get { return page.EntryDate; }
            set
            {
                {
                    if (page.EntryDate != value)
                    {
                        page.EntryDate = value;
                        OnPropertyChange("EntryDate");
                    }
                }
            }
        }
        public ICommand SaveTextCommand
        {
            get { return new DelegateCommand(SaveText); }
        }

        

        private void SelectedDate()
        {
            Console.WriteLine("A date was selected");
        }

        public void SaveText()
        {
            
            Console.WriteLine(this.Title + ",   " + this.Thought + ",  " + this.EntryDate);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                SelectedDate();
            }
        }
    }
}
