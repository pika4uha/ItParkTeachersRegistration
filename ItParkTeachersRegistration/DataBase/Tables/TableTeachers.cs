using ItParkTeachersRegistration.DataBase.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItParkTeachersRegistration.DataBase.Tables
{
    internal class TableTeachers
    {
        private NpgsqlConnection _connection;

        public TableTeachers(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public void AddNew(Teachers teachers)
        {
            string sqlRequest = $"INSERT INTO Teachers (name, invite_code) VALUES ('{teachers.Name}', '{teachers.InviteCode}')";

            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

            command.ExecuteNonQuery();
        }

        public Teachers GetTeacher(Teachers teachers)
        {
            string sqlRequest = $"SELECT * FROM links_categories WHERE id={findId}";

            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            dataReader.Read();

            string name = dataReader.GetString(dataReader.GetOrdinal("name"));

            dataReader.Close();

            return teachers;
        }
    }
}
