using PersonManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PersonManager
{
    public class GroupPage : Page
    {
        public GroupPage(GroupViewModel groupViewModel)
        {
            GroupViewModel = groupViewModel;
        }
        public GroupViewModel? GroupViewModel { get; }

        public Frame? Frame { get; set; }
    }
}
