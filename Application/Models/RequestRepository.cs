using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{

    public class RequestRepository
    {
        public List<RequestSubject> requests;

        public RequestRepository()
        {
            requests = new List<RequestSubject>();
            FillRepository();
        }
        private void FillRepository()
        {
            using(MyContext db = new MyContext())
            {
                requests = db.RequestSubjects.Include("Request").Include("Subject").ToList();
            }
            
        }
        public IEnumerable<RequestSubject> GetRequests()
        {
            return requests;
        }
    }
}