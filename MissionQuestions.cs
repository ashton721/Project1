
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int missionQuestionID { get; set; }
        public String missQuestion { get; set; }
        public String missAnswer { get; set; }
        [ForeignKey("Missions")]
        public virtual int missionID { get; set; }
        public virtual Missions Missions { get; set; }
        [ForeignKey("Users")]
        public virtual int userID { get; set; }
        public virtual Users Users { get; set; }

    }
}
