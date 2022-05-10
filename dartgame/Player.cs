using System;
using System.Collections.Generic;

namespace dartgame
{
    class Player : IPlayer
    {
        private string _name;
        private List<Turn> _turns = new();

        public void SetName(string name)
        {
            _name = name;
        }

        public void AddTurn()
        {
            var random = new Random();
            _turns.Add(new Turn(random.Next(0, 20), random.Next(0, 20), random.Next(0, 20)));
        }

        public void AddTurn(int throwOne, int throwTwo, int throwThree)
        {
            _turns.Add(new Turn(throwOne, throwTwo, throwThree));
        }

        public void PrintTurns()
        {
            var turnNum = 1;

            foreach (var turn in _turns)
            {
                Console.WriteLine($"Turn {turnNum}: {turn}");
                turnNum++;
            }
        }


        public int CalculatePoints()
        {
            var total = 0;

            foreach (var turn in _turns)
                total += turn.GetScore();

            return total;
        }

        public override string ToString()
        {
            return _name.ToString().ToUpper();
        }
    }
}
