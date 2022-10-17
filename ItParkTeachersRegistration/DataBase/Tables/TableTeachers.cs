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

        public bool AddNew(Teacher teacher)
        {
            if (!CheckInviteCodeUnique(teacher))
            {
                return false;
            }

            string sqlRequest = $"INSERT INTO Teachers (name, invite_code) VALUES ('{teacher.Name}', '{teacher.InviteCode}')";

            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

            command.ExecuteNonQuery();

            return true;
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            string sqlRequest = $"SELECT name, invite_code FROM teachers"; // $"SELECT * FROM teachers WHERE id={findId}" 

            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string name = dataReader.GetString(dataReader.GetOrdinal("name"));
                string code = dataReader.GetString(dataReader.GetOrdinal("invite_code"));

                teachers.Add(new Teacher(name, code));
            }

            dataReader.Close();

            return teachers;
        }

        private bool CheckInviteCodeUnique(Teacher teacher)
        {
            string sqlRequest = $"SELECT invite_code FROM teachers";

            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string code = dataReader.GetString(dataReader.GetOrdinal("invite_code"));

                if (teacher.InviteCode == code)
                {
                    dataReader.Close();

                    return false;
                }
            }

            dataReader.Close();

            return true;
        }
    }
}
