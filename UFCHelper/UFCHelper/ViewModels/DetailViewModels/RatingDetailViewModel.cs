using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using Models;
using System.Drawing;
using Xamarin.Forms;
using UFCHelper.Views;
using System.Web;
using WorkWithDB;
using System.Threading.Tasks;

namespace UFCHelper.ViewModels
{
    [QueryProperty(nameof(WeightName), "weightName")]
    public class RatingDetailViewModel : BaseViewModel
    {
        public Command<Fighter> ItemTapped { get; }
        public Command LoadItemsCommand { get; }

        public List<Fighter> Fighters { get { return fighters; } set { fighters = value; OnPropertyChanged("Fighters"); } }
        private List<Fighter> fighters;

        private string weightName;
        public string WeightName
        {
            get { return weightName; }
            set
            {
                weightName = value;
                LoadFighterPage();
                OnPropertyChanged("Fighters");
            }
        }

        public void LoadFighterPage()
        {
            Title = "ТОП-15: " + WeightName;

            LoadItemsCommand.Execute(true);
        }

        private Fighter _selectedFighter;
        public Fighter SelectedItem
        {
            get => _selectedFighter;
            set
            {
                SetProperty(ref _selectedFighter, value);
                OnItemSelected(value);
            }
        }


        async void OnItemSelected(Fighter fighter)
        {
            if (fighter == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FighterDetailPage)}?fighterName={fighter.Name}&" +
                $"fighterSurname={fighter.Surname}");
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Fighters = await ReadingDB.GetRating(weightName);
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

        public RatingDetailViewModel()
        {
            ItemTapped = new Command<Fighter>(OnItemSelected);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            fighters = new List<Fighter>();
        }

    }
}
