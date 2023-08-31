using System.Linq;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if (context.Students.Any())
                {
                    return;
                }

                context.Students.AddRange(new[]
                {
                    new Student()
                    {
                        Name = "Ayse",
                        Surname = "Yılmaz",
                        ClassId = 1 
                    },
                    new Student()
                    {
                        Name = "Tuna Han",
                        Surname = "Berber",
                        ClassId = 1 
                    },
                    new Student()
                    {
                        Name = "Hayri",
                        Surname = "Kırkağaç",
                        ClassId = 2 
                    },
                    new Student()
                    { 
                        Name = "Aybüke",
                        Surname = "Garip",
                        ClassId = 2 
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
