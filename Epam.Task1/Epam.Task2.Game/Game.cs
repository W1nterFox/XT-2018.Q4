using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task2.Game
{
    public class Game
    {
        private GameField gameField;
        private ArtificialIntelligence ai;
        
        public Game()
        {
            Console.WriteLine("Game is starting...");
            this.gameField = new GameField();
            this.ai = new ArtificialIntelligence();
        }

        public GameField GameField => this.gameField;

        public void StartGame()
        {
            while (this.gameField.CurrentPlayer.HealthPoint >= 0 && this.gameField.Bonuses.Count != 0)
            {
                this.PrintRules();
                this.DrawHealthPoint();
                this.gameField.DrawGrid();
                this.gameField.CurrentPlayer.MakeMove(this.gameField);
                this.MakeEnemiesMove(this.gameField);
                
                Console.Clear();
            }

            this.GameOver();
        }
        
        public void MakeEnemiesMove(GameField gameField)
        {
            this.ai.MakeStep(this.gameField);
        }

        public void GameOver()
        {
            Console.WriteLine("Game is over");
            if (this.gameField.Bonuses.Count == 0)
            {
                Console.WriteLine("You have collected all bonuses! Congratulations!");
                Console.WriteLine();
            }

            this.PrintStatistics();
        }

        public void PrintRules()
        {
            Console.WriteLine("A - Move left");
            Console.WriteLine("D - Move right");
            Console.WriteLine("W - Move up");
            Console.WriteLine("S - Move down");
            Console.WriteLine();
            Console.WriteLine("P - Player");
            Console.WriteLine("E - Enemy");
            Console.WriteLine("B - Bonus");
            Console.WriteLine("* - Decor");
        }
        
        public void DrawHealthPoint()
        {
            Console.WriteLine("Health points: {0}/100", this.gameField.CurrentPlayer.HealthPoint);
        }

        public void PrintStatistics()
        {
            Console.WriteLine("Statistics: ");
            Console.WriteLine("--------------");
            Console.WriteLine("--------------");
            Console.WriteLine("--------------");
            Console.WriteLine("Press any button to close this window...");
        }
    }
}
