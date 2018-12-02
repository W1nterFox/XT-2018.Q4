using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Game.DecorFolder;
using Epam.Task2.Round;

namespace Epam.Task2.Game
{
    public abstract class MovableObject : GameObject
    {
        private GameObject[,] grid;
        private Bonus currentBonus;
        private Player currentPlayer;

        public void MoveDown(GameField gameField)
        {
            this.grid = gameField.Grid;

            Point currentLocation = this.Location;
            Point newLocation = new Point(this.Location.X + 1, this.Location.Y);

            if (currentLocation.X < this.grid.GetLength(0) - 1)
            {
                this.ChooseObjectAction(gameField, currentLocation, newLocation);
            }
        }

        public void MoveLeft(GameField gameField)
        {
            this.grid = gameField.Grid;

            Point currentLocation = this.Location;
            Point newLocation = new Point(this.Location.X, this.Location.Y - 1);

            if (currentLocation.Y > 0)
            {
                this.ChooseObjectAction(gameField, currentLocation, newLocation);
            }
        }

        public void MoveRight(GameField gameField)
        {
            this.grid = gameField.Grid;

            Point currentLocation = this.Location;
            Point newLocation = new Point(this.Location.X, this.Location.Y + 1);

            if (currentLocation.Y < this.grid.GetLength(1) - 1)
            {
                this.ChooseObjectAction(gameField, currentLocation, newLocation);
            }
        }

        public void MoveUp(GameField gameField)
        {
            this.grid = gameField.Grid;

            Point currentLocation = this.Location;
            Point newLocation = new Point(this.Location.X - 1, this.Location.Y);

            if (currentLocation.X > 0)
            {
                this.ChooseObjectAction(gameField, currentLocation, newLocation);
            }
        }

        private void ChooseObjectAction(GameField gameField, Point currentLocation, Point newLocation)
        {
            if (!(this.grid[newLocation.X, newLocation.Y] is DecorObject))
            {
                if (this.grid[newLocation.X, newLocation.Y] is Bonus && this is Player && !(this is Enemy))
                {
                    this.currentBonus = (Bonus)this.grid[newLocation.X, newLocation.Y];
                    ((Player)this).UseBonus(this.currentBonus);
                    gameField.Bonuses.Remove(this.currentBonus);
                }
                else if (this.grid[newLocation.X, newLocation.Y] is Enemy && this is Player)
                {
                    ((Enemy)this.grid[newLocation.X, newLocation.Y]).Bite((Player)this);
                }
                else if (this.grid[newLocation.X, newLocation.Y] is Player && this is Enemy)
                {
                    this.currentPlayer = (Player)this.grid[newLocation.X, newLocation.Y];
                    ((Enemy)this).Bite(this.currentPlayer);
                }

                if (!(this.grid[newLocation.X, newLocation.Y] is Enemy && this is Enemy) &&
                    !(this.grid[newLocation.X, newLocation.Y] is Bonus && this is Enemy))
                {
                    this.grid[currentLocation.X, currentLocation.Y] = new FreeCell();
                    this.grid[newLocation.X, newLocation.Y] = this;
                    this.Location = new Point(newLocation.X, newLocation.Y);
                }
            }
        }
    }
}
