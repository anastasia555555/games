using System.Collections.Generic;

namespace Game_of_Life.Domain.Interfaces
{
    public interface IGame<TGameGrid, TGameRules, TCell> : IEnumerable<TGameGrid> 
        where TGameGrid : IGameGrid<TCell>
        where TGameRules : IGameRules<TGameGrid, TCell>
    {
        TGameGrid Initial { get; }
    }
}
