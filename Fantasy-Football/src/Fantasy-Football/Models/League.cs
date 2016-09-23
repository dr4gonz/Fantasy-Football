using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football.Models
{
    [Table("Leagues")]
    public class League
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<LeaguesUsers> LeaguesUsers { get; set; }
        public League() { }
    }
}
