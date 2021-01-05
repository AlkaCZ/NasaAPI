using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UkolPlanety.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace UkolPlanety.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class PageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PageViewModel(ASpaceObject spaceObject)
        {
            Name = spaceObject.Name;
            Size = spaceObject.Size;
            Material = spaceObject.Material;
        }
        string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        double _Size;
        public double Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
            }

        }
        string _Material;

        public string Material
        {
            get { return _Material; }
            set
            {
                _Material = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Material"));
            }
        }
        public ASpaceObject ToSpaceObject()
        {
            ASpaceObject s = new ASpaceObject { Name = this.Name, Material = this.Material, Size = this.Size };
            return s;
        }

    }

    public partial class ASpaceObjectPage : ContentPage
    {
        ObservableCollection<ASpaceObject> oCollection;
        public ASpaceObjectPage()
        {
            InitializeComponent();
        }
        public ASpaceObjectPage(ASpaceObject so, ObservableCollection<ASpaceObject> collection)
        {
            InitializeComponent();
            PageViewModel pageView = new PageViewModel(so);
            BindingContext = pageView;
            oCollection = collection;
        }

        private void Save_Button_Clicked(object sender, EventArgs e)
        {
            oCollection.Add((BindingContext as PageViewModel).ToSpaceObject());
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}