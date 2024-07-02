using System;
using System.Collections.Generic;
using System.Linq;
using HelloItQuantum.Function;
using HelloItQuantum.Models;
using HelloItQuantum.Views;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
	public class AuthViewModel : MainWindowViewModel
    {
        #region
        string nickname = "";

        List<string>? userNicknames = new List<string>();
        public string Nickname { get => nickname; set => SetProperty(ref nickname, value); }
        #endregion

        /// <summary>
        /// Метод, обрабатывающий нажатие на кнопку Войти
        /// </summary>
        public void Auth()
        {
            List<User>? users = WorkWithFile.GetAllUsers();
            if(users != null)
            {
                userNicknames = users.Select(it => it.Nickname).ToList();
                if (userNicknames.Contains(Nickname))
                {
                    CurrentUser = users.FirstOrDefault(it => it.Nickname == Nickname);
                    HomeVM = new HomeViewModel();
                    PageSwitch.View = new HomeView();
                }
                else
                {
                    Nickname = "";
                }
            }
            else
            {
                Nickname = "";
            }

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