using nr148081_150251.Samoloty.BL;
using nr148081_150251.Samoloty.Interfaces;
using nr148081_150251.Samoloty.UI.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;


namespace nr148081_150251.Samoloty.UI.ViewModel
{
    class PlaneListViewModel
    {
        public ObservableCollection<PlaneViewModel> Planes { get; set; } = new ObservableCollection<PlaneViewModel>();
        private Logic _logic;

        private ListCollectionView _view;
        public string FilterValue { get; set; }

        private string _errorMessagePlanes;

        public string ErrorMessagePlanes
        {
            get { return _errorMessagePlanes; }
            set
            {
                if (_errorMessagePlanes != value)
                {
                    _errorMessagePlanes = value;
                    RaisePropertyChanged(nameof(ErrorMessagePlanes));
                }
            }
        }

        private PlaneViewModel _selectedPlane;
        public PlaneViewModel SelectedPlane
        {
            get => _selectedPlane;
            set
            {
                _selectedPlane = value;
                RaisePropertyChanged(nameof(SelectedPlane));
            }
        }

        private RelayCommand _filterCommand;
        public RelayCommand FilterCommand
        {
            get => _filterCommand;
        }

        private RelayCommand _newPlaneCommand;
        public RelayCommand NewPlaneCommand
        {
            get => _newPlaneCommand;
        }

        private RelayCommand _savePlaneCommand;
        public RelayCommand SavePlaneCommand
        {
            get => _savePlaneCommand;
        }

        private RelayCommand _deletePlaneCommand;
        public RelayCommand DeletePlaneCommand
        {
            get => _deletePlaneCommand;
        }


        public PlaneListViewModel(Logic logic)
        {
            _logic = logic;
            IEnumerable<IPlane> planes = logic.GetPlanes();
            foreach (var plane in planes)
            {
                Planes.Add(new PlaneViewModel(plane));
            }

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Planes);
            _filterCommand = new RelayCommand(_ => FilterGrid());
            _newPlaneCommand = new RelayCommand(_ => AddPlane());
            _savePlaneCommand = new RelayCommand(_ => SaveChanges());
            _deletePlaneCommand = new RelayCommand(_ => DeletePlane());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddPlane()
        {
            IPlane plane = _logic.NewPlane();
            PlaneViewModel planeViewModel = new PlaneViewModel(plane);
            Planes.Add(planeViewModel);
            ErrorMessagePlanes = "";
        }

        private void SaveChanges()
        {
            if (SelectedPlane == null) return;
            try
            {
                _logic.SavePlane(SelectedPlane.Plane);
                _logic.Commit();
                ErrorMessagePlanes = "";
            }
            catch (Exception ex)
            {
                ErrorMessagePlanes = ex.Message;
            }
        }

        private void DeletePlane()
        {
            if (SelectedPlane == null) return;
            
            try
            {
                _logic.DeletePlane(SelectedPlane.Plane);
                Planes.Remove(SelectedPlane);
                _logic.Commit();
                ErrorMessagePlanes = "";
            }
            catch (Exception ex)
            {
                ErrorMessagePlanes = ex.Message;
            }
            
       
        }

        private void FilterGrid()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (plane) => ((PlaneViewModel)plane).Model.Contains(FilterValue);
            }
            ErrorMessagePlanes = "";
        }

    }
}
