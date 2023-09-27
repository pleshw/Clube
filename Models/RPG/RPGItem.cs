namespace Clube.Models.RPG
{
    public class RPGItem
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }

        public required Guid RPGSystemId { get; set; }
        public required RPGSystem RPGSystem { get; set; }

        public Guid? InventoryId { get; set; }
        public PlayerInventory? Inventory { get; set; }
    }
}
