using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E3201810070111.Models
{
  public  class Pagos
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pago { get; set; }
 
        public string Descripcion { get; set; }
 
        public string Monto { get; set; }
 
        public string Fecha { get; set; }

        public string Photo_recibo { get; set; }


    }
}
