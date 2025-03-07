﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Models
{
    public class Race
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        [NotMapped][JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }
        [NotMapped]
        public virtual ICollection<Position> Positions { get; set; }
        public Race()
        {
            Teams = new HashSet<Team>();
        }
    }
}
