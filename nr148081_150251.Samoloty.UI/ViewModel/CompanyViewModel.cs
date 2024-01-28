
using nr148081_150251.Samoloty.Interfaces;
using System.ComponentModel;

namespace nr148081_150251.Samoloty.UI.ViewModel
{
    internal class CompanyViewModel : INotifyPropertyChanged
    {
        public ICompany Company;
        public event PropertyChangedEventHandler PropertyChanged;

        public CompanyViewModel(ICompany company)
        {
            Company = company;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Id
        {
            get => Company.Id;
            set
            {
                Company.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => Company.Name;
            set
            {
                Company.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public int Year
        {
            get => Company.Year;
            set
            {
                Company.Year = value;
                RaisePropertyChanged(nameof(Year));
            }
        }

        public string Description
        {
            get => Company.Description;
            set
            {
                Company.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

    }
}
