using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPLib.Models
{
    public interface IFootballModel
    {
        event Action DataChangedLeagues;
        event Action DataChangedTeams;
        event Action DataChangedPlayers;
        League GetLeagueByName(string name);

        List<string> GetLeagues();
        List<string> GetTeams(string leagueName);
        List<string> GetPlayers(string leagueName, string teamName);
        void AddLeague(League leagueName);
        void AddTeam(League leagueName, Team teamName);
        void AddPlayer(Team teamName, Player playerName);
        void EditLeague(League oldLeagueName, string newLeagueName);
        void EditTeam(Team oldTeamName, string newTeamName);
        void EditPlayer(Player oldPlayerName, string newPlayerName);
        void DeleteTeam(League leagueName, Team teamName);
        void DeletePlayer(Team teamName, Player playerName);
    }
}
