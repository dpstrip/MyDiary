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

        public ViewPage()
        {
            this.page = new Page();
            this.page.Title = "A thought";
            this.page.Thought = "A deep one";
            this.page.EntryDate = new DateTime(2019, 5, 15);
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
