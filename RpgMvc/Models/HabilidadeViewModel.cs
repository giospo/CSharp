using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgMvc.Models.Enuns;

namespace RpgMvc.Models
{
    public class HabilidadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Dano { get; set; }
    }
}