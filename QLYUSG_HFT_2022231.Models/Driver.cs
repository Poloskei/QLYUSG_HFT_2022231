using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QLYUSG_HFT_2022231.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [NotMapped][JsonIgnore]
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
    }
}
