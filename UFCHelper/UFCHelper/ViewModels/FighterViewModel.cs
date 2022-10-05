using Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorkWithDB;
using Xamarin.Forms;

namespace UFCHelper.ViewModels
{
    public class FighterViewModel : BaseViewModel
    {
        private Fighter fighter = new Fighter();
        #region Fighter Properties

        #region MainProperties
        public string Name
        {
            get { return fighter.Name; }
            set
            {
                if (value == fighter.Name)
                    return;

                fighter.Name = value;

                OnPropertyChanged("Name");
            }
        }


        public string Surname
        {
            get { return fighter.Surname; }
            set
            {
                if (value == fighter.Surname)
                    return;

                fighter.Surname = value;

                OnPropertyChanged("Surname");
            }
        }

        public string Alias
        {
            get { return fighter.Alias; }
            set
            {
                if (value == fighter.Alias)
                    return;

                fighter.Alias = value;

                OnPropertyChanged("Alias");
            }
        }

        public string Country
        {
            get { return fighter.Country; }
            set
            {
                if (value == fighter.Country)
                    return;

                fighter.Country = value;

                OnPropertyChanged("Country");
            }
        }

        private string debut;
        public string Debut
        {
            get
            {
                return debut;
            }

            set
            {
                if (value == fighter.Debut.ToString())
                    return;

                debut = value;

                try
                {
                        string[] r = value.Split('.');
                        fighter.Debut = new DateTime(Convert.ToInt32(r[2]), Convert.ToInt32(r[1]), Convert.ToInt32(r[0]));
                }
                catch
                {

                }

                OnPropertyChanged("Debut");
            }
        }

        public string WeightCategory
        {
            get { return fighter.WeightCategory; }
            set
            {
                if (value == fighter.WeightCategory)
                    return;

                fighter.WeightCategory = value;

                OnPropertyChanged("WeightCategory");
            }
        }

        private string bigPhotoAddress;
        public string BigPhotoAddress
        {
            get { return bigPhotoAddress; }
            set
            {
                if (value == bigPhotoAddress)
                    return;
                if (value == null || value == "")
                {
                    bigPhotoAddress = Models.Fighter.DefaultBigPhoto;
                    return;
                }
                if (!IsUri(value))
                    return;

                bigPhotoAddress = value;
            }
        }

        public UriImageSource BigPhoto
        {
            get { return fighter.BigPhoto; }
            set
            {
                fighter.BigPhoto = value;
                OnPropertyChanged("BigPhoto");
            }
        }

        private string smallPhotoAddress;
        public string SmallPhotoAddress
        {
            get { return smallPhotoAddress; }
            set
            {
                if (value == smallPhotoAddress)
                    return;
                if (value == null || value == "")
                {
                    smallPhotoAddress = Models.Fighter.DefaultSmallPhoto;
                    return;
                }
                if (!IsUri(value))
                    return;

                smallPhotoAddress = value;
            }
        }


        public UriImageSource SmallPhoto
        {
            get { return fighter.SmallPhoto; }
            set
            {
                fighter.SmallPhoto = value;
                OnPropertyChanged("SmallPhoto");
            }
        }
        #endregion

        #region Record Properties

        private string wins;
        public string Wins
        {
            get { return wins; }
            set
            {
                if (value == fighter.Wins.ToString())
                    return;

                wins = value;
                fighter.Wins = Convert.ToInt32(value);

                OnPropertyChanged("Wins");
            }
        }

        private string loses;
        public string Loses
        {
            get { return loses; }
            set
            {
                if (value == fighter.Loses.ToString())
                    return;

                loses = value;
                fighter.Loses = Convert.ToInt32(value);

                OnPropertyChanged("Loses");
            }
        }

        private string draws;
        public string Draws
        {
            get { return draws; }
            set
            {
                if (value == fighter.Draws.ToString())
                    return;

                draws = value;
                fighter.Draws = Convert.ToInt32(value);

                OnPropertyChanged("Draws");
            }
        }

        private string noContests;
        public string NoContests
        {
            get { return noContests; }
            set
            {
                if (value == fighter.NoContests.ToString())
                    return;

                noContests = value;
                fighter.NoContests = Convert.ToInt32(value);

                OnPropertyChanged("NoContests");
            }
        }
        #endregion

        #region Anthropometry Properties

        public string Gender
        {
            get { return fighter.Gender; }
            set
            {
                if (value == fighter.Gender)
                    return;

                fighter.Gender = value;

                OnPropertyChanged("Gender");
            }
        }

        private string age;
        public string Age
        {
            get { return age; }
            set
            {
                if (value == fighter.Age.ToString())
                    return;

                age = value;
                fighter.Age = Convert.ToInt32(value);

                OnPropertyChanged("Age");
            }
        }

        private string height;
        public string Height
        {
            get { return height; }
            set
            {
                if (value == fighter.Height.ToString())
                    return;

                height = value;
                fighter.Height = Convert.ToDouble(value);

                OnPropertyChanged("Height");
            }
        }

        private string weight;
        public string Weight
        {
            get { return weight; }
            set
            {
                if (value == fighter.Weight.ToString())
                    return;

                weight = value;
                fighter.Weight = Convert.ToDouble(value);

                OnPropertyChanged("Weight");
            }
        }

        private string armSpan;
        public string ArmSpan
        {
            get { return armSpan; }
            set
            {
                if (value == fighter.ArmSpan.ToString() || value == "")
                    return;

                armSpan = value;
                fighter.ArmSpan = Convert.ToDouble(value);

                OnPropertyChanged("ArmSpan");
            }
        }

        private string legSpan;
        public string LegSpan
        {
            get { return legSpan; }
            set
            {
                if (value == fighter.LegSpan.ToString())
                    return;

                legSpan = value;
                fighter.LegSpan = Convert.ToDouble(value);

                OnPropertyChanged("LegSpan");
            }
        }


        public string NumRating
        {
            get { return fighter.NumRating; }
            set
            {
                if (value == fighter.NumRating)
                    return;

                fighter.NumRating = value;

                OnPropertyChanged("NumRating");
            }
        }

        public string FullName
        {
            get { return fighter.FullName; }
        }
        #endregion


        #endregion

        bool IsUri(string source)
        {
            if (!string.IsNullOrEmpty(source) && Uri.IsWellFormedUriString(source, UriKind.Absolute))
            {
                Uri tempValue;
                return (Uri.TryCreate(source, UriKind.Absolute, out tempValue));
            }
            return (false);
        }

        public async void FillDataFromDB()
        {
            fighter = await ReadingDB.GetAllDataAboutFighter(fighter.Name, fighter.Surname);
            wins = fighter.Wins.ToString();
            loses = fighter.Loses.ToString();
            draws = fighter.Draws.ToString();
            noContests = fighter.NoContests.ToString();
            armSpan = fighter.ArmSpan.ToString();
            legSpan = fighter.LegSpan.ToString();
            weight = fighter.Weight.ToString();
            height = fighter.Height.ToString();
            debut = fighter.Debut.ToString("dd.MM.yyyy");
            age = fighter.Age.ToString();
        }

        public void UploadDataToDB()
        {
            UpdatingDB.AddAllDataAboutFighter(fighter);
        }

        public FighterViewModel(Fighter fighter)
        {
            this.fighter = fighter;
        }

        public FighterViewModel()
        {

        }
    }
}
