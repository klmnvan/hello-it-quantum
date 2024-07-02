using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ExCSS;


namespace HelloItQuantum.ViewModels
{
    public class LabyrinthViewModel : MainWindowViewModel
    {

        bool isVisibleContextWindow = true;
        string textInSP = "Жил-был робот Ракета. Он хотел помочь профессору на станции, но между ними был лабиринт из оранжевых и красных клеток. Ракета мог идти только по оранжевым, избегая красных. Помоги Ракете добраться до станции профессора.";
        string textInBTN = "Далее";


        StackPanel listCommandForRobots = new StackPanel();
        public StackPanel ListCommandForRobots { get => listCommandForRobots; set => SetProperty(ref listCommandForRobots, value); }
        public bool IsVisibleContextWindow { get => isVisibleContextWindow; set => SetProperty(ref isVisibleContextWindow, value); }
        public string TextInSP { get => textInSP; set => SetProperty(ref textInSP, value); }
        public string TextInBTN { get => textInBTN; set => SetProperty(ref textInBTN, value); }

        List<string> listContent = new List<string>();

        public void GoNext() {
            TextInSP = "Здорово! Ракета оказался на исследовательской станции и помог профессору починить лабораторию. Миссия выполнена!";
            IsVisibleContextWindow = false;
        }
       
        
        public void AddButton(string comand)
        {
			ListCommandForRobots.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
			TextBlock tb = new TextBlock();
            tb.Text = "go " + comand;
			tb.TextAlignment = TextAlignment.Center;
			tb.FontSize = 24;
            tb.Width = 150;
            tb.Margin = new Thickness(10);
			Border border = new Border();
            border.CornerRadius = new CornerRadius(20);
			border.Background = new SolidColorBrush(Avalonia.Media.Color.FromArgb(242, 101, 39, 0));
			border.Child = tb;
			border.Margin = new Thickness(5);
			ListCommandForRobots.Children.Add(border);
            listContent.Add(tb.Text);

        }
        
        public void DeleteCommand() {
            ListCommandForRobots.Children.Clear();
            listContent.Clear();
        }
        public void CheckCommand()
        {
            //ListCommandForRobots.Children.Clear();
            var c = ListCommandForRobots.Children;
            bool googCommands = true;
            if (listContent.Count < 9)
            {
                googCommands = false;
            }
            else { 
                for (int i = 0; i < listContent.Count; i++) {
                    if (listContent[0] != "go right") {
                        googCommands = false; break;
                    }
                    if (listContent[1] != "go right")
                    {
                        googCommands = false; break;
                    }
                    if (listContent[2] != "go up")
                    {
                        googCommands = false; break;
                    }
                    if (listContent[3] != "go up")
                    {
                        googCommands = false; break;
                    }
                    if (listContent[4] != "go left")
                    {
                        googCommands = false; break;
                    }
                    if (listContent[5] != "go up")
                    {
                        googCommands = false; break;
                    }
                    if (listContent[6] != "go up")
                    {
                        googCommands = false; break;
                    }
                    if (listContent[7] != "go right")
                    {
                        googCommands = false; break;
                    }
                    if (listContent[8] != "go right")
                    {
                        googCommands = false; break;
                    }
                }
            }
            if (googCommands)
            {
                TextInSP = "Здорово! Ракета оказался на исследовательской станции и помог профессору починить лабораторию. Миссия выполнена!";
                IsVisibleContextWindow = true;
                TextInBTN = "Закрыть";
            }
            else {
               
                TextInSP = "К сожалению, Ракета заблудился и не добрался до исследовательской станции. Не отчаивайся! Попробуй заново!";
                IsVisibleContextWindow = true;
                TextInBTN = "Закрыть";
            }
        }

    }

    public class NameComand {
        public string name { get; set; }
    }

}