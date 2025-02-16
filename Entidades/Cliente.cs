using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppGMAO.Entidades
{
    [Table("tbMaestroCliente")]
    public class Cliente
    {
        [Key]
        public string IDCliente { get; set; }
        public string DescCliente { get; set; }
        public string ? Direccion { get; set; }
        public string ? Poblacion { get; set; }
        public string ? Provincia { get; set; }
        public string ? Email { get; set; }

        public string NombreCompleto => $"{IDCliente} {DescCliente}";
    }
}
