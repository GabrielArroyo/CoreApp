using Infraestructure.Infrastructure.Data.DataModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<Users> _users;

        public UsersService(IPOCEmpleadosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<Users>(settings.UsersCollectionName);
        }

        public List<Users> Get() =>
            _users.Find(users => true).ToList();

        public Users Get(string id) =>
            _users.Find<Users>(users => users.Id == id).FirstOrDefault();

        public Users Create(Users user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, Users userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(Users userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}

