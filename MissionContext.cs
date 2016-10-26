using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext()
            : base("MissionContext")
        {

        }

        public DbSet<Missions> Missions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<MissionQuestions> MissionQuestions { get; set; }
    }
}