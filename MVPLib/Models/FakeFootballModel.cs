using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPLib.Models
{
    public class FakeFootballModel : IFootballModel
    {
        public event Action DataChangedLeagues;
        public event Action DataChangedTeams;
        public event Action DataChangedPlayers;

        private List<League> leagues = new List<League>();

        public void AddLeague(League leagueName)
        {
            if (!leagues.Any(l => l.Name == leagueName.Name)) // Проверка на дублирование
            {
                leagues.Add(leagueName);
                DataChangedLeagues?.Invoke();
            }
        }

        public void AddPlayer(Team teamName, Player playerName)
        {
            if (!teamName.Players.Any(p => p.Name == playerName.Name)) // Проверка на дублирование
            {
                teamName.AddPlayer(playerName);
                DataChangedPlayers?.Invoke();
            }
        }

        public void AddTeam(League leagueName, Team teamName)
        {
            if (!leagueName.Teams.Any(t => t.Name == teamName.Name)) // Проверка на дублирование
            {
                leagueName.AddTeam(teamName);
                DataChangedTeams?.Invoke();
            }
        }

        public void DeleteTeam(League leagueName, Team teamName)
        {
            if (leagueName != null && teamName != null)
            {
                leagueName.Teams.Remove(teamName);
                DataChangedTeams?.Invoke();
            }
        }

        public void DeletePlayer(Team team, Player player)
        {
            team.Players.Remove(player);
            DataChangedPlayers?.Invoke();
        }


        public void EditLeague(League oldLeagueName, string newLeagueName)
        {
            oldLeagueName.Name = newLeagueName;
            DataChangedLeagues?.Invoke();
        }

        public void EditPlayer(Player oldPlayer, string newPlayerName)
        {
            oldPlayer.Name = newPlayerName;
            DataChangedPlayers?.Invoke();
        }

        public void EditTeam(Team oldTeamName, string newTeamName)
        {
            oldTeamName.Name = newTeamName;
            DataChangedTeams?.Invoke();
        }


        public List<string> GetLeagues()
        {
            List<string> leagueNames = new List<string>();
            foreach (var league in leagues)
            {
                leagueNames.Add(league.Name);
            }
            return leagueNames;
        }

        public List<string> GetTeams(string leagueName)
        {
            var league = leagues.Find(l => l.Name == leagueName);
            if (league != null)
            {
                List<string> teamNames = new List<string>();
                foreach (var team in league.Teams)
                {
                    teamNames.Add(team.Name);
                }
                return teamNames;
            }
            return new List<string>();
        }

        public List<string> GetPlayers(string leagueName, string teamName)
        {
            var league = leagues.Find(l => l.Name == leagueName);
            if (league != null)
            {
                var team = league.Teams.Find(t => t.Name == teamName);
                if (team != null)
                {
                    List<string> playerNames = new List<string>();
                    foreach (var player in team.Players)
                    {
                        playerNames.Add(player.Name);
                    }
                    return playerNames;
                }
            }
            return new List<string>();
        }
        public League GetLeagueByName(string name)
        {
            return leagues.FirstOrDefault(l => l.Name == name);
        }
    }
}
