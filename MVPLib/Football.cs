using MVPLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPLib
{
    public class League
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; }

        public League(string name)
        {
            Name = name;
            Teams = new List<Team>();
        }

        public void AddTeam(Team teamName)
        {
            Teams.Add(teamName);
        }
        public Team GetTeamByName(string name)
        {
            return Teams.FirstOrDefault(t => t.Name == name);
        }

    }

    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public void AddPlayer(Player playerName)
        {
            Players.Add(playerName);
        }
    }

    public class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
