using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class PlayerInventory : IDefault<PlayerInventory>, IDefaultId
    {
        [NotMapped]
        public static Guid DefaultId
        {
            get => new( "258cd403-03a8-48a2-bd90-3b068d082d69" );
        }

        public Guid Id { get; set; }

        public required Guid PlayerId { get; set; }
        public required Player Player { get; set; }
        public required List<RPGItem> Items { get; set; }

        public static PlayerInventory GetDefault()
        {
            return Player.GetDefault().Inventory;
        }
    }
}