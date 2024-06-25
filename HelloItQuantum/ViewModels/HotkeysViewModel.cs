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
        string textInSP = ""; //Текст в StackPanel
        string textAnswer = ""; //Текст в поле ввода ответа
        (int, string, int) act = (1, "", 1); 
        string textShowAct = "1/5";

        string path = $"{Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))))}\\Assets\\HotkeysAudio\\voice1.wav";

        public bool VisibleBtnNext { get => visibleBtnNext; set => SetProperty(ref visibleBtnNext, value); }
        public string TextInBtnNext { get => textInBtnNext; set => SetProperty(ref textInBtnNext, value); }
        public bool VisibleBtnNo { get => visibleBtnNo; set => SetProperty(ref visibleBtnNo, value); }
        public bool VisibleTBAnswer { get => visibleTBAnswer; set => SetProperty(ref visibleTBAnswer, value); }
        public bool VisibleImgAnswer { get => visibleImgAnswer; set => SetProperty(ref visibleImgAnswer, value); }
        public string TextInSP { get => textInSP; set => SetProperty(ref textInSP, value); }
        public string TextShowAct { get => textShowAct; set => SetProperty(ref textShowAct, value); }
        public string TextAnswer { get => textAnswer; set => SetProperty(ref textAnswer, value); }
        #endregion

        public HotkeysViewModel()
        {
            act = act = (1, "Изучать программирование - значит уметь выполнять различные действия на компьютере с помощью клавиатуры", 1);
            ParsAct();
        }

        /// <summary>
        /// Функция запуска аудио
        /// </summary>
        public void PlayTask()
        {
            SoundPlayer snd = new SoundPlayer(path);
            snd.Play();
        }

        /// <summary>
        /// Парс элемента очереди
        /// </summary>
        public void ParsAct()
        {
            TextAnswer = "";
            TextInSP = act.Item2;
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
            string directory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))));
            switch (act.Item1)
            {
                case 1:
                    {
                        act = (2, "Готов ли ты проверить свои знания в мире горячих клавиш? Не волнуйся, я тебя научу", 2);
                        path = $"{directory}\\Assets\\HotkeysAudio\\voice1.wav";
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
                            act = (5, "Чтобы стереть текст, который ты написал, необходимо нажать клавишу Backspace. Иногда её изображают стрелочкой влево.", 1);
                        }
                    }; break;
                case 4:
                    {
                        if (TextAnswer == "Backspace" || TextAnswer == "←")
                        {
                            act = (6, "Ты молодец. Знаешь ли ты, как с помощью клавиатуры скопировать текст?", 2);
                            TextShowAct = "2/5";
                        }
                        else
                        {
                            SoundPlayer snd = new SoundPlayer($"{directory}\\Assets\\HotkeysAudio\\error.wav");
                            snd.Play();
                        }
                    }; break;
                case 5:
                    {
                        act = (4, "Введи название клавиши, которую ты узнал, с помощью которой можно стереть текст", 3);
                    }; break;
                case 6:
                    {
                        if (button == "Далее")
                        {
                            act = (8, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно скопировать текст", 3);
                        }
                        else
                        {
                            act = (7, "Чтобы с помощью клавиатуры скопировать текст, необходимо использовать сочетание клавиш Ctrl + C.", 1);
                        }
                    }; break;
                case 7:
                    {
                        act = (8, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно скопировать текст", 3);
                    }; break;
                case 8:
                    {
                        if (TextAnswer == "Ctrl + C")
                        {
                            act = (9, "Отлично справляешься. Знаешь ли ты, как с помощью клавиатуры вставить скопированный текст?", 2);
                            TextShowAct = "3/5";
                        }
                        else
                        {
                            SoundPlayer snd = new SoundPlayer($"{directory}\\Assets\\HotkeysAudio\\error.wav");
                            snd.Play();
                        }
                    }; break;
                case 9:
                    {
                        if (button == "Далее")
                        {
                            act = (11, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно вставить скопированный текст", 3);
                        }
                        else
                        {
                            act = (10, "Чтобы с помощью клавиатуры вставить скопированный текст, необходимо использовать сочетание клавиш Ctrl + V. ", 1);
                        }
                    }; break;
                case 10:
                    {
                        act = (11, "Введи сочетание клавиш, с помощью которых можно вставить скопированный текст", 3);
                    }; break;
                case 11:
                    {
                        if (TextAnswer == "Ctrl + V")
                        {
                            act = (12, "Почти конец! Знаешь ли ты, как стереть символ спереди курсора?", 2);
                            TextShowAct = "4/5";
                        }
                        else
                        {
                            SoundPlayer snd = new SoundPlayer($"{directory}\\Assets\\HotkeysAudio\\error.wav");
                            snd.Play();
                        }
                    }; break;
                case 12:
                    {
                        if (button == "Далее")
                        {
                            act = (14, "Если говоришь, знаешь, введи клавишу, с помощью которой можно стереть текст спереди курсора", 3);
                        }
                        else
                        {
                            act = (13, "Курсор - мерцающая линия, которая дает знать, в каком месте сейчас будет изменяться текст. Чтобы стереть символ спереди курсора. Необходимо нажать клавишу Del.", 1);
                        }
                    }; break;
                case 13:
                    {
                        act = (14, "Введи клавишу, с помощью которой можно стереть текст спереди курсора", 3);
                    }; break;
                case 14:
                    {
                        if (TextAnswer == "Del")
                        {
                            act = (15, "И мой последний вопрос. Знаешь ли ты, как закрыть приложение, в котором ты сейчас находишься, с помощью клавиш?", 2);
                            TextShowAct = "5/5";
                        }
                        else
                        {
                            SoundPlayer snd = new SoundPlayer($"{directory}\\Assets\\HotkeysAudio\\error.wav");
                            snd.Play();
                        }
                    }; break;
                case 15:
                    {
                        if (button == "Далее")
                        {
                            act = (17, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно закрыть приложение, в котором ты сейчас находишься", 3);
                        }
                        else
                        {
                            act = (16, "Чтобы закрыть приложение, в котором ты сейчас находишься, с помощью клавиш, необходимо нажать клавиши Alt + F4.", 1);
                        }
                    }; break;
                case 16:
                    {
                        act = (17, "Введи сочетание клавиш, с помощью которых можно закрыть приложение, в котором ты сейчас находишься", 3);
                    }; break;
                case 17:
                    {
                        if (TextAnswer == "Alt + F4")
                        {
                            act = (18, "Ты молодец и знаешь все базовые горячие клавиши для того, чтобы изучать программирование. Надеюсь это поможет тебе выбрать направление. Пока-пока!", 1);
                        }
                        else
                        {
                            SoundPlayer snd = new SoundPlayer($"{directory}\\Assets\\HotkeysAudio\\error.wav");
                            snd.Play();
                        }
                    }; break;
                case 18:
                    {
                        path = $"{directory}\\Assets\\HotkeysAudio\\audio1.wav";
                        SoundPlayer snd = new SoundPlayer($"{directory}\\Assets\\HotkeysAudio\\audio1.wav");
                        snd.Play();
                        PageSwitch.View = new PlaySectionView();
                    }; break;

            }
            ParsAct();
        }

    }
}