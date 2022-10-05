using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UFCHelper.ViewModels
{
    public class GeneralRoundDetailViewModel : BaseViewModel
    {
        public string Number
        {
            get
            {
                return "Раунд " + RoundsSecondFighter.Number;
            }
            set { }
        }


        public string GeneralPunches
        {
            get
            {
                return $"{RoundsSecondFighter.Punches}-{RoundsFirstFighter.Punches}";
            }
            set { }
        }

        public string GeneralAllPunches
        {
            get
            {
                return $"{RoundsSecondFighter.AllPunches}-{RoundsFirstFighter.AllPunches}";
            }
            set { }
        }

        public string GeneralAccPunches
        {
            get
            {
                return $"{RoundsSecondFighter.AccPunches}-{RoundsFirstFighter.AccPunches}";
            }
            set { }
        }

        public string GeneralAllAccPunches
        {
            get
            {
                return $"{RoundsSecondFighter.AllAccPunches}-{RoundsFirstFighter.AllAccPunches}";
            }
            set { }
        }

        public string GeneralTakedowns
        {
            get
            {
                return $"{RoundsSecondFighter.Takedowns}-{RoundsFirstFighter.Takedowns}";
            }
            set { }
        }

        public string GeneralTryTakedowns
        {
            get
            {
                return $"{RoundsSecondFighter.TryTakedowns}-{RoundsFirstFighter.TryTakedowns}";
            }
            set
            {

            }
        }


        private Round RoundsSecondFighter;
        private Round RoundsFirstFighter;
        public GeneralRoundDetailViewModel(Round round1, Round round2 )
        {
            RoundsSecondFighter = round2;
            RoundsFirstFighter = round1;
        }
    }
}
