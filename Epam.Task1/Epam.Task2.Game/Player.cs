using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Game
{
    public class Player : MovableObject
    {
        public Player()
        {
            this.Location = new Point(0, 0);
        }

        public Player(Point p1)
        {
            this.Location = p1;
        }

        public int HealthPoint { get; private set; } = 100;

        public override void Draw()
        {
            Console.WriteLine("Drawn the Player");
        }

        public void LoseHP(int countHP)
        {
            this.HealthPoint -= countHP;
        }

        public void HealHP(int countHP)
        {
            this.HealthPoint += countHP;
            if (this.HealthPoint > 100)
            {
                this.HealthPoint = 100;
            }
        }

        public void UseBonus(Bonus bonus)
        {
            this.HealHP(bonus.HealHPCount);
        }

        public void MakeMove(GameField gameField)
        {
            char playerMove;
            bool validKey = false;
            while (!validKey)
            {
                playerMove = Console.ReadKey(true).KeyChar;
                switch (playerMove)
                {
                    case 'A':
                    case 'a':
                        {
                            gameField.CurrentPlayer.MoveLeft(gameField);
                            validKey = true;
                            break;
                        }

                    case 'D':
                    case 'd':
                        {
                            gameField.CurrentPlayer.MoveRight(gameField);
                            validKey = true;
                            break;
                        }

                    case 'W':
                    case 'w':
                        {
                            gameField.CurrentPlayer.MoveUp(gameField);
                            validKey = true;
                            break;
                        }

                    case 'S':
                    case 's':
                        {
                            gameField.CurrentPlayer.MoveDown(gameField);
                            validKey = true;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Use keys: 'W', 'S', 'A' and 'D'");
                            break;
                        }
                }
            }
        }
    }
}
