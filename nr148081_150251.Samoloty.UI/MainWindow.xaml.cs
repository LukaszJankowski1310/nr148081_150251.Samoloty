using nr148081_150251.Samoloty.BL;
using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace nr148081_150251.Samoloty.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic _logic;
        CompanyListViewModel _companyListViewModel;
        PlaneListViewModel _planeListViewModel;

        public MainWindow()
        {

            _logic = new Logic("nr148081_150251.Samoloty.DAOSql.dll");
            if (_logic == null) throw new Exception("Nie znaleziono bibliteki");

            _companyListViewModel = new CompanyListViewModel(_logic);
            _planeListViewModel = new PlaneListViewModel(_logic);

            InitializeComponent();
            InitViews();

        }

        private void InitViews()
        {
            if (_logic != null)
            {
                CompaniesTab.DataContext = _companyListViewModel;
                PlanesTab.DataContext = _planeListViewModel;
                CompaniesComboBox.ItemsSource = _logic.GetCompanies().ToList();
                TypeComboBox.ItemsSource = Enum.GetValues(typeof(PlaneType));
            }          
        }

    }
}