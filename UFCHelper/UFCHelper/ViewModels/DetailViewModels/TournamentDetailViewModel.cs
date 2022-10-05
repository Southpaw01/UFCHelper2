using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UFCHelper.Views;
using WorkWithDB;
using Xamarin.Forms;

namespace UFCHelper.ViewModels
{
    [QueryProperty(nameof(Name), "tournamentName")]
    public class TournamentDetailViewModel : BaseViewModel
    {
        private Tournament tournament;
        #region
        public string Date
        {
            get
            {
                return tournament.Date.ToString("dd.MM.yyyy");
            }

            set
            {
                if (value == tournament.Date.ToString("dd.MM.yyyy"))
                    return;

                tournament.Date = Convert.ToDateTime(value);

                OnPropertyChanged("Date");
            }
        }

        public string Place 
        {
            get
            {
                return tournament.Place;
            }

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
            get
            {
                return tournament.Status;
            }

            set
            {
                if (value == tournament.Status)
                    return;

                tournament.Status = value;

                OnPropertyChanged("Status");
            }
        }

        public string Name
        {
            get { return tournament.Name; }
            set
            {
                tournament.Name = value;
                LoadTournamentPage();
                OnPropertyChanged("Name");
            }
        }
        #endregion

        private List<Fight> fights;
        public List<Fight> Fights
        {
            get { return fights; }
            set
            {
                fights = value;

                OnPropertyChanged("Fights");
            }
        }

        public Command LoadItemsCommand { get; }
        public Command<Fight> ItemTapped { get; }

        public void LoadTournamentPage()
        {
            Title = Name;

            LoadItemsCommand.Execute(true);
        }

        public TournamentDetailViewModel()
        {
            ItemTapped = new Command<Fight>(OnItemSelected);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            tournament = new Tournament();
            fights = new List<Fight>();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                tournament = await ReadingDB.GetInformationAboutTournament(Name);
                fights = await ReadingDB.GetFightsOfTournament(Name);

                OnPropertyChanged("Name");
                OnPropertyChanged("Place");
                OnPropertyChanged("Date");
                OnPropertyChanged("Status");

                OnPropertyChanged("Fights");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Fight _selectedFight;
        public Fight SelectedItem
        {
            get => _selectedFight;
            set
            {
                SetProperty(ref _selectedFight, value);
                OnItemSelected(value);
            }
        }


        async void OnItemSelected(Fight fight)
        {
            if (fight == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FightDetailPage)}?fightName={fight.Name}");
        }
    }
}
