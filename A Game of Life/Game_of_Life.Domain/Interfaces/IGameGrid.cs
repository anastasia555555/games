using System.Collections.Generic;

namespace Game_of_Life.Domain.Interfaces
{
    public interface IGameGrid<TCell> : IEnumerable<TCell>
    {
        int Rows { get;  }
        int Columns { get; }
    }
}