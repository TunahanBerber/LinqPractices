using System;
using System.Linq;
using LinqPractices.DbOperations;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            using (var _context = new LinqDbContext())
            {
                var students = _context.Students.ToList(); // Öğrenci listesi çekiliyor

                //! Find (Veriye Erişmemizi sağlıyor)
                Console.WriteLine("***Find***");
                var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
                Console.WriteLine(student.Name);

                student = _context.Students.Find(2);
                Console.WriteLine(student.Name);

                //! FirstOrDefault()
                Console.WriteLine();
                Console.WriteLine("****FirstOrDefault****");
                student = _context.Students.FirstOrDefault(student => student.Surname == "Berber");
                Console.WriteLine(student.Name);

                //!! SingleOrDefault
                Console.WriteLine();
                Console.WriteLine("****SingleOrDefault****");
                student = _context.Students.SingleOrDefault(student => student.Name == "Tuna Han");
                Console.WriteLine(student.Surname);

                //! ToList
                Console.WriteLine();
                Console.WriteLine("*****ToList*****");
                var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();
                Console.WriteLine(studentList.Count);

                //! OrderBy

                Console.WriteLine();

                students = _context.Students.OrderBy(x => x.StudentId).ToList();
                foreach (var st in students)
                {
                    Console.WriteLine(st.StudentId + " - " + st.Surname);
                }


                //! OrderByDescending(Tersten Sıralar)

                Console.WriteLine();

                students = _context.Students.OrderByDescending(x => x.StudentId).ToList();
                foreach (var st in students)
                {
                    Console.WriteLine(st.StudentId + " - " + st.Surname);
                }


                //Anonymous Object Result 
                Console.WriteLine();
                Console.WriteLine("*****Anonymous Object Result ****");

                var anonymousObject = _context.Students.Where(x => x.ClassId == 2).Select(x => new
                {
                    Id = x.StudentId,
                    FullName = x.Name + " " + x.Surname
                });
                foreach (var obj in anonymousObject)
                {
                    Console.WriteLine(obj.Id + " - " + obj.FullName);
                }
            }
        }
    }
}

//! Bunlar Günlük hayatta en sık kullanılan linQ ilemleridir.
