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
    public class AddFightViewModel : BaseViewModel
    {
        private Fight fight;
        #region Fight Properties


        public string Result
        {
            get { return fight.Result; }
            set
            {
                if (value == fight.Result)
                    return;

                fight.Result = value;


                OnPropertyChanged("Result");
                OnPropertyChanged("IsThereResult");

            }
        }

        public string Name
        {
            get { return fight.Name; }
            set
            {
                if (value == fight.Name)
                    return;

                fight.Name = value;

                OnPropertyChanged("Name");
            }
        }

        public string WinnerName
        {
            get { return fight.WinnerName; }
            set
            {
                if (value == fight.WinnerName)
                    return;

                fight.WinnerName = value;

                OnPropertyChanged("WinnerName");
            }
        }

        public string Weight
        {
            get { return fight.Weight.ToString(); }
            set
            {
                if (value == fight.Weight.ToString())
                    return;

                fight.Weight = Convert.ToString(value);

                OnPropertyChanged("Weight");
            }
        }

        public string Tournament
        {
            get { return fight.Tournament; }
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
            get { return fight.Round.ToString(); }
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
            get { return fight.Time.ToString(); }
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
            get { return fight.Type; }
            set
            {
                if (value == fight.Type)
                    return;

                fight.Type = value;

                if (value == "Обычный" && Rounds1.Count != Fight.UsualCountRounds)
                {
                    for (int i = Fight.TitleCountRounds; i > Fight.UsualCountRounds; i--)
                    {
                        Rounds1.RemoveAt(i - 1);
                        Rounds2.RemoveAt(i - 1);
                    }
                }
                else if (value == "Титульный" && Rounds1.Count != Fight.TitleCountRounds)
                {
                    for (int i = Fight.UsualCountRounds; i < Fight.TitleCountRounds; i++)
                    {
                        Rounds1.Add(new AddRoundViewModel(this) { Number = (i + 1).ToString() });
                        Rounds2.Add(new AddRoundViewModel(this) { Number = (i + 1).ToString() });
                    }
                }

                OnPropertyChanged("Type");
            }
        }

        public string Note
        {
            get { return fight.Note; }
            set
            {
                if (value == fight.Note)
                    return;

                fight.Note = value;

                OnPropertyChanged("Note");
            }
        }

        public string Number
        {
            get { return fight.Number.ToString(); }
            set
            {
                if (value == fight.Number.ToString())
                    return;

                fight.Number = Convert.ToInt32(value);

                OnPropertyChanged("Number");
            }
        }

        #endregion

        private Fighter firstFighter;
        #region FirstFighter Properties

        public string NameFirstFighter
        {
            get { return firstFighter.Name; }
            set
            {
                if (value == firstFighter.Name)
                    return;

                firstFighter.Name = value;

                if (NameFirstFighter != null && SurnameFirstFighter != null)
                {
                    Task.Run(async () => await TryAddPhotoFirstFighter());
                }
                else firstFighter.SmallPhoto = new UriImageSource() { Uri = new Uri(Fighter.DefaultSmallPhoto) };

                OnPropertyChanged("IsNotEmptyNames");
                OnPropertyChanged("NameFirstFighter");
                OnPropertyChanged("Winners");
            }
        }

        public string SurnameFirstFighter
        {
            get { return firstFighter.Surname; }
            set
            {
                if (value == firstFighter.Surname)
                    return;

                firstFighter.Surname = value;

                if (NameFirstFighter != null && SurnameFirstFighter != null)
                {
                    Task.Run(async () => await TryAddPhotoFirstFighter());
                }
                else firstFighter.SmallPhoto = new UriImageSource() { Uri = new Uri(Fighter.DefaultSmallPhoto) };

                Task.Run(async () => await ChangeName());

                OnPropertyChanged("IsNotEmptyNames");
                OnPropertyChanged("SurnameFirstFighter");
                OnPropertyChanged("Winners");
            }
        }

        public UriImageSource ImageFirstFighter
        {
            get { return firstFighter.SmallPhoto; }
            set
            {
                if (value == firstFighter.SmallPhoto)
                    return;

                firstFighter.SmallPhoto = value;

                OnPropertyChanged("ImageFirstFighter");
            }
        }

        #endregion

        private Fighter secondFighter;
        #region SecondFighter Properties
        public string NameSecondFighter
        {
            get { return secondFighter.Name; }
            set
            {
                if (value == secondFighter.Name)
                    return;

                secondFighter.Name = value;

                if (NameSecondFighter != null && SurnameSecondFighter != null)
                {
                    Task.Run(async () => await TryAddPhotoSecondFighter());
                }
                else secondFighter.SmallPhoto = new UriImageSource() { Uri = new Uri(Fighter.DefaultSmallPhoto) };

                OnPropertyChanged("IsNotEmptyNames");
                OnPropertyChanged("NameSecondFighter");
                OnPropertyChanged("Winners");
            }
        }

        public string SurnameSecondFighter
        {
            get { return secondFighter.Surname; }
            set
            {
                if (value == secondFighter.Surname)
                    return;

                secondFighter.Surname = value;

                if (NameSecondFighter != null && SurnameSecondFighter != null)
                {
                    Task.Run(async () => await TryAddPhotoSecondFighter());
                }
                else secondFighter.SmallPhoto = new UriImageSource() { Uri = new Uri(Fighter.DefaultSmallPhoto) };

                Task.Run(async () => await ChangeName());

                OnPropertyChanged("IsNotEmptyNames");
                OnPropertyChanged("SurnameSecondFighter");
                OnPropertyChanged("Winners");
            }
        }

        public UriImageSource ImageSecondFighter
        {
            get { return secondFighter.SmallPhoto; }
            set
            {
                if (value == secondFighter.SmallPhoto)
                    return;

                secondFighter.SmallPhoto = value;

                OnPropertyChanged("ImageSecondFighter");
            }
        }
        #endregion


        public ObservableCollection<AddRoundViewModel> Rounds1 { get; private set; }
        public ObservableCollection<AddRoundViewModel> Rounds2 { get; private set; }

        public AddFightViewModel()
        { 
            Task.Run(async () => PossibleResults = await ReadingDB.GetPossibleResults());

            fight = new Fight();
            firstFighter = new Fighter();
            secondFighter = new Fighter();

            Rounds1 = new ObservableCollection<AddRoundViewModel>();
            Rounds2 = new ObservableCollection<AddRoundViewModel>();

            for (int i = 0; i < Fight.UsualCountRounds; i++)
            {
                Rounds1.Add(new AddRoundViewModel(this) { Number = (i + 1).ToString() });
                Rounds2.Add(new AddRoundViewModel(this) { Number = (i + 1).ToString() });
            }

            SaveCommand = new Command(SaveFight);
        }


        public Command SaveCommand { get; }

        void SaveFight()
        {
            UpdatingDB.AddFight(fight);

            for (int i = 0; i < Rounds1.Count; i++)
            {
                Rounds1[i].SaveRound(firstFighter, fight);
                Rounds2[i].SaveRound(secondFighter, fight);
            }
        }

        public ObservableCollection<string> Winners
        {
            get
            {
                return new ObservableCollection<string>
                {
                    "Нет победителя",
                    NameFirstFighter + " " + SurnameFirstFighter,
                    NameSecondFighter + " " + SurnameSecondFighter
                };
            }
        }

        bool IsUri(string source)
        {
            if (!string.IsNullOrEmpty(source) && Uri.IsWellFormedUriString(source, UriKind.Absolute))
            {
                Uri tempValue;
                return (Uri.TryCreate(source, UriKind.Absolute, out tempValue));
            }
            return (false);
        }

        async Task TryAddPhotoFirstFighter()
        {
            string newUri = await ReadingDB.GetSmallImageOfFighter(firstFighter);

            if (IsUri(newUri))
            {
                ImageFirstFighter = new UriImageSource() { Uri = new Uri(newUri) };
            }
            else firstFighter.SmallPhoto = new UriImageSource() { Uri = new Uri(Fighter.DefaultSmallPhoto) };
        }

        async Task TryAddPhotoSecondFighter()
        {
            string newUri = await ReadingDB.GetSmallImageOfFighter(secondFighter);

            if (IsUri(newUri))
            {
                ImageSecondFighter = new UriImageSource() { Uri = new Uri(newUri) };
            }
            else secondFighter.SmallPhoto = new UriImageSource() { Uri = new Uri(Fighter.DefaultSmallPhoto) };
        }

        async Task ChangeName()
        {
            Name = $"{SurnameFirstFighter} vs {SurnameSecondFighter}";

            int num = await StatsDB.CountOfFightByNameFight(Name);
            num += await StatsDB.CountOfFightByNameFight($"{SurnameSecondFighter} vs {SurnameFirstFighter}"); 

            if (num > 0)
            {
                Name += $" {num + 1}";
            }
        }

        public bool IsNotEmptyNames
        {
            get
            {
                if (NameFirstFighter != null && SurnameFirstFighter != null
                    && NameSecondFighter != null && SurnameSecondFighter != null)
                {
                    return true;
                }

                return false;
            }
        }

        private ObservableCollection<string> possibleResults;
        public ObservableCollection<string> PossibleResults
        {
            get
            {
                return possibleResults;
            }
            set
            {
                possibleResults = value;

                OnPropertyChanged("PossibleResults");
            }
        }
    }
}
