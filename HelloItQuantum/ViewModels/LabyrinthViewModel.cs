using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using DynamicData;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
    public class LabyrinthViewModel : MainWindowViewModel
    {
        StackPanel listCommandForRobots = new StackPanel();
        public StackPanel ListCommandForRobots { get => listCommandForRobots; set => SetProperty(ref listCommandForRobots, value); }

        public void AddRight()
        {
            TextBox tb = new TextBox();
            tb.Text = "Прививи";
            ListCommandForRobots.Children.Add(tb);
        }
    }

    public class NameComand {
        public string name { get; set; }
    }

}