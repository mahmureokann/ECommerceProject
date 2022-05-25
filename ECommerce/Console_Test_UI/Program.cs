using DataAccess.Context;
using DataAccess.Entity;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Test_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryService categoryService = new CategoryService();

            
            //Listeleme Test
            foreach (var category in categoryService.GetList())
            {
                Console.WriteLine(category.CategoryName);
            }
            Console.WriteLine("****************************");

            //Güncelleme Test
            var updated = categoryService.GetById(Guid.Parse("FF13193D-98A0-4246-B17F-165309CD075F"));
            updated.CategoryName = "Oto Aksesuar";

            categoryService.Update(updated);

            foreach (var category in categoryService.GetList())
            {
                Console.WriteLine(category.CategoryName);
            }
            Console.WriteLine("****************************");
            //Silme Test

            categoryService.Delete(Guid.Parse("FF13193D-98A0-4246-B17F-165309CD075F"));

            foreach (var category in categoryService.GetDefault(x=>x.Status==Core.Enums.Status.Active))
            {
                Console.WriteLine(category.CategoryName);
            }

            Console.Read();
        }
    }
}
