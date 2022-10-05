using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB;
using Xamarin.Forms;

namespace UFCHelper.ViewModels
{
    public class RatingsViewModel : BaseViewModel
    {
        private WeightCategory _selectedRating;

        public List<WeightCategory> Ratings
        {
            get
            {
                return ratings;
            }
            set
            {
                ratings = value;
                OnPropertyChanged("Ratings");
            }
        }

        List<WeightCategory> ratings;

        public Command LoadItemsCommand { get; }
        public Command<WeightCategory> ItemTapped { get; }
        public Image mainImage { get; }

        public RatingsViewModel()
        {
            Title = "Действующий ТОП-15";
            Ratings = new List<WeightCategory>();
         

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<WeightCategory>(OnItemSelected);

            LoadItemsCommand.Execute(true);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Ratings.Clear();
                Ratings = await ReadingDB.GetWeightCategories();
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

        public WeightCategory SelectedItem
        {
            get => _selectedRating;
            set
            {
                SetProperty(ref _selectedRating, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(WeightCategory rating)
        {
            if (rating == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"RatingDetailPage?weightName={rating.Name}");
        }
    }
}
