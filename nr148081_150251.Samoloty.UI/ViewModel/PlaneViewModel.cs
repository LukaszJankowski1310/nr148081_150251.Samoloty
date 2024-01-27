using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.Interfaces;
using System.ComponentModel;

namespace nr148081_150251.Samoloty.UI.ViewModel
{
    internal class PlaneViewModel : INotifyPropertyChanged
    {
        public IPlane Plane { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public PlaneViewModel(IPlane plane) 
        {
            Plane = plane;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
       

        public int Id
        {
            get => Plane.Id;
            set
            {
                Plane.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public string Model
        {
            get => Plane.Model;
            set
            {
                Plane.Model = value;
                RaisePropertyChanged(nameof(Model));
            }
        }
        public decimal MaximumSpeed
        {
            get => Plane.MaximumSpeed;
            set
            {
                Plane.MaximumSpeed = value;
                RaisePropertyChanged(nameof(MaximumSpeed));
            }
        }

        public PlaneType Type
        {
            get => Plane.Type;
            set
            {
                Plane.Type = value;
                RaisePropertyChanged(nameof(Type));
            }
        }

        public ICompany Company
        {
            get => Plane.Company;
            set
            {
                Plane.Company = value;
                RaisePropertyChanged(nameof(Company));
            }
        }


    
    }
}
