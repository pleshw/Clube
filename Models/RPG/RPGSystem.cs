namespace Clube.Models.RPG
{
    public interface IRPGSystem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
    }

    public abstract class RPGSystem : IRPGSystem
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Version { get; set; } = 1;

        public abstract Player GetDefaultPlayer();
    }
}
