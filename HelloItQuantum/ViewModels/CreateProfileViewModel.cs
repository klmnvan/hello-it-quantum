using System;
using System.Collections.Generic;
using HelloItQuantum.Views;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
	public class CreateProfileViewModel : MainWindowViewModel
	{
        #region
        string nickname = "";
        string name = "";
        string surname = "";
        public string Nickname { get => nickname; set => SetProperty(ref nickname, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Surname { get => surname; set => SetProperty(ref surname, value); }
        #endregion

        /// <summary>
        /// Метод, обрабатывающий нажатие на кнопку Создать профиль
        /// </summary>
        public void CreateProfile()
        {
            AuthVM = new AuthViewModel();
            PageSwitch.View = new AuthView();
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие на кнопку Есть профиль
        /// </summary>
        public void Auth()
        {
            AuthVM = new AuthViewModel();
            PageSwitch.View = new AuthView();
        }
    }
}