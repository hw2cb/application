using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class MyContext :DbContext
    {
        public MyContext ():base("DbConnectionString")
        {

        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSubject> RequestSubjects { get; set; }
    }
}