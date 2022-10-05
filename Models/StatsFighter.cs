using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class StatsFighter
    {
        public int CountFightsInUfc { get; set; } = 0;

        public int Punches { get; set; } = 0;

        public int AllPunches { get; set; } = 0;

        public int AccPunches { get; set; } = 0;

        public int AllAccPunches { get; set; } = 0;

        public int Takedowns { get; set; } = 0;

        public int TryTakedowns { get; set; } = 0;


        public double StatsAccPuncehs
        {
            get 
            {
                if (AllAccPunches > 0)
                {
                    return Math.Round((double)AccPunches / (double)AllAccPunches * 100, 0);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double StatsStruggle
        {
            get 
            {
                if (TryTakedowns > 0)
                {
                    return Math.Round((double)Takedowns / (double)TryTakedowns * 100);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
