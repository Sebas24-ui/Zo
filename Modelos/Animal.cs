using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Animal
    {
        [Key] public int Id { get; set; }
        public string NombreAnimal { get; set; }

        public int Edad { get; set; }
        public string Genero { get; set; }
        public int EspecieId { get; set; }
        public int RazaId { get; set; }

        public Especie? Especie { get; set; }
        public Raza? Raza { get; set; }
    }
}
