using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class ItemsRepository
    {
        public List<Item> items;

        public ItemsRepository()
        {
            items = new List<Item>();
            FillRepository();
        }
        private void FillRepository()
        {
            using(MyContext db = new MyContext())
            {
                //requests = db.RequestSubjects.Include("Request").Include("Subject").ToList();
                items = db.Items.Include("Subject").ToList();
            }
            
        }
        public List<Item> GetItems()
        {
            return items;
        }
    }
}