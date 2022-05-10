using System.Collections.Generic;

namespace dartgame
{
    class Turn : ITurn
    {
        private List<int> _throws = new();

        public Turn(int throwOne, int throwTwo, int throwThree)
        {
            _throws.Add(throwOne);
            _throws.Add(throwTwo);
            _throws.Add(throwThree);
        }

        public int GetScore()
        {
            var score = 0;

            foreach (var t in _throws)
                score += t;

            return score;
        }

        public override string ToString()
        {
            return $"{_throws[0]}, {_throws[1]}, {_throws[2]}";
        }
    }
}
