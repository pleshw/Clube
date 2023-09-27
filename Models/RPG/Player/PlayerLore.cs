using Clube.Models.RPG.Systems;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class PlayerLore : IDefault<PlayerLore>, IDefaultId
    {
        [NotMapped]
        public static Guid DefaultId
        {
            get => new( "f2d5ff97-6e46-4f90-ae4b-05bd88373d5d" );
        }

        public Guid Id { get; set; }
        public required string Race { get; set; }
        public required string Class { get; set; }
        public required string BackgroundHistory { get; set; }

        public required Guid PlayerId { get; set; }
        public required Player Player { get; set; }

        public static PlayerLore GetDefault()
        {
            return Player.GetDefault().Lore;
        }
    }
}