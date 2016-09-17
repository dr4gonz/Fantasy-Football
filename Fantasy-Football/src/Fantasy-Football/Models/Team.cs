using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public ApplicationUser User { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public Team() { }


    }
}
