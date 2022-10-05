using System;
using System.Collections.Generic;
using System.Text;
using Models;
using WorkWithDB;
using Xamarin.Forms;

namespace UFCHelper.ViewModels
{
    [QueryProperty(nameof(AddTournament), "addTournament")]
    public class AddTournamentViewModel : BaseViewModel
    {
        private string AddTournament = "Добавить турнир";

        public Command SaveCommand { get; }

        private Tournament tournament;
        #region Tournament Properties
        public string Name
        {
            get { return tournament.Name; }
            set
            {
                if (value == tournament.Name)
                    return;

                tournament.Name = value;

                OnPropertyChanged("Name");
            }
        }

        public string Date
        {
            get { return tournament.Date.ToString(); }
            set
            {
                if (value == tournament.Date.ToString())
                    return;

                tournament.Date = Convert.ToDateTime(value);

                OnPropertyChanged("Date");
            }
        }

        public string Place
        {
            get { return tournament.Place; }
            set
            {
                if (value == tournament.Place)
                    return;

                tournament.Place = value;

                OnPropertyChanged("Place");
            }
        }

        public string Status
        {
            get { return tournament.Status; }
            set
            {
                if (value == tournament.Status)
                    return;

                tournament.Status = value;

                OnPropertyChanged("Status");
            }
        }

        #endregion

        public AddTournamentViewModel()
        {
            tournament = new Tournament();

            Title = AddTournament;

            SaveCommand = new Command(() => UpdatingDB.AddTournament(tournament));
        }

    }
}
