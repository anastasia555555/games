using Game_of_Life.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life.Domain.Models
{
    internal class GameRules : IGameRules<GameGrid, Cell>
    {
        public static GameRules Instance { get; } = new GameRules();

        public GameGrid Apply(GameGrid oldGrid)
        {
            Cell[,] newGrid = new Cell[oldGrid.Rows, oldGrid.Columns];

            for (int row = 0; row < oldGrid.Rows; row++)
            {
                for (int column = 0; column < oldGrid.Columns; column++)
                {
                    newGrid[row, column] = CalculateCellStatus(oldGrid, row, column);
                }
            }

            return GameGrid.Create(newGrid);
        }

        private Cell CalculateCellStatus(GameGrid currentGrid, int row, int column)
        {
            Cell currentCell = currentGrid.Grid[row, column];

            IEnumerable<Cell> neighbours = GetNeighbours(currentGrid, row, column);

            int aliveNeighbours = neighbours.Count(x => x == Cell.Alive);

            if (currentCell == Cell.Alive && (aliveNeighbours == 2 || aliveNeighbours == 3))
                return Cell.Alive;
            if (currentCell == Cell.Dead && aliveNeighbours == 3)
                return Cell.Dead;
            else
                return Cell.Dead;
        }

        private IEnumerable<Cell> GetNeighbours(GameGrid currentGrid, int row, int column)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    //if (i > currentGrid.Rows || j > currentGrid.Columns) continue;

                    int normalizedRow = Normalize(row + i, currentGrid.Rows);
                    int normalizedColumn = Normalize(column + j, currentGrid.Columns);

                    yield return currentGrid.Grid[normalizedRow, normalizedColumn];
                }
            }
        }

        private static int Normalize(int current, int total)
            => (current + total) / total;
    }
}
