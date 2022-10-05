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
    [QueryProperty(nameof(FighterName), "fighterName")]
    [QueryProperty(nameof(FighterSurname), "fighterSurname")]
    public class FighterDetailViewModel : BaseViewModel
    {

        public string FighterName
        {
            get { return fighter.Name; }
            set
            {
                fighter.Name = value;
                if (fighter.Name != null && fighter.Surname != null)
                {
                    LoadInformatonAbotFighter();
                }

                OnPropertyChanged("Fighter");
            }
        }

        public string FighterSurname
        {
            get { return fighter.Surname; }
            set
            {
                fighter.Surname = value;
                if (fighter.Name != null && fighter.Surname != null)
                {
                    LoadInformatonAbotFighter();
                }
                OnPropertyChanged("Fighter");
            }
        }

        private FighterViewModel fighter = new FighterViewModel();
        public FighterViewModel Fighter
        {
            get
            {
                return fighter;
            }

            set
            {
                fighter = value;

                OnPropertyChanged("Fighter");
            }
        }

        private StatsFighter statsFighter;
        public StatsFighter StatsFighter
        {
            get { return statsFighter; }
            set
            {
                statsFighter = value;
                OnPropertyChanged("StatsFighter");
            }
        }

        public Command ItemTapped { get; }
        public Command LoadItemsCommand { get; }

        private List<Fight> fights;
        public List<Fight> Fights { get { return fights; } set { fights = value; OnPropertyChanged("Fights"); } }


        public FighterDetailViewModel()
        {
            ItemTapped = new Command<Fight>(OnItemSelected);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            statsFighter = new StatsFighter();
            fights = new List<Fight>();
        }

        public void LoadInformatonAbotFighter()
        {
            Title = $"{fighter.Name} {fighter.Surname}";

            LoadItemsCommand.Execute(true);
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

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Fighter.FillDataFromDB();
                Fights = await ReadingDB.GetFightsOfFighter(fighter.Name, fighter.Surname);

                StatsFighter = await StatsDB.GetSumOfPunchesAndTakedownsForAllTime(fighter.Name, fighter.Surname);
                statsFighter.CountFightsInUfc = await StatsDB.CountOfFightsInUFC(fighter.Name, fighter.Surname);

                OnPropertyChanged("Fighter");
                OnPropertyChanged("StatsFighter");
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

    }
}

