//CodeStock.Core/Data/SQLiteClient.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeStock.Core.Models;
using SQLite.Net.Async;

namespace CodeStock.Core.Data
{
    //TODO : Create client to isolate access to database
    public class SQLiteClient
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private readonly SQLiteAsyncConnection _connection;

        public SQLiteClient(ISQLitePlatform sqlite)
        {
            _connection = sqlite.GetConnection();
            CreateDatabaseAsync();
        }

        public async Task CreateDatabaseAsync()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _connection.CreateTableAsync<Conference>().ConfigureAwait(false);
                await _connection.CreateTableAsync<Session>().ConfigureAwait(false);
            }
        }

        public async Task<List<Conference>> GetConferencesAsync()
        {
            List<Conference> conferences;
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                conferences = await _connection.Table<Conference>().ToListAsync().ConfigureAwait(false);
            }

            return conferences;
        }

        public async Task<Conference> GetConference(string slug)
        {
            Conference conference;
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                conference = await _connection.Table<Conference>().Where(x => x.Slug == slug).FirstOrDefaultAsync().ConfigureAwait(false);
                var sessions = await _connection.Table<Session>().Where(x => x.ConferenceSlug == conference.Slug).ToListAsync();

                conference.Sessions = sessions ?? new List<Session>();
            }

            return conference;
        }

        public async Task SaveAll(IEnumerable<Conference> conferences)
        {
            foreach (var conference in conferences)
            {
                await Save(conference);
            }
        }

        public async Task Save(Conference conference)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                // Because our conference model is being mapped from the dto,
                // we need to check the database by name, not id
                var existingConference = await _connection.Table<Conference>()
                        .Where(x => x.Slug == conference.Slug)
                        .FirstOrDefaultAsync();

                if (existingConference == null)
                {
                    await _connection.InsertAsync(conference).ConfigureAwait(false);
                }
                else
                {
                    conference.Id = existingConference.Id;
                    await _connection.UpdateAsync(conference).ConfigureAwait(false);
                }

                if (conference.Sessions != null && conference.Sessions.Any())
                {
                    await SaveAllSessions(conference.Slug, conference.Sessions);
                }
            }
        }

        private async Task SaveAllSessions(string conferenceSlug, IEnumerable<Session> sessions)
        {
            foreach (var session in sessions)
            {
                await SaveSession(conferenceSlug, session);
            }
        }

        public async Task SaveSession(string conferenceSlug, Session session)
        {
            // Because our conference model is being mapped from the dto,
            // we need to check the database by name, not id
            var existingSession = await _connection.Table<Session>()
                    .Where(x => x.Slug == session.Slug)
                    .Where(x => x.ConferenceSlug == conferenceSlug)
                    .FirstOrDefaultAsync();

            if (existingSession == null)
            {
                session.ConferenceSlug = conferenceSlug;
                await _connection.InsertAsync(session).ConfigureAwait(false);
            }
            else
            {
                session.Id = existingSession.Id;
                session.ConferenceSlug = conferenceSlug;
                await _connection.UpdateAsync(session).ConfigureAwait(false);
            }
        }
    }
}