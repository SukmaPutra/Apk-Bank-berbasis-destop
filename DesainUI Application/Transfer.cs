using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace DesainUI_Application
{
    public class Transfer
    {
        public string NamaRekeningTujuan { get; set; }
        public string NoRekeningTujuan { get; set; }
        public string NamaBankTujuan { get; set; }  // Ensure that this matches the property name used in fr_transfer
        public string KodeBankTujuan { get; set; }
        public DateTime TanggalWaktuTransfer { get; set; }

        public decimal NominalTransfer { get; set; }
        public decimal BiayaAdmin { get; set; }
        public decimal Total { get; set; }

        public int IdNasabah { get; set; }

        public Nasabah Nasabah { get; set; }

        public decimal NominalTarik { get; set; }
    }
}
