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
            Speed = spaceObject.Speed;
            IsHazerdious = spaceObject.IsHazerdious;
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
        bool _IsHazerdious;

        public bool IsHazerdious
        {
            get { return _IsHazerdious; }
            set
            {
                _IsHazerdious = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsHazerdious"));
            }
        }
        double _Speed;

        public double Speed
        {
            get { return _Speed; }
            set
            {
                _Speed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Speed"));
            }
        }
        public ASpaceObject ToSpaceObject()
        {
            ASpaceObject s = new ASpaceObject { Name = this.Name, Size = this.Size, Speed = this.Speed, IsHazerdious = this.IsHazerdious};
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