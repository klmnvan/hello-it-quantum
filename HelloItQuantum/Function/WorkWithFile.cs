using DynamicData;
using HelloItQuantum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HelloItQuantum.Function
{
	public static class WorkWithFile
	{
		private static string filePath = "user.csv";

		/// <summary>
		/// Считывает пользователей из файла
		/// </summary>
		/// <returns>Возвращает null - если файл пустой (не существует) или возвращает модель</returns>
		static public List<User>? GetAllUsers()
		{
			if (!File.Exists(filePath))
			{
				FileStream fs = File.Create(filePath);
				return null;
			}
			List<User> users = new List<User>();
			using (StreamReader read = new StreamReader(filePath))
			{
				while (!read.EndOfStream)
				{
					string[] row = read.ReadLine().Split(';');
					User user = new User();
					user.Nickname = row[0];
					user.Name = row[1];
					user.Surname = row[2];
					user.GameHotkeys = Convert.ToInt32(row[3]);
					user.GameCreateFriend = Convert.ToInt32(row[4]);
					user.GameLabyrinth = Convert.ToInt32(row[5]);
					users.Add(user);
				}
			}
			return users;
		}

		/// <summary>
		/// Добавляет пользователя в файл
		/// </summary>
		/// <param name="newUser">Новый пользователь</param>
		/// <returns>true если пользователь добавлен, false - пользователь уже существует</returns>
		static public bool IsWriteUserInFile(User newUser)
		{
			List<User>? users = GetAllUsers();
			bool exists = users.Any(item => item.Nickname == newUser.Nickname);
			if (exists)
			{
				return false;
			}
			using (StreamWriter writer = new StreamWriter(filePath, true))
			{
				writer.WriteLine($"{newUser.Nickname};{newUser.Name};{newUser.Surname};{newUser.GameHotkeys};{newUser.GameCreateFriend};{newUser.GameLabyrinth}");
			}
			return true;
		}

		static public void UpdateValueGameProgress(int game, int value, User currentUser)
		{
            List<User>? users = GetAllUsers();
            users.Remove(users.FirstOrDefault(it => it.Nickname == currentUser.Nickname));
			switch (game)
			{
				case 1: currentUser.GameHotkeys = currentUser.GameHotkeys < value ? value : currentUser.GameHotkeys; break;
				case 2: currentUser.GameLabyrinth = value; break;
				case 3: currentUser.GameCreateFriend = value; break;
			}
            users.Add(currentUser);
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
				foreach (User newUser in users)
				{
                    writer.WriteLine($"{newUser.Nickname};{newUser.Name};{newUser.Surname};{newUser.GameHotkeys};{newUser.GameCreateFriend};{newUser.GameLabyrinth}");
                }
            }
        }
	}
}
