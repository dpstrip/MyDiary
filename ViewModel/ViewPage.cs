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
        private DiaryRepository dr;

        public ViewPage()
        {
            //Will create a DR object and get list of dates.
            dr = new DiaryRepository();
            listOfPages = dr.GetPageDates(DateTime.Today.Date);
            page = new Page(); //Need to have an object even if it is empty to load.

            //this.page = new Page();
            //this.page.Title = "A thought";
            //this.page.Thought = "A deep one";
            //this.page.EntryDate = new DateTime(2019, 5, 15);

            ////Create list of pages to be placed on calendar
            //listOfPages = new List<PageDate>();
            //PageDate pd = new PageDate();
            //pd.EntryDate = new DateTime(2019, 5, 4);
            //pd.id = 1;
            //listOfPages.Add(pd);

            //PageDate pd1 = new PageDate();
            //pd1.EntryDate = new DateTime(2019, 5, 5);
            //pd1.id = 2;
            //listOfPages.Add(pd1);

            //PageDate pd2 = new PageDate();
            //pd2.EntryDate = new DateTime(2019, 5, 14);
            //pd2.id = 3;
            //listOfPages.Add(pd2);

        }

        public List<PageDate> ListOfDateEntry
        {
            get { return listOfPages; }
            set {
                listOfPages = value;
                RaisePropertyChangedEvent("ListOfDateEntry");
            }
        }

        public string Title {
            get { return page.Title; }
            set
            {
                {
                    if (page.Title != value)
                    {
                        page.Title = value;
                       
                        RaisePropertyChangedEvent("Title");
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
                        RaisePropertyChangedEvent("Thought");
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
                        //OnPropertyChange("EntryDate");
                        RaisePropertyChangedEvent("EntryDate");
                    }
                }
            }
        }
        public ICommand SaveTextCommand
        {
            get { return new DelegateCommand(SaveText); }
        }

        
        //Not used
        private void SelectedDate()
        {
            Console.WriteLine("A date was selected");
        }

        public void SaveText()
        {
            
            Console.WriteLine(this.Title + ",   " + this.Thought + ",  " + this.EntryDate);
            dr.InsertData(page);
        }


        public void CheckPageList(DateTime dt)
        {
            //I need to check if the page exists. if it doesn't then create a new page.else
            //set the page to the old page.
            //I need to see if the month of dt is same month as list.  If not update list
            CheckListOfDates(dt);

            //1.) check if page exists
            PageDate tempPage = listOfPages.Find(x => x.EntryDate == dt);
            if (tempPage == null)
            {
                //Page newPage = new Page();
                this.page.id = 0;
                this.Thought = null;
                this.Title = null;
                this.EntryDate = new DateTime(1, 1, 1);
            }
            else
            {
                //find page and set it to Page
                Page foundPage = dr.GetPage(tempPage.id);
                this.page.id = foundPage.id;
                this.Thought = foundPage.Thought;
                this.Title = foundPage.Title;
                this.EntryDate = foundPage.EntryDate;
            }

            Console.WriteLine("Object id {0}, {1}, {2}, {3}", page.id, page.EntryDate, page.Title, page.Thought);

        }

        private void CheckListOfDates(DateTime dt)
        {
            int dtMonth = dt.Month;
            int pdMonth = 0;
            if (listOfPages.Count > 0)
            {
                pdMonth = listOfPages[0].EntryDate.Month;
            }
           
            if (dtMonth != pdMonth)
            {
                listOfPages = dr.GetPageDates(dt.Date);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                SelectedDate();
                Console.WriteLine("Here {0}", propertyName);
            }
        }
    }
}
