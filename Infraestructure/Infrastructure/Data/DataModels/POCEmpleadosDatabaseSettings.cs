using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Infrastructure.Data.DataModels
{
    public class POCEmpleadosDatabaseSettings : IPOCEmpleadosDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string RegisterUsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IPOCEmpleadosDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string RegisterUsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
