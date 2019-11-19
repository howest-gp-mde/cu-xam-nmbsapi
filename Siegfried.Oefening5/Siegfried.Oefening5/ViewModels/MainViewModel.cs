using FreshMvvm;
using Siegfried.Oefening5.Domain;
using Siegfried.Oefening5.Domain.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Siegfried.Oefening5.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        private NmbsService nmbsService;

        public MainViewModel()
        {
            nmbsService = new NmbsService();
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            await RefreshStations();
        }

        public ICommand ShowDeparturesCommand => new Command<Station>(
            (Station selectedStation) =>
            {
                CoreMethods.PushPageModel<DeparturesViewModel>(selectedStation, false, true);
            });

        private ObservableCollection<Station> stations;

        public ObservableCollection<Station> Stations
        {
            get { return stations; }
            set { 
                stations = value;
                RaisePropertyChanged();
            }
        }


        private async Task RefreshStations()
        {
            var stationList = await nmbsService.GetStations();
            stationList = stationList.Where(e => e.Name.StartsWith("G"));
            Stations = new ObservableCollection<Station>(stationList);
        }
    }
}
