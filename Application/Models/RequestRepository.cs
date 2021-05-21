using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Application.Models
{

    public class RequestRepository
    {
        public List<Request> requests;
        public RequestRepository()
        {
            requests = new List<Request>();
            FillRepository();
        }
        private void FillRepository()
        {
            using(MyContext db = new MyContext())
            {
                requests = db.Requests.Include(x=>x.Items.Select(y=>y.Subject)).ToList();
            }
            
        }
        public List<Request> GetRequests()
        {
            return requests;
        }
    }
}