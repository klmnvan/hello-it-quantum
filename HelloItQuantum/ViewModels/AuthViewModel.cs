using System;
using System.Collections.Generic;
using HelloItQuantum.Views;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
	public class AuthViewModel : MainWindowViewModel
    {
        #region
        string nickname = "";
        public string Nickname { get => nickname; set => SetProperty(ref nickname, value); }
        #endregion

        /// <summary>
        /// Метод, обрабатывающий нажатие на кнопку Войти
        /// </summary>
        public void Auth()
        {
            HomeVM = new HomeViewModel();
            PageSwitch.View = new HomeView();
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие на кнопку Нет профиля
        /// </summary>
        public void CreateProfile()
        {
            CreateProfileVM = new CreateProfileViewModel();
            PageSwitch.View = new CreateProfileView();
        }
    }
}