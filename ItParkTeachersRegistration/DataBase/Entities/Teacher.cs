using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItParkTeachersRegistration.DataBase.Entities
{
    internal class Teacher
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public long ChatId { get; set; }
        public string InviteCode { get; set; }

        public Teacher() { }
        public Teacher(string name, string inviteCode)
        {
            Name = name;
            InviteCode = inviteCode;
        }
    }
}
