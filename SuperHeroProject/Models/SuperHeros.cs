using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroProject.Models
{
    public class SuperHeros
    {
        [Key]
        public int SuperHeroID { get; set; }
        public int Name{ get; set; }
        public int AlterEgo { get; set; }
        public int PrimaryPower { get; set; }
        public int SecondaryPower { get; set; }
        public int Catchphrase { get; set; }
    }
}