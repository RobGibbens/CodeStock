//CodeStock.Core/ViewModels/ConferencesViewModel.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using CodeStock.Core.Data;
using CodeStock.Core.Models;

namespace CodeStock.Core.ViewModels
{
    public class ConferencesViewModel : MvxViewModel
    {
        private SQLiteClient _sqliteClient;
        private readonly ITekConfService _tekConfService;

        //TODO : Inject sqlite
        public ConferencesViewModel(ITekConfService tekConfService, ISQLitePlatform sqlite)
        {
            
            _tekConfService = tekConfService;
            _sqliteClient = new SQLiteClient(sqlite);
            this.Conferences = new List<Conference>();
        }

        public async void Init()
        {
            await GetConferences();
        }

        public async Task GetConferences()
        {
            var conferences = await _tekConfService.GetConferences().ConfigureAwait(false);
            this.Conferences = conferences;

            //TODO : Save models to database
            await _sqliteClient.SaveAll(conferences).ConfigureAwait(false);
        }

        private List<Conference> _conferences;
        public List<Conference> Conferences
        {
            get
            {
                return _conferences;
            }
            set
            {
                _conferences = value;
                RaisePropertyChanged(() => Conferences);
            }
        }
    }
}