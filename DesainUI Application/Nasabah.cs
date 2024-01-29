using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace DesainUI_Application
{
    public class Nasabah
    {
        public int NIK { get; set; }
        public string nama { get; set; }

        public string tempatLahir { get; set; }

        public int tgllahir { get; set; }
        public string jeniskelamin { get; set; }

        public string alamat { get; set; }

        public int noHP { get; set; }

        public int norekening { get; set; }

        public string email { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public int pinATM { get; set; }
        public decimal saldo { get; set; }
    }
}
