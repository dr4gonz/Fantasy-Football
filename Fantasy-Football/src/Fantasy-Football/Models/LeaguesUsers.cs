using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football.Models
{
    [Table("LeaguesUsers")]
    public class LeaguesUsers
    {
        [Key]
        public int Id { get; set; }
        public League League { get; set; }
        public ApplicationUser User { get; set; }
        public LeaguesUsers() { }

    }
}
