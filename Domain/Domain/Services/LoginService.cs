using Infraestructure.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Services
{
    public class LoginService
    {
        private readonly IMongoCollection<RegisterUsers> _Login;

        public LoginService(IPOCEmpleadosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Login = database.GetCollection<RegisterUsers>(settings.RegisterUsersCollectionName);
        }
        public RegisterUsers Get(RegisterUsers user) =>
           _Login.Find<RegisterUsers>(users => (users.Password == Encriptar(user.Password)) && (users.Identificador == user.Identificador)).FirstOrDefault();
        public void Create(RegisterUsers user)
        {
            user.Password = Encriptar(user.Password);
            _Login.InsertOne(user);

        }
        private string Encriptar(string pass)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(pass);
            result = Convert.ToBase64String(encryted);
            return result;
        }

    }
}

