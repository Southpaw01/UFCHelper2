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
    public class FightersViewModel : BaseViewModel
    {
        public Command<Fighter> ItemTapped { get; }
        public Command LoadItemsCommand { get; }

        public List<Fighter> Fighters { get { return fighters; } set { fighters = value; OnPropertyChanged("Fighters"); } }
        private List<Fighter> fighters;

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
            await Shell.Current.GoToAsync($"{nameof(FighterDetailPage)}?fighterName={fighter.Name}&fighterSurname={fighter.Surname}");
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Fighters = await ReadingDB.GetAllFighters();
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

        public FightersViewModel()
        {
            ItemTapped = new Command<Fighter>(OnItemSelected);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            fighters = new List<Fighter>();

            LoadItemsCommand.Execute(true);
        }

    }
}
