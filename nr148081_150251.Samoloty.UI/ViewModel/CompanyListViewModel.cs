using nr148081_150251.Samoloty.BL;
using nr148081_150251.Samoloty.Interfaces;
using nr148081_150251.Samoloty.UI.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace nr148081_150251.Samoloty.UI.ViewModel
{
    internal class CompanyListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CompanyViewModel> Companies { get; set; } = new ObservableCollection<CompanyViewModel>();
        private Logic _logic;

        private ListCollectionView _view;
        public string FilterValue {  get; set; }

        private CompanyViewModel _selectedCompany;
        public CompanyViewModel SelectedCompany
        {
            get => _selectedCompany;
            set
            {
                _selectedCompany = value;
                //EditedCompany = value;
                RaisePropertyChanged(nameof(SelectedCompany));
            }
        }

        //private CompanyViewModel _editedCompany;
        //public CompanyViewModel EditedCompany
        //{
        //    get => _editedCompany;
        //    set
        //    {
        //        _editedCompany = value;
        //        RaisePropertyChanged(nameof(EditedCompany));
        //    }
        //}

        public CompanyListViewModel(Logic logic)
        {   
            _logic = logic;
            IEnumerable<ICompany> companies = logic.GetCompanies();
            foreach (var copmany in companies) 
            {
                Companies.Add(new CompanyViewModel(copmany));
            }

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Companies);
            _filterCommand = new RelayCommand(_ => FilterGrid());
            _newCompanyCommand = new RelayCommand(_ => AddCompany());
            _saveCompanyCommand = new RelayCommand(_ => SaveChanges());
            _deleteCompanyCommand = new RelayCommand(_ => DeleteCompany());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddCompany()
        {
            ICompany company = _logic.NewCompany();
            CompanyViewModel companyViewModel = new CompanyViewModel(company);
            Companies.Add(companyViewModel);
            SelectedCompany = companyViewModel;
        }

        private void SaveChanges()
        {
            _logic.SaveCompany(SelectedCompany.Company);
        }

        private void DeleteCompany()
        {
            _logic.DeleteCompany(SelectedCompany.Company);
            Companies.Remove(SelectedCompany);
        }

        private void FilterGrid()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (company) => ((CompanyViewModel)company).Name.Contains(FilterValue);
            }
        }

        private RelayCommand _filterCommand;
        public RelayCommand FilterCommand
        {
            get => _filterCommand;
        }

        private RelayCommand _newCompanyCommand;
        public RelayCommand NewCompanyCommand
        {
            get => _newCompanyCommand;
        }

        private RelayCommand _saveCompanyCommand;
        public RelayCommand SaveCompanyCommand
        {
            get => _saveCompanyCommand;
        }

        private RelayCommand _deleteCompanyCommand;
        public RelayCommand DeleteCompanyCommand
        {
            get => _deleteCompanyCommand;
        }
        
    }
}
