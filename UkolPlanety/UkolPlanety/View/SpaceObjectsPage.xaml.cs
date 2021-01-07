using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using UkolPlanety.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using  System.Net.Http;

namespace UkolPlanety.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpaceObjectsPage : ContentPage
    {
        public SpaceObjectsPage()
        {

            InitializeComponent();
            SpaceObjects spaceObjects = new SpaceObjects();
            BindingContext = spaceObjects;
            
        }

        async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Page p = new ASpaceObjectPage(((((ListView)sender).SelectedItem) as Models.ASpaceObject), (BindingContext as SpaceObjects).AllSpaceObjects);
            NavigationPage np = new NavigationPage(p);
            await Application.Current.MainPage.Navigation.PushAsync(np);

            if ((sender as ListView) != null)
                (sender as ListView).SelectedItem = null;

        }

        async void InfoButt_Clicked(object sender, EventArgs e)
        {

                //Page p = new ASpaceObjectPage() as Models.ASpaceObject), (BindingContext as SpaceObjects).AllSpaceObjects);
                //NavigationPage np = new NavigationPage(p);
                //await Application.Current.MainPage.Navigation.PushAsync(np);
            

        }
    }
}
