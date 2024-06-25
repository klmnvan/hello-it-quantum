using HelloItQuantum.Views;
using System;
using System.IO;
using System.Media;

namespace HelloItQuantum.ViewModels
{
	public class HotkeysViewModel : MainWindowViewModel
    {

        #region
        bool visibleBtnNext = true; //Кнопка Далее
        string textInBtnNext = "Далее"; //Текст внутри кнопки Далее (иногда он может быть Да)
        bool visibleBtnNo = false; //Кнопка Нет
        bool visibleTBAnswer = false; //TB куда вводить ответ
        bool visibleImgAnswer = false; //SP с ответом
        string textInSP = "Изучать программирование - значит уметь выполнять различные действия на компьютере с помощью клавиатуры"; //Текст в StackPanel
        string textAnswer = ""; //Текст в поле ввода ответа
        (int, string, int) act = (1, "", 1); 
        string textShowAct = "1/5";

        public bool VisibleBtnNext { get => visibleBtnNext; set => SetProperty(ref visibleBtnNext, value); }
        public string TextInBtnNext { get => textInBtnNext; set => SetProperty(ref textInBtnNext, value); }
        public bool VisibleBtnNo { get => visibleBtnNo; set => SetProperty(ref visibleBtnNo, value); }
        public bool VisibleTBAnswer { get => visibleTBAnswer; set => SetProperty(ref visibleTBAnswer, value); }
        public bool VisibleImgAnswer { get => visibleImgAnswer; set => SetProperty(ref visibleImgAnswer, value); }
        public string TextInSP { get => textInSP; set => SetProperty(ref textInSP, value); }
        public string TextShowAct { get => textShowAct; set => SetProperty(ref textShowAct, value); }
        public string TextAnswer { get => textAnswer; set => SetProperty(ref textAnswer, value); }
        #endregion

        /// <summary>
        /// Функция запуска аудио
        /// </summary>
        public void PlayTask()
        {
            string directory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))));
            string path = "";
            switch (act.Item1)
            {
                case 1:
                    {
                        path = $"{directory}\\Assets\\HotkeysAudio\\voice1.wav";
                    }; break;
                case 2:
                    {
                        path = $"{directory}\\Assets\\HotkeysAudio\\voice2.wav";
                    }; break;
            }
            SoundPlayer snd = new SoundPlayer(path);
            snd.Play();
        }

        /// <summary>
        /// Парс элемента очереди
        /// </summary>
        public void NextAct()
        {
            TextInSP = act.Item2;
            TextShowAct = "1/5";
            switch (act.Item3)
            {
                case 1:
                    {
                        VisibleTBAnswer = false;
                        VisibleBtnNo = false;
                        VisibleBtnNext = true;
                        TextInBtnNext = "Далее";
                    }; break;
                case 2:
                    {
                        VisibleTBAnswer = false;
                        VisibleBtnNo = true;
                        VisibleBtnNext = true;
                        TextInBtnNext = "Да";
                    }; break;
                case 3:
                    {
                        VisibleTBAnswer = true;
                        VisibleBtnNo = false;
                        VisibleBtnNext = true;
                        TextInBtnNext = "Далее";
                    }; break;
            }
        }

        /// <summary>
        /// Обработка нажатий на кнопку
        /// </summary>
        /// <param name="button">Какая кнопка была нажата</param>
        public void GoNext(string button) 
        {
            switch (act.Item1)
            {
                case 1:
                    {
                        act = (2, "Готов ли ты проверить свои знания в мире горячих клавиш? Не волнуйся, я тебя научу", 2);
                    }; break;
                case 2:
                    {
                        if (button == "Далее")
                        {
                            act = (3, "Отлично. Начнем с простого вопроса. Знаешь ли ты, как с помощью клавиатуры стирать текст?", 2);
                        }
                        else
                        {
                            PageSwitch.View = new PlaySectionView();
                        }
                    }; break;
                case 3:
                    {
                        if (button == "Далее")
                        {
                            act = (4, "Если говоришь, знаешь, введи название клавиши, с помощью которой можно стереть текст", 3);
                        }
                        else
                        {
                            act = (5, "Чтобы стереть текст, который ты написал, необходимо нажать клавишу Backspace. Иногда её изображают стрелочкой влево ? ", 1);
                        }
                    }; break;
                case 4:
                    {
                        if (TextAnswer == "Backspace" || TextAnswer == "?")
                        {
                            act = (6, "Ты молодец. Знаешь ли ты, как с помощью клавиатуры скопировать текст?", 2);
                        }
                        else
                        {
                            TextAnswer = "Неверно";
                        }
                    }; break;
                case 5:
                    {
                        act = (4, "Введи название клавиши, которую ты узнал, с помощью которой можно стереть текст", 3);
                    }; break;
            }
            NextAct();
        }


    }
}