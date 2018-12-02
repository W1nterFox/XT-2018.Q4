using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Game
{
    public class ArtificialIntelligence
    {
        private Random r = new Random();

        public void MakeStep(GameField gameField)
        {
            foreach (var enemy in gameField.Enemies)
            {
                var direction = this.r.Next(0, 3);
                switch (direction)
                {
                    case 0:
                        {
                            enemy.MoveUp(gameField);
                            break;
                        }

                    case 1:
                        {
                            enemy.MoveDown(gameField);
                            break;
                        }

                    case 2:
                        {
                            enemy.MoveLeft(gameField);
                            break;
                        }

                    case 3:
                        {
                            enemy.MoveRight(gameField);
                            break;
                        }
                }
            }
        }
    }
}
