using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContactDTO
    {
        public int id { get; set; }
        public string accountNumber { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string contactNo { get; set; }
        public bool isMale { get; set; }
        public decimal balance { get; set; }

    }
}
