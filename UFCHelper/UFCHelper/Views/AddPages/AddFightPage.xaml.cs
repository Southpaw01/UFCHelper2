using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFCHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UFCHelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFightPage : TabbedPage
    {
        public AddFightPage()
        {
            InitializeComponent();

            TypeFightPicker.SelectedIndex = 0;
            WinnerPicker.SelectedIndex = 0;
        }

    }
}