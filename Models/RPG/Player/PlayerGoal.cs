using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class PlayerGoal : IDefault<PlayerGoal>, IDefaultId
    {
        [NotMapped]
        public static Guid DefaultId
        {
            get => new( "4587d345-3c12-46f2-88a8-55841fbfe991" );
        }

        public Guid Id { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }

        public required bool Completed { get; set; }

        public required Guid PlayerId { get; set; }
        public required Player Player { get; set; }

        public required Guid PlayerBioId { get; set; }
        public required PlayerBio PlayerBio { get; set; }

        public static PlayerGoal GetDefault()
        {
            return Player.GetDefault().Bio.Goals.First();
        }
    }
}