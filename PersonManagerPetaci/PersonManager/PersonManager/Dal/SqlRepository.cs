using PersonManager.Models;
using PersonManager.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PersonManager.Dal
{
    internal class SqlRepository : IRepository
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public void AddPerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture
                });
            var id = new SqlParameter(nameof(Person.IDPerson), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            person.IDPerson = (int)id.Value;
        }

        public void DeletePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            cmd.ExecuteNonQuery();

        }

        public IList<Person> GetPeople()
        {
            IList<Person> list = new List<Person>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadPerson(dr));
            }

            return list;
        }

        private Person ReadPerson(SqlDataReader dr) => new Person
        {
            IDPerson = (int)dr[nameof(Person.IDPerson)],
            FirstName = dr[nameof(Person.FirstName)].ToString(),
            LastName = dr[nameof(Person.LastName)].ToString(),
            Age = (int)dr[nameof(Person.Age)],
            Email = dr[nameof(Person.Email)].ToString(),
            Picture = ImageUtils.ByteArrayFromReader(dr, nameof(Person.Picture))
        };

        public Person GetPerson(int idPerson)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), idPerson);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadPerson(dr);
            }
            throw new ArgumentException("Wrong id, no such person");

        }

        public void UpdatePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture
                });

            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            cmd.ExecuteNonQuery();

        }

        public void AddGroup(Group group)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Group.Name), group.Name);
            var id = new SqlParameter(nameof(Group.IDGroup), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            group.IDGroup = (int)id.Value;
        }

        public void UpdateGroup(Group group)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Group.Name), group.Name);
            cmd.Parameters.AddWithValue(nameof(Group.IDGroup), group.IDGroup);
            cmd.ExecuteNonQuery();
        }

        public void DeleteGroup(Group group)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Group.IDGroup), group.IDGroup);
            cmd.ExecuteNonQuery();

        }

        public Group GetGroup(int idGroup)
        {
            Group group = new Group();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Group.IDGroup), idGroup);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                group = ReadGroup(dr);
            }
            return group;
        }

        public IEnumerable<Group> GetGroups()
        {
            IList<Group> list = new List<Group>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadGroup(dr));
            }

            return list;
        }

        private Group ReadGroup(SqlDataReader dr) => new Group
        {
            IDGroup = (int)dr[nameof(Group.IDGroup)],
            Name = dr[nameof(Group.Name)].ToString()
        };

        public void AddPersonToGroup(int groupId, int personId)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(GroupPerson.PersonID), personId);
            cmd.Parameters.AddWithValue(nameof(GroupPerson.GroupID), groupId);
            cmd.ExecuteNonQuery();
        }

        public void RemovePersonFromGroup(int groupId, int personId)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(GroupPerson.PersonID), personId);
            cmd.Parameters.AddWithValue(nameof(GroupPerson.GroupID), groupId);
            cmd.ExecuteNonQuery();
        }

        public IList<Person> GetPeopleFromGroup(int groupId)
        {
            List<Person> people = new List<Person>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(GroupPerson.GroupID), groupId);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                people.Add(ReadPerson(dr));
            }

            return people;
        }
    }
}
