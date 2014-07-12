//CodeStock.Core/ViewModels/ConferenceViewModel.cs
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using CodeStock.Core.Data;
using CodeStock.Core.Models;

namespace CodeStock.Core.ViewModels
{
    //TODO : Create conference view model to display sessions
    public class ConferenceViewModel : MvxViewModel
    {
        private SQLiteClient _sqliteClient;
        private Conference _conference;
        private List<Session> _sessions; 
        
        public ConferenceViewModel(ISQLitePlatform sqlite)
        {
            _sqliteClient = new SQLiteClient(sqlite);
        }
        public async void Init(string slug)
        {
            _conference = await _sqliteClient.GetConference(slug).ConfigureAwait(false);
            this.Sessions = _conference.Sessions;
        }
        
        public List<Session> Sessions
        {
            get
            {
                return _sessions;
            }
            set
            {
                _sessions = value;
                RaisePropertyChanged(() => Sessions);
            }
        }
    }
}
