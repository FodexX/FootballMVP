using MVPLib.Models;
using MVPLib.View;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MVPLib.Presenters
{
    public class FootballPresenter
    {
        private readonly IFootballView views_;
        private readonly IFootballModel model_;

        public FootballPresenter(IFootballView view, IFootballModel model)
        {
            views_ = view;
            model_ = model;
            Initialize();

            UpdateFootballInfo();
        }

        public void Initialize()
        {
            views_.AddLeague += Views_AddLeague;
            views_.AddTeam += Views_AddTeam;
            views_.AddPlayer += Views_AddPlayer;
            views_.LeagueSelected += Views_LeagueSelected;
            views_.TeamSelected += Views_TeamSelected;
            views_.EditLeague += Views_EditLeague;
            views_.EditTeam += Views_EditTeam;
            views_.EditPlayer += Views_EditPlayer;
            views_.DeleteTeam += Views_DeleteTeam;
            views_.DeletePlayer += Views_DeletePlayer;
        }
        public IFootballModel GetModel()
        {
            return model_;
        }

        private void Views_DeletePlayer(Player player, string Name)
        {
            model_.DeletePlayer(views_.GetSelectedTeam(), player);
        }

        private void Views_DeleteTeam(Team team, string newName)
        {
            model_.DeleteTeam(views_.GetSelectedLeague(), team);
        }

        private void Views_EditLeague(League obj, string newNameLeague)
        {
            model_.EditLeague(obj, newNameLeague);
        }

        private void Views_EditTeam(Team obj, string newNameTeam)
        {
            model_.EditTeam(obj, newNameTeam);
        }

        private void Views_EditPlayer(Player oldPlayer, string newName)
        {
            model_.EditPlayer(oldPlayer, newName);
            UpdateFootballInfo();
        }


        private void Views_TeamSelected(Team obj)
        {
            views_.updatePlayer(obj);
        }

        private void Views_LeagueSelected(League obj)
        {
            views_.updateTeam(obj);
            Team selectedTeam = views_.GetSelectedTeam();
            if (selectedTeam != null)
            {
                views_.updatePlayer(selectedTeam);
            }
        }

        private void Views_AddPlayer(Player obj)
        {
            model_.AddPlayer(views_.GetSelectedTeam(), obj);
        }

        private void Views_AddTeam(Team obj)
        {
            model_.AddTeam(views_.GetSelectedLeague(), obj);
        }

        private void Views_AddLeague(League obj)
        {
            model_.AddLeague(obj);
        }

        private void UpdateFootballInfo()
        {
            if (views_ != null)
            {
                List<string> leagues = model_.GetLeagues();
                views_.ShowAllLeagues(leagues);
            }
        }
    }
}