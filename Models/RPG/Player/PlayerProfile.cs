using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class PlayerProfile : IDefault<PlayerProfile>, IDefaultId
    {
        [NotMapped]
        public static Guid DefaultId
        {
            get => new( "44232be2-13f2-4418-9585-f72ca4b0a55a" );
        }

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }

        public required Guid PlayerId { get; set; }
        public required Player Player { get; set; }

        public static PlayerProfile GetDefault()
        {
            return Player.GetDefault().Profile;
        }
    }
}