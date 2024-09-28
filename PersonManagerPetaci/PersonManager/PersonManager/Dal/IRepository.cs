using PersonManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    public interface IRepository
    {
        void AddGroup(Group group);
        void AddPerson(Person person);
        void AddPersonToGroup(int groupId, int personId);
        void DeleteGroup(Group group);
        void DeletePerson(Person person);
        IEnumerable<Group> GetGroups();
        IList<Person> GetPeople();
        IList<Person> GetPeopleFromGroup(int groupId);
        Person GetPerson(int idPerson);
        void RemovePersonFromGroup(int groupId, int personId);
        void UpdateGroup(Group group);
        void UpdatePerson(Person person);
    }
}
