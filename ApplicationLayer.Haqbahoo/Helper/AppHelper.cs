using InfrastructionLayer.Haqbahoo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Helper
{
    public class AppHelper
    {
        private readonly ApplicationDbContext _context;
            public AppHelper(ApplicationDbContext context)
        {
            _context = context;

        }
        public static string FormatVehicle(string make, string name, string variant, string model)
        {
            return $"{make} {name}  {variant} {model}";
        }


    }
}
