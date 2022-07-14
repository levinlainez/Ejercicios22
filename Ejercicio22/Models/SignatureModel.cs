using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio22.Models
{
    public class SignatureModel
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }
        [MaxLength(100)]
        public string nombre { get; set; }
        [MaxLength(100)]
        public string descripcion { get; set; }
        public String Singnature { get; set; }
    }
}
