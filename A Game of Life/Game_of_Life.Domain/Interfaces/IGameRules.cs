namespace Game_of_Life.Domain.Interfaces
{
    public interface IGameRules<TGameGrid, TCell> 
        where TGameGrid : IGameGrid<TCell>
    {
        TGameGrid Apply(TGameGrid oldGrid);
    }
}