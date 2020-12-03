using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BookApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand OpenSectionCommand { get; private set; }
    }
}
