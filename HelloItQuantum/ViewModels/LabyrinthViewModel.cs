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

        /*private List<NameComand> listCommandForRobots = new List<NameComand>();

        public List<NameComand> ListCommandForRobots { get => listCommandForRobots; set => listCommandForRobots = value; }

        public void AddRight() {
            ListCommandForRobots.Add(new NameComand { name = "go right" });

        }*/

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