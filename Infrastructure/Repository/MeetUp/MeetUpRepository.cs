using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PlayTogether.Core.Domains;

namespace PlayTogether.Infrastructure.Repository.MeetUp
{
    public class MeetUpRepository : IMeetupRepository,  IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public MeetUpRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(Meet meetUp)
        {
            await Meets.InsertOneAsync(meetUp);
        }

        public async Task<IEnumerable<Meet>> BrowseAsync()
            => await  Meets.AsQueryable().ToListAsync();

        public async Task DeleteAsync(Guid Id)
        {
            await Meets.DeleteOneAsync(x => x.Id == Id);
        }

        public async Task UpdateAsync(Meet meetup)
        {
            await Meets.ReplaceOneAsync(x => x.Id == meetup.Id, meetup);
        }

        public async Task<Meet> GetMeetById(Guid meetupId)

            => await Meets.AsQueryable().FirstOrDefaultAsync(x => x.Id == meetupId);

        public async Task<IEnumerable<Meet>> GetUserMeetUp(string email)
        {
            throw new NotImplementedException();
        }

        private IMongoCollection<Meet> Meets => _database.GetCollection<Meet>("Meet");
    }
}
