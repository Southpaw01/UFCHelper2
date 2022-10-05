using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models
{
    public partial class Fight
    {
        public static int UsualCountRounds = 3;
        public static int TitleCountRounds = 5;


        public string WinnerName { get; set; }

        public string Result { get; set; }

        public string Name { get; set; } = "Боец 1 vs Боец 2";

        public string Weight { get; set; }

        public string Tournament { get; set; }

        public int Round { get; set; }

        public TimeSpan Time { get; set; }

        public string Type { get; set; }

        public string Note { get; set; }

        public int Number { get; set; }

        public List<Round> rounds1 { get; set; } = new List<Round>();
        public List<Round> rounds2 { get; set; } = new List<Round>();
    }
}
