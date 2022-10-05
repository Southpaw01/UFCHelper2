using Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorkWithDB;

namespace UFCHelper.ViewModels
{
    public class FightViewModel : BaseViewModel
    {
        private Fight fight = new Fight();
        #region FightProperties
        public string Name
        {
            get { return fight.Name; }
            set
            {
                fight.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Result
        {
            get { return fight.Result; }
            set
            {
                if (value == fight.Result)
                    return;

                fight.Result = value;

                OnPropertyChanged("Result");
            }
        }

        public string Weight
        {
            get
            {
                return fight.Weight;
            }

            set
            {
                if (value == fight.Weight)
                    return;

                fight.Weight = value;

                OnPropertyChanged("Weight");
            }
        }

        public string Tournament
        {
            get
            {
                return fight.Tournament;
            }

            set
            {
                if (value == fight.Tournament)
                    return;

                fight.Tournament = value;

                OnPropertyChanged("Tournament");
            }
        }

        public string Round
        {
            get
            {
                return fight.Round.ToString();
            }

            set
            {
                if (value == fight.Round.ToString())
                    return;

                fight.Round = Convert.ToInt32(value);

                OnPropertyChanged("Round");
            }
        }

        public string Time
        {
            get
            {
                return string.Format("{0:mm\\:ss}", fight.Time);
            }

            set
            {
                if (value == fight.Time.ToString())
                    return;

                fight.Time = TimeSpan.Parse(value);

                OnPropertyChanged("Time");
            }
        }

        public string Type
        {
            get
            {
                return fight.Type;
            }

            set
            {
                if (value == fight.Type)
                    return;

                fight.Tournament = value;

                OnPropertyChanged("Type");
            }
        }

        public string Number
        {
            get
            {
                return fight.Number.ToString();
            }

            set
            {
                if (value == fight.Number.ToString())
                    return;

                fight.Number = Convert.ToInt32(value);

                OnPropertyChanged("Number");
            }
        }

        public string WinnerName
        {
            get
            {
                return fight.WinnerName;
            }

            set
            {
                if (value == fight.WinnerName)
                    return;

                fight.WinnerName = value;

                OnPropertyChanged("WinnerName");
            }
        }

        public List<Round> Rounds1
        {
            get
            {
                return fight.rounds1;
            }
            set
            {
                if (value == fight.rounds1)
                    return;

                fight.rounds1 = value;

                OnPropertyChanged("Rounds1");
            }
        }

        public List<Round> Rounds2
        {
            get
            {
                return fight.rounds2;
            }
            set
            {
                if (value == fight.rounds2)
                    return;

                fight.rounds2= value;

                OnPropertyChanged("Rounds2");
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
                if (value == rounds)
                    return;

                rounds = value;

                OnPropertyChanged("Rounds");
            }
        }

        #endregion FightProperties

        public void FillDataFromDB()
        {
            fight =  ReadingDB.GetInformationAboutFight(Name);

            List<Fighter> fighters = ReadingDB.GetInformationAboutFightersFromFight(Name);

            for (int i = 0; i < fighters.Count; i++)
            {
                string nameFight = fight.Name.Substring(0, fighters[i].Surname.Length);

                if (nameFight == fighters[i].Surname)
                {
                    FirstFighter = new FighterViewModel(fighters[i]);
                }
                else SecondFighter = new FighterViewModel(fighters[i]);
            }

            Rounds1 = ReadingDB.GetStatsByRoundsOfFighter(FirstFighter.Name, FirstFighter.Surname, Name);
            Rounds2 = ReadingDB.GetStatsByRoundsOfFighter(SecondFighter.Name, SecondFighter.Surname, Name);

            Rounds = new List<GeneralRoundDetailViewModel>();
            for (int i = 0; i < Rounds1.Count; i++)
            {
                GeneralRoundDetailViewModel viewModel = new GeneralRoundDetailViewModel(Rounds1[i], Rounds2[i]);

                Rounds.Add(viewModel);
            }
        }

        private FighterViewModel firstFighter = new FighterViewModel();
        public FighterViewModel FirstFighter
        {
            get
            {
                return firstFighter;
            }
            set
            {
                firstFighter = value;
                OnPropertyChanged("FirstFighter");
            }
        }

        private FighterViewModel secondFighter = new FighterViewModel();
        public FighterViewModel SecondFighter
        {
            get
            {
                return secondFighter;
            }
            set
            {
                secondFighter = value;
                OnPropertyChanged("SecondFighter");
            }
        }

        public void UploadDataToDB()
        {
            UpdatingDB.AddFight(fight);
        }
    }
}
