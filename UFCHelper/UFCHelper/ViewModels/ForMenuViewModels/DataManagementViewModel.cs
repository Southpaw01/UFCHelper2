using System;
using System.Collections.Generic;
using System.Text;
using UFCHelper.Views;
using Xamarin.Forms;

namespace UFCHelper.ViewModels
{
    public class DataManagementViewModel : BaseViewModel
    {

        public Command AddNewFighterCommand { get; }
        public Command AddTournamentCommand { get; }
        public Command AddFightCommand { get; }

        public DataManagementViewModel()
        {
            AddNewFighterCommand = new Command(async () => await Shell.Current.GoToAsync($"{nameof(AddFighterPage)}?{nameof(AddFighterViewModel)}=Добавление нового бойца"));

            AddTournamentCommand = new Command(async () => await Shell.Current.GoToAsync($"{nameof(AddTournamentPage)}?{nameof(AddTournamentViewModel)}=Добавление турнира"));

            AddFightCommand = new Command(async () => await Shell.Current.GoToAsync($"{nameof(AddFightPage)}?{nameof(AddFightViewModel)}=Добавление боя"));
        }
    }
}
