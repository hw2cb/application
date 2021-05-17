using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class SubjectRepository
    {
        public List<Subject> subjects;

        public SubjectRepository()
        {
            subjects = new List<Subject>();
            FillRepository();
        }
        private void FillRepository()
        {
            using (MyContext db = new MyContext())
            {
                //заполнение
                List<Subject> fillSubj = new List<Subject>()
                {
                    new Subject(){Name = "Стул"},
                    new Subject(){Name = "Стол"},
                    new Subject(){Name = "Калькулятор"},
                    new Subject(){Name = "Ведро"},
                    new Subject(){Name = "Веник"}

                };
                db.Subjects.AddRange(fillSubj);
                db.SaveChanges();
                subjects = db.Subjects.ToList();
            }
        }
        public IEnumerable<Subject> GetSubjectsRepository() => subjects;
    }
}