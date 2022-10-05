using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using WorkWithDB;
using Xamarin.Forms;

namespace UFCHelper.ViewModels
{
    public class UpcomingTournamentsViewModel : BaseViewModel
    {
        private Tournament _selectedTournament;

        public List<Tournament> Tournaments
        {
            get
            {
                return ratings;
            }
            set
            {
                ratings = value;
                OnPropertyChanged("Tournaments");
            }
        }

        List<Tournament> ratings;

        public Command LoadItemsCommand { get; }
        public Command<Tournament> ItemTapped { get; }
        public Image mainImage { get; }

        public UpcomingTournamentsViewModel()
        {
            Title = "Предстоящие турниры";
            Tournaments = new List<Tournament>();


            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Tournament>(OnItemSelected);

            LoadItemsCommand.Execute(true);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Tournaments.Clear();
                Tournaments = await ReadingDB.GetUpcomingTournaments();
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Tournament SelectedItem
        {
            get => _selectedTournament;
            set
            {
                SetProperty(ref _selectedTournament, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Tournament tournament)
        {
            if (tournament == null)
                return;

            await Shell.Current.GoToAsync($"TournamentDetailPage?tournamentName={tournament.Name}");
        }
    }
}

