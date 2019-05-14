using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using MyDiary.Model;

namespace MyDiary.Model
{
    public class DiaryRepository
    {
        private LiteDatabase db;
        private LiteCollection<Page> pageCollection;

        public DiaryRepository()
        {
            //Add stuff for getting db out of app.config
            string filename = "database.db";
            db = new LiteDatabase(filename);
            pageCollection = db.GetCollection<Page>("Pages");
        }

        private void CreateData(Page page)
        {
            try
            {
                pageCollection.Insert(page);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateData(Page page)
        {
            try
            {
                pageCollection.Update(page.id, page);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InsertData(Page page)
        {
            if (page.id != 0)
            {
                UpdateData(page);
            }
            else
            {
                CreateData(page);
            }
        }

        private DateTime BeginMonth(DateTime today)
        {
            return new DateTime(today.Year, today.Month, 1).Date;
        }

        private DateTime EndMonth(DateTime today)
        {
            return new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1).Date;
        }

        public List<PageDate> GetPageDates(DateTime today)
        {
            List<PageDate> pgIDList;
            DateTime start = BeginMonth(today);
            DateTime end = EndMonth(today);

            try
            {
                var pageCollection = db.GetCollection<PageDate>("Pages");
                pgIDList = pageCollection.Find(Query.Between("EntryDate", start, end, true, true)).ToList<PageDate>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                pgIDList = null;
            }

            return pgIDList;
        }

        public Page GetPage(int id)
        {
            Page page;
            try
            {
                page = this.pageCollection.FindById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                page = null;
            }

            return page;
        }

        public List<Page> AllData()
        {
            return this.pageCollection.FindAll().ToList<Page>();
        }
    }
}
