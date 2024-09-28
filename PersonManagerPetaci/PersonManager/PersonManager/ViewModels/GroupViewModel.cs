using PersonManager.Dal;
using PersonManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PersonManager.ViewModels
{
    public class GroupViewModel
    {
        public ObservableCollection<Group> Groups { get; }
        public GroupViewModel() {
            Groups = new ObservableCollection<Group>(RepositoryFactory.GetRepository().GetGroups());


            Groups.CollectionChanged += Groups_CollectionChanged;
                }

        private void Groups_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddGroup(
                        Groups[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteGroup(
                        e.OldItems!.OfType<Group>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateGroup(
                        e.NewItems!.OfType<Group>().ToList()[0]);
                    break;
            }
        }

        public void UpdateGroup(Group group) => Groups[Groups.IndexOf(group)] = group;
    }
}
