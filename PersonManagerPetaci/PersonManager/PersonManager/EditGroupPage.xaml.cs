using PersonManager.Dal;
using PersonManager.Models;
using PersonManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonManager
{
    /// <summary>
    /// Interaction logic for EditGroupPage.xaml
    /// </summary>
    public partial class EditGroupPage : GroupPage
    {
        private List<String?> allPeople;
        private List<String?> groupPeople;
        private List<String> addedPeople = new List<string>();
        private List<String> deletedPeople = new List<string>();
        private readonly Group? group;
        public EditGroupPage(GroupViewModel groupViewModel,
            Group? group = null
            )
            : base(groupViewModel)
        {
            InitializeComponent();
            this.group = group ?? new Group();
            DataContext = group;

            LoadPeople();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }



        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeopleInGroup.SelectedItem == null) return;
            var deletedPerson = lvPeopleInGroup.SelectedItem as String;
            if (addedPeople.Contains(deletedPerson)) addedPeople.Remove(deletedPerson);
            else
            {
                groupPeople.Remove(deletedPerson);
                allPeople.Add(deletedPerson);
                if (!deletedPeople.Contains(deletedPerson))
                {
                    deletedPeople.Add(deletedPerson);
                }
            }
            RefreshPeople();
        }
        

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {

                group!.Name = tbName.Text.Trim();

                if (group.IDGroup == 0)
                {
                    GroupViewModel.Groups.Add(group);
                }
                else
                {
                    GroupViewModel.UpdateGroup(group);
                }

                List<Person> groupPeople = GetGroupPeople();
                foreach (string name in deletedPeople)
                {
                    Person deletedPerson = FindPersonByName(groupPeople, name);
                    if (deletedPerson != null)
                    {
                        RepositoryFactory.GetRepository().RemovePersonFromGroup(group.IDGroup, deletedPerson.IDPerson);
                    }
                }

                if (addedPeople.Count > 0)
                {
                    List<Person> people = GetAllPeople();
                    foreach (string? personName in addedPeople)
                    {
                    Person matchingPerson = FindPersonByName(people, personName);
                    RepositoryFactory.GetRepository().AddPersonToGroup(group.IDGroup, matchingPerson.IDPerson);
                    }
                }
                Frame?.NavigationService.GoBack();
            }
        }

        private Person FindPersonByName(List<Person> people, string name)
        {
            return people.Where(p => p.FirstName == name).FirstOrDefault();
        }

        private List<Person> GetAllPeople() {
        return RepositoryFactory.GetRepository().GetPeople().ToList();
        }
        private List<Person> GetGroupPeople() {
        return RepositoryFactory.GetRepository().GetPeopleFromGroup(group.IDGroup).ToList();
        }

        private void LoadPeople()
        {
            groupPeople = GetGroupPeople().Select(p => p.FirstName).ToList();

            lvPeopleInGroup.ItemsSource = new List<string>(groupPeople);

            allPeople = GetAllPeople().Select(p => p.FirstName).Where(p => !groupPeople.Contains(p)).ToList();
            lvAllPeople.ItemsSource = new List<string>(allPeople);
        }
        private void RefreshPeople()
        {
            if (addedPeople != null)
            {
                foreach (String person in addedPeople)
                {
                    if (!groupPeople.Contains(person))
                    {
                        groupPeople.Add(person);
                    }
                }
            }

            lvPeopleInGroup.ItemsSource = new List<string>(groupPeople);

            allPeople.Where(p => !groupPeople.Contains(p)).ToList();
            lvAllPeople.ItemsSource = new List<string>(allPeople);
        }

        private bool FormValid()
        {
            tbName.BorderBrush = Brushes.White;
            bool check = !string.IsNullOrEmpty(tbName.Text.Trim());
            if (!check)
            {
                tbName.BorderBrush = Brushes.Red;
            }
            return check;
        }

        private void lvAllPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvAllPeople.SelectedItem == null) return;
            string addedPersonName = lvAllPeople.SelectedItem as string;
            if (!addedPeople.Contains(addedPersonName))
            {
                addedPeople.Add(addedPersonName);
                allPeople.Remove(addedPersonName);
            }
            if (!deletedPeople.Contains(addedPersonName))
            {
                deletedPeople.Remove(addedPersonName);
            }
            RefreshPeople();
        }

        private void lvPeopleInGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //do nothing
        }
    }
}
