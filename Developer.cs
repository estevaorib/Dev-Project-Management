using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDesenvolvedoresEProjetos
{
    public class Developer
    {
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(45)]
        public String Name { get; set; }

        public DateTime Birth { get; set; }
        
        public Char Level { get; set; }

        [Required]
        public Credential Credential { get; set; }

        public Developer()
        {

        }

        public Developer(string name, DateTime birth, char level)
        {
            Name = name;
            Birth = birth;
            Level = level;
        }
    }
}
