using FreshMvvm;
using Siegfried.Oefening5.Domain;
using Siegfried.Oefening5.Domain.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Siegfried.Oefening5.ViewModels
{
    public class DeparturesViewModel : FreshBasePageModel
    {
        private NmbsService nmbsService;

        public DeparturesViewModel()
        {
            nmbsService = new NmbsService();
        }

        public async override void Init(object initData)
        {
            try
            {
                Station station = initData as Station;
                DateTime start = DateTime.Now.AddMinutes(-20);

                var departures = await nmbsService.GetDepartures(station, start);
                Departures = new ObservableCollection<Departure>(departures);
            }
            catch(Exception ex)
            {
                await CoreMethods.DisplayAlert("Boem petat", ex.Message, "Ok");
            }
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            
        }

        private IEnumerable<Departure> departures;

        public IEnumerable<Departure> Departures
        {
            get { return departures; }
            set { 
                departures = value;
                RaisePropertyChanged();
            }
        }

    }
}
