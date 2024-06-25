using System;
using System.Collections.Generic;

namespace MVPLib.View
{
    public delegate void ViewDelegateLeague(League L, string Name);
    public delegate void ViewDelegateTeam(Team T, string Name);
    public delegate void ViewDelegatePlayer(Player P, string Name);
    public delegate void AddTeamDelegate(League league, Team team);


    public interface IFootballView
    {
        event Action<League> LeagueSelected;
        event Action<Team> TeamSelected;
        event Action<League> AddLeague;
        event Action<Team> AddTeam;
        event Action<Player> AddPlayer;
        event ViewDelegateLeague EditLeague;
        event ViewDelegateTeam EditTeam;
        event ViewDelegatePlayer EditPlayer;
        event ViewDelegateTeam DeleteTeam;
        event ViewDelegatePlayer DeletePlayer;

        void ShowAllLeagues(List<string> leagues);

        League GetSelectedLeague();
        Team GetSelectedTeam();
        void updateLeague(League l);
        void updateTeam(League L);
        void updatePlayer(Team T);
    }
}
