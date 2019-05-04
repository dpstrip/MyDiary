﻿using System;
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
            this.page.title = "A thought";
            this.page.thought = "A deep one";
            this.page.entryDate = new DateTime(2019, 5, 15);
        }

        public string Title {
            get { return page.title; }
            set
            {
                {
                    if (page.title != value)
                    {
                        page.title = value;
                        //OnPropertyChange("Title");
                    }
                }
            }
        }
        public string Thought {
            get { return page.thought; }
            set{
                {
                    if (page.thought != value)
                    {
                        page.thought = value;
                        //OnPropertyChange("Thought");
}
                }
            }
        }
        public DateTime EntryDate {
            get { return page.entryDate; }
            set
            {
                {
                    if (page.entryDate != value)
                    {
                        page.entryDate = value;
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

        private void SaveText()
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
