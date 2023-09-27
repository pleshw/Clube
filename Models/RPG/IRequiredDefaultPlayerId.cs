namespace Clube.Models.RPG
{
    public interface IRequiredDefaultPlayerId
    {
        static abstract Guid DefaultPlayerId { get; }
    }
}
