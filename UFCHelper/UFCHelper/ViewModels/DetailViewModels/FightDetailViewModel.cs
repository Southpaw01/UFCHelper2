using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB;
using Xamarin.Forms;

namespace UFCHelper.ViewModels
{
    [QueryProperty(nameof(Name), "fightName")]
    public class FightDetailViewModel : BaseViewModel
    {
        public string Name
        {
            get { return fight.Name; }
            set
            {
                fight.Name = value;
                if (fight.Name != null)
                {
                    LoadItemsCommand.Execute(true);
                }
                OnPropertyChanged("Fight");
            }
        }

        private FightViewModel fight = new FightViewModel();
        public FightViewModel Fight
        {
            get
            {
                return fight;
            }

            set
            {
                fight = value;

                OnPropertyChanged("Fighter");
            }
        }

        private List<GeneralRoundDetailViewModel> rounds = new List<GeneralRoundDetailViewModel>();
        public List<GeneralRoundDetailViewModel> Rounds
        {
            get
            {
                return rounds;
            }
            set
            {
                rounds = value;
                OnPropertyChanged("Rounds");
            }
        }

        private StatsFighter sumStats1;
        public StatsFighter SumStats1
        {
            get
            {
                return sumStats1;
            }
            set
            {
                sumStats1 = value;
                OnPropertyChanged("SumStats1");
            }
        }


        private StatsFighter sumStats2;
        public StatsFighter SumStats2
        {
            get
            {
                return sumStats2;
            }
            set
            {
                sumStats2 = value;
                OnPropertyChanged("SumStats2");
            }
        }

        private bool isWinner1;
        public bool IsWinner1
        {
            get
            {
                return isWinner1;
            }
            set
            {
                isWinner1 = value;
                OnPropertyChanged("IsWinner1");
            }
        }


        private bool isWinner2;
        public bool IsWinner2
        {
            get
            {
                return isWinner2;
            }
            set
            {
                isWinner2 = value;
                OnPropertyChanged("IsWinner2");
            }
        }


        public FightDetailViewModel()
        {

            sumStats1 = new StatsFighter();
            sumStats2 = new StatsFighter();
            rounds = new List<GeneralRoundDetailViewModel>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        public Command LoadItemsCommand { get; }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Fight.FillDataFromDB();

                OnPropertyChanged("Fight");


                sumStats1 = await StatsDB.SumPunchesAndTakedownsInOneFight(Fight.FirstFighter.Name, Fight.FirstFighter.Surname, Name);
                sumStats2 = await StatsDB.SumPunchesAndTakedownsInOneFight(Fight.SecondFighter.Name, Fight.SecondFighter.Surname, Name);

                if (Fight.WinnerName == Fight.FirstFighter.Name + " " + Fight.FirstFighter.Surname)
                {
                    IsWinner1 = true;
                    IsWinner2 = false;
                }
                else
                if (Fight.WinnerName == Fight.SecondFighter.Name + " " + Fight.SecondFighter.Surname)
                {
                    IsWinner1 = false;
                    IsWinner2 = true;
                }

                OnPropertyChanged("SumStats1");
                OnPropertyChanged("SumStats2");
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
