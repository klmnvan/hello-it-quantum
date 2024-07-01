using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
    public class LabyrinthViewModel : ReactiveObject
    {
        private List<NameComand> listCommandForRobots = new List<NameComand>();

        public List<NameComand> ListCommandForRobots { get => listCommandForRobots; set => listCommandForRobots = value; }

        public void addRight() {
            ListCommandForRobots.Add(new NameComand { name = "go right" });

        }

        


    }

    public class NameComand {
        public string name { get; set; }

    }

}