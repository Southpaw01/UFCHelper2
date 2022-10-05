using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UFCHelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataManagementPage : ContentPage
    {
        App app = Application.Current as App;

        public DataManagementPage()
        {
            InitializeComponent();
        }
    }
}