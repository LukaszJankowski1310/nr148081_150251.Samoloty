using nr148081_150251.Samoloty.BL;
using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.UI.ViewModel;
using System.Windows;

namespace nr148081_150251.Samoloty.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            Logic logic = new Logic("nr148081_150251.Samoloty.DAOMock.dll");
          
            InitializeComponent();

            PlanesTab.DataContext = new CompanyListViewModel(logic);

            PlanesTab.DataContext = new PlaneListViewModel(logic);

            CompaniesComboBox.ItemsSource = logic.GetCompanies();
            TypeComboBox.ItemsSource = Enum.GetValues(typeof(PlaneType));

        }
    }
}