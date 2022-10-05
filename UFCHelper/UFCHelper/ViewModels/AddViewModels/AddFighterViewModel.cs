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
    public class AddFighterViewModel : BaseViewModel
    {

        public Command AddBigPhotoCommand { get; }
        public Command AddSmallPhotoCommand { get; }
        public Command SaveCommand { get; }

        private FighterViewModel fighter = new FighterViewModel();
        public FighterViewModel Fighter
        {
            get
            {
                return fighter;
            }

            set
            {
                fighter = value;

                OnPropertyChanged("Fighter");
            }
        }

        public AddFighterViewModel()
        {
            AddBigPhotoCommand = new Command(() =>
            {
                Fighter.BigPhoto.Uri = new Uri(Fighter.BigPhotoAddress);
                OnPropertyChanged("Fighter");
            });

            AddSmallPhotoCommand = new Command(() =>
            {
                Fighter.SmallPhoto.Uri = new Uri(Fighter.SmallPhotoAddress);
                OnPropertyChanged("Fighter");
            });

            SaveCommand = new Command(() =>
            {
                Fighter.UploadDataToDB();
            });
        }
    }

}
