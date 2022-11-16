using Game_of_Life.Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Game_of_Life.Domain.Models
{
    internal class Game : IGame<GameGrid, GameRules, Cell>
    {
        private readonly GameRules _gameRules;

        public GameGrid Initial { get; }

        public Game(GameRules rules, GameGrid grid)
        {
            if (rules == null || grid == null) //make safe
            {
                return;
            }
            _gameRules = rules;
            Initial = grid;
        }

        public IEnumerator<GameGrid> GetEnumerator()
        {
            GameGrid current = Initial;

            while (true)
            {
                yield return current;
                current = _gameRules.Apply(current);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static Game Create(GameRules rules, GameGrid grid) => new Game(rules, grid);

        public static Game Default { get; } = new Game(GameRules.Instance, GameGrid.Default());
    }
}
