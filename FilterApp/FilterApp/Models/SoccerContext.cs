using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilterApp.Models
{
    public class SoccerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }

    public class SoccerDbInitializer : DropCreateDatabaseAlways<SoccerContext>
    {
        protected override void Seed(SoccerContext db)
        {
            Team t1 = new Team { Name = "Barcelona" };
            Team t2 = new Team { Name = "Real" };
            db.Teams.Add(t1);
            db.Teams.Add(t2);
            db.SaveChanges();
            Player pl1 = new Player { Name = "Ronaldy", Age = 31, Position = "forward", Team = t2 };
            Player pl2 = new Player { Name = "Bale", Age = 25, Position = "forward", Team = t2 };
            Player pl3 = new Player { Name = "Messi", Age = 29, Position = "forward", Team = t1 };
            Player pl4 = new Player { Name = "Neymar", Age = 23, Position = "forward", Team = t1 };
            Player pl5 = new Player { Name = "Пике", Age = 31, Position = "защитник", Team = t2 };
            db.Players.AddRange(new List<Player> { pl1, pl2, pl3, pl4, pl5 });
            db.SaveChanges();
        }
    }
}