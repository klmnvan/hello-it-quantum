using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
	public class LabyrinthViewModel : ReactiveObject
	{
        public ObservableCollection<MyItem> MyItems { get; } = new ObservableCollection<MyItem>();

        public ICommand AddRowCommand { get; }

        public LabyrinthViewModel()
        {
            AddRowCommand = ReactiveCommand.Create(AddRow);
        }

        private void AddRow()
        {
            MyItems.Add(new MyItem { MyProperty = $"Строка {MyItems.Count + 1}" });
        }

    }
    public class MyItem
    {
        public string MyProperty { get; set; }
    }
}