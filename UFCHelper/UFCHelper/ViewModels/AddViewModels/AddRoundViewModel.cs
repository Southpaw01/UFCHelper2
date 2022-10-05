using Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorkWithDB;

namespace UFCHelper.ViewModels
{
    public class AddRoundViewModel : BaseViewModel
    {
        private Round round;
        #region Round Properties

        public string Number
        {
            get { return round.Number.ToString(); }
            set
            {
                if (value == round.Number.ToString())
                    return;

                round.Number = Convert.ToInt32(value);

                OnPropertyChanged("Number");
                FightView.OnPropertyChanged("Number");
            }
        }

        public string Punches
        {
            get { return round.Punches.ToString(); }
            set
            {
                if (value == round.Punches.ToString())
                    return;

                round.Punches = Convert.ToInt32(value);

                OnPropertyChanged("Punches");
                FightView.OnPropertyChanged("Punches");
            }
        }

        public string AllPunches
        {
            get { return round.AllPunches.ToString(); }
            set
            {
                if (value == round.AllPunches.ToString())
                    return;

                round.AllPunches = Convert.ToInt32(value);

                OnPropertyChanged("AllPunches");
                FightView.OnPropertyChanged("AllPunches");
            }
        }

        public string AccPunches
        {
            get { return round.AccPunches.ToString(); }
            set
            {
                if (value == round.AccPunches.ToString())
                    return;

                round.AccPunches = Convert.ToInt32(value);

                OnPropertyChanged("AccPunches");
                FightView.OnPropertyChanged("AccPunches");
            }
        }

        public string AllAccPunches
        {
            get { return round.AllAccPunches.ToString(); }
            set
            {
                if (value == round.AllAccPunches.ToString())
                    return;

                round.AllAccPunches = Convert.ToInt32(value);

                OnPropertyChanged("AllAccPunches");
                FightView.OnPropertyChanged("AllAccPunches");
            }
        }

        public string TryTakedowns
        {
            get { return round.TryTakedowns.ToString(); }
            set
            {
                if (value == round.TryTakedowns.ToString())
                    return;

                round.TryTakedowns = Convert.ToInt32(value);

                OnPropertyChanged("TryTakedowns");
                FightView.OnPropertyChanged("TryTakedowns");
            }
        }

        public string Takedowns
        {
            get { return round.Takedowns.ToString(); }
            set
            {
                if (value == round.Takedowns.ToString())
                    return;

                round.Takedowns = Convert.ToInt32(value);

                OnPropertyChanged("Takedowns");
                FightView.OnPropertyChanged("Takedowns");
            }
        }

        #endregion

        public AddFightViewModel FightView;
        public AddRoundViewModel(AddFightViewModel fightView)
        {
            round = new Round();

            FightView = fightView;
        }

        public void SaveRound(Fighter fighter, Fight fight)
        {
            UpdatingDB.AddStatsFight(fight, fighter, round);
        }
    }
}
