using Game_of_Life.Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Game_of_Life.Domain.Models
{
    public class GameGrid : IGameGrid<Cell>
    {
        public Cell[,] Grid { get; }

        public int Rows => Grid.GetLength(0);

        public int Columns => Grid.GetLength(1);

        private GameGrid(Cell[,] grid)
        {
            Grid = grid; // make safe
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    yield return Grid[row, column]; 
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static GameGrid Create(Cell[,] grid) => new GameGrid(grid);

        public static GameGrid Default() => new GameGrid(new Cell[20, 30]);
    }
}
