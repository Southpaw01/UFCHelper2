using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models
{
    public class Fighter
    {
        public static string DefaultSmallPhoto = "https://ufc.ru/themes/custom/ufc/assets/img/no-profile-image.png";
        public static string DefaultBigPhoto = "https://dmxg5wxfqgb4u.cloudfront.net/styles/athlete_bio_full_body/s3/image/fighter_images/SHADOW_Fighter_fullLength_RED.png";


        public string Name { get; set; }

        public string Alias { get; set; }

        public string Surname { get; set; }

        public string Country { get; set; }

        public DateTime Debut { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int Draws { get; set; }

        public int NoContests { get; set; }

        public double ArmSpan { get; set; }

        public double LegSpan { get; set; }

        public string NumRating { get; set; }

        public string WeightCategory { get; set; }

        public UriImageSource SmallPhoto { get; set; } = new UriImageSource() { Uri = new Uri(DefaultSmallPhoto) };
        
        public UriImageSource BigPhoto { get; set; } = new UriImageSource() { Uri = new Uri(DefaultBigPhoto) };

         

        public string FullName
        {
            get
            {
                if (Alias != null && Alias != "")
                {
                    return Name + $" \"{Alias}\" " + Surname;
                }
                else
                {
                    return Name + " " + Surname;
                }
            }
        }

        public string Record
        {
            get
            {
                return $"{Wins}-{Loses}-{Draws} ({NoContests})";
            }
        }

    }
}
