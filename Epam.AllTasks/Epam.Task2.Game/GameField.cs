using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Game.BonusFolder;
using Epam.Task2.Game.DecorFolder;
using Epam.Task2.Game.EnemyFolder;

namespace Epam.Task2.Game
{
    public class GameField
    {
        private GameObject[,] grid;
        private Random r = new Random();
        private List<DecorObject> decorObjects = new List<DecorObject> { };
        private List<Enemy> enemies = new List<Enemy> { };
        private List<Bonus> bonuses = new List<Bonus> { };

        public GameField()
        {
            this.InitGrid();
            this.InitDecorObjects();
            this.InitEnemies();
            this.InitBonuses();
            this.InitPlayer();
        }

        public GameObject[,] Grid => this.grid;

        public int Height { get; } = 10;

        public int Width { get; } = 20;

        public List<Enemy> Enemies => this.enemies;

        public List<Bonus> Bonuses => this.bonuses;

        public Player CurrentPlayer { get; private set; }
        
        public void InitGrid()
        {
            this.grid = new GameObject[this.Height, this.Width];
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    this.grid[i, j] = new FreeCell();
                }
            }
        }

        public void InitDecorObjects()
        {
            this.decorObjects.Add(new Stone());
            this.decorObjects.Add(new Tree());
            this.decorObjects.Add(new Well());

            this.PutObjectsToField(this.decorObjects.ToArray());
        }

        public void InitEnemies()
        {
            this.enemies.Add(new Wolf());
            this.enemies.Add(new Bear());
            this.enemies.Add(new Wolverine());

            this.PutObjectsToField(this.enemies.ToArray());
        }

        public void InitBonuses()
        {
            this.bonuses.Add(new Apple());
            this.bonuses.Add(new Cherry());
            this.bonuses.Add(new Grape());
            this.bonuses.Add(new Mushroom());

            this.PutObjectsToField(this.bonuses.ToArray());
        }

        public void InitPlayer()
        {
            this.CurrentPlayer = new Player();
            this.PutOneObjectToField(this.CurrentPlayer);
        }

        public void PutObjectsToField(GameObject[] arr)
        {
            foreach (var elem in arr)
            {
                this.PutOneObjectToField(elem);
            }
        }

        //// Алгоритм ужасный, но суть задания не в алгоритме
        //// Если надо будет переписать эффективнее, то сделаю
        public void PutOneObjectToField(GameObject elem)
        {
            int i;
            int k;
            if (this.GridIsNotFull())
            {
                while (true)
                {
                    i = this.r.Next(0, 9);
                    k = this.r.Next(0, 20);
                    if (this.Grid[i, k] is FreeCell)
                    {
                        this.Grid[i, k] = elem;
                        elem.Location = new Round.Point(i, k);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Game object did not put on the field. Field has not any free cell");
            }
        }

        public bool GridIsNotFull()
        {
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (this.Grid[i, j] is FreeCell)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void DrawGrid()
        {
            for (int i = 0; i < this.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grid.GetLength(1); j++)
                {
                    if (this.Grid[i, j] is FreeCell)
                    {
                        Console.Write("_");
                    }
                    else if (this.Grid[i, j] is Player)
                    {
                        Console.Write("P");
                    }
                    else if (this.Grid[i, j] is Bonus)
                    {
                        Console.Write('B');
                    }
                    else if (this.Grid[i, j] is DecorObject)
                    {
                        Console.Write('*');
                    }
                    else if (this.Grid[i, j] is Enemy)
                    {
                        Console.Write('E');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
