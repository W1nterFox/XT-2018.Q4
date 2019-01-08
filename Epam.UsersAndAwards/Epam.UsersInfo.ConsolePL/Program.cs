using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.BLL;
using Epam.UsersInfo.BLL.Interface;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.ConsolePL
{
    public class Program
    {
        private static readonly string DateFormat = "dd.MM.yyyy";
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;

        public static void Main(string[] args)
        {
            userLogic = new UserLogic();
            awardLogic = new AwardLogic();

            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("1. Add user");
                    Console.WriteLine("2. Remove user");
                    Console.WriteLine("3. Add user's award");
                    Console.WriteLine("4. Show list of users");
                    Console.WriteLine("5. Show users with awards");
                    Console.WriteLine("6. Add award");
                    Console.WriteLine("7. Show awards");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("--------------------------");

                    ConsoleKeyInfo entry = Console.ReadKey(intercept: true);

                    switch (entry.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                AddUser();
                                Console.WriteLine("User saved.");
                                break;
                            }

                        case ConsoleKey.D2:
                            {
                                DeleteUser();
                                break;
                            }

                        case ConsoleKey.D3:
                            {
                                AddAwardToUser();
                                break;
                            }

                        case ConsoleKey.D4:
                            {
                                ShowUsers();
                                break;
                            }
                            
                        case ConsoleKey.D5:
                            {
                                ShowUsersWithAwards();
                                break;
                            }

                        case ConsoleKey.D6:
                            {
                                AddAward();
                                break;
                            }

                        case ConsoleKey.D7:
                            {
                                ShowAwards();
                                break;
                            }
                            
                        case ConsoleKey.D0:
                            {
                                return;
                            }
                    }

                    Console.WriteLine();
                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Error: {e.Message}");
                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void AddUser()
        {
            User user = EnterUser();
            userLogic.Add(user);
        }

        private static void DeleteUser()
        {
            Console.Write("Enter ID of user: ");
            int id = int.Parse(Console.ReadLine());
            userLogic.Delete(id);
            userLogic.DeleteFromUsersAwardsList(id);
        }

        private static void ShowUsers()
        {
            User[] users = userLogic.GetAll();
            Console.WriteLine("Users: ");
            foreach (var user in users)
            {
                Console.Write($"ID: {user.Id}, Name: {user.Name}, Birthday: {user.Birthday}, Age: {user.Age}");
                Console.WriteLine();
            }
        }

        private static void AddAward()
        {
            Console.WriteLine("Type name of award: ");
            string nameOfAward = Console.ReadLine();
            if (string.IsNullOrEmpty(nameOfAward))
            {
                throw new ArgumentException("Name can`t be null or empty");
            }

            Award award = new Award { Name = nameOfAward };
            awardLogic.Add(award);
        }

        private static void ShowAwards()
        {
            var awards = awardLogic.GetAll();
            Console.WriteLine("Awards: ");
            foreach (var award in awards)
            {
                Console.WriteLine($"Id: {award.Id}, Name: {award.Name}");
            }
        }

        private static void AddAwardToUser()
        {
            Console.Write("Enter ID of user: ");

            int userId;
            int awardId;

            if (!int.TryParse(Console.ReadLine(), out userId))
            {
                throw new ArgumentException("Id of user must be a number");
            }

            if (awardLogic.GetMaxId() == 0)
            {
                Console.WriteLine("Not a single award has been created yet");
                return;
            }

            Console.WriteLine();
            ShowAwards();

            Console.WriteLine();
            Console.WriteLine("Pick one of the Id`s: ");
            if (!int.TryParse(Console.ReadLine(), out awardId))
            {
                throw new ArgumentException("Id of award must be a number");
            }

            userLogic.AddAwardToUser(userId, awardId);
        }

        private static void ShowUsersWithAwards()
        {
            User[] users = userLogic.GetAll();
            Console.WriteLine("Users with awards: ");
            Console.WriteLine();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Birthday: {user.Birthday}, Age: {user.Age}");
                Console.Write("Awards: ");
                var awardsIdsOfUser = userLogic.GetUserAwardsIds(user.Id);
                foreach (var award in awardLogic.GetAwardsByIds(awardsIdsOfUser))
                {
                    Console.Write("{0} ", award.Name);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static User EnterUser()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can`t be null or empty");
            }

            Console.Write("Enter birthday. Format: {0}. ", DateFormat);
            string birthday = Console.ReadLine();
            DateTime dateTemp;

            if (DateTime.TryParseExact(birthday, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTemp))
            {
                return new User { Name = name, Birthday = dateTemp };
            }
            else
            {
                throw new ArgumentException("Incorrect date");
            }
        }
    }
}
