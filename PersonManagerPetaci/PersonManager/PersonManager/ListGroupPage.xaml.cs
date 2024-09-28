using PersonManager.Dal;
using PersonManager.Models;
using PersonManager.ViewModels;
using System;
using System.Collections.Generic;
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
    public partial class ListGroupPage : GroupPage
    {
        public ListGroupPage(GroupViewModel groupViewModel) : base(groupViewModel)
        {
            InitializeComponent();
            lvGroups.ItemsSource = groupViewModel.Groups;
        }

        private void btnViewPeople_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new ListPeoplePage(new PersonViewModel())
            {
                Frame = Frame
            });
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditGroupPage(GroupViewModel)
            {
                Frame = Frame
            });
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvGroups.SelectedItem != null)
            {
                Frame?.Navigate(new EditGroupPage(
                    GroupViewModel,
                    lvGroups.SelectedItem as Group
                    )
                {
                    Frame = Frame
                });
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvGroups.SelectedItem != null)
            {
                Group group = lvGroups.SelectedItem as Group;
                var people = RepositoryFactory.GetRepository().GetPeopleFromGroup(group.IDGroup).ToList();
                foreach (Person person in people)
                {
                    RepositoryFactory.GetRepository().RemovePersonFromGroup(person.IDPerson, group.IDGroup);
                }
                GroupViewModel.Groups.Remove((lvGroups.SelectedItem as Group)!);
            }
        }

        private void lvGroups_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvGroups.SelectedItem != null)
            {
                Group? group = lvGroups.SelectedItem as Group;
                Frame?.Navigate(new EditGroupPage(GroupViewModel, group)
                {
                    Frame = Frame
                });
            }
        }
    }
}
