using System;
using System.Collections.Generic;
using UFCHelper.ViewModels;
using UFCHelper.Views;
using Xamarin.Forms;

namespace UFCHelper
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RatingDetailPage), typeof(RatingDetailPage));
            Routing.RegisterRoute(nameof(AddFighterPage), typeof(AddFighterPage));
            Routing.RegisterRoute(nameof(AddTournamentPage), typeof(AddTournamentPage));
            Routing.RegisterRoute(nameof(AddFightPage), typeof(AddFightPage));
            Routing.RegisterRoute(nameof(UpcomingTournamentsPage), typeof(UpcomingTournamentsPage));
            Routing.RegisterRoute(nameof(FinishedTournamentsPage), typeof(FinishedTournamentsPage));
            Routing.RegisterRoute(nameof(FighterDetailPage), typeof(FighterDetailPage));
            Routing.RegisterRoute(nameof(TournamentDetailPage), typeof(TournamentDetailPage));
            Routing.RegisterRoute(nameof(FightDetailPage), typeof(FightDetailPage));
            Routing.RegisterRoute(nameof(FightersPage), typeof(FightersPage));
        }
    }
}
