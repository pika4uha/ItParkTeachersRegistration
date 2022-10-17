using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ItParkTeachersRegistration.DataBase.Connection;
using ItParkTeachersRegistration.DataBase.Tables;

namespace ItParkTeachersRegistration.DataBase
{
    internal class DbManager
    {
        public TableTeachers TableTeachers { get; private set; }

        public DbManager()
        {
            NpgsqlConnection connection = DbConnector.GetInstance().Connection;

            TableTeachers = new TableTeachers(connection);
        }

        private static DbManager _dbManager = null;

        public static DbManager GetInstance()
        {
            if (_dbManager == null)
            {
                _dbManager = new DbManager();
            }

            return _dbManager;
        }
    }
}
