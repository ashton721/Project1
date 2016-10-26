
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    [Table("Missions")]
    public class Missions
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int missionID { get; set; }
        public String missionName { get; set; }
        public String missionPresName { get; set; }
        public String missionLanguage { get; set; }
        public String missionClimate { get; set; }
        public String missionReligion { get; set; }
        public String missionImg { get; set; }
       
    }
}
    