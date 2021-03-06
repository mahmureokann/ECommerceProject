using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tools
{
    public class DbContextSingleton
    {
        private DbContextSingleton()
        {

        }

        private static ECommerceContext _context;
        public static ECommerceContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ECommerceContext();
                }
                return _context;
            }
        }
    }
}
