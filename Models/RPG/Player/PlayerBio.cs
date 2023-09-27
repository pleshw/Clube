using Clube.Models.RPG.Systems;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public enum CharacterAlignment
    {
        LawfulGood,
        NeutralGood,
        ChaoticGood,
        LawfulNeutral,
        TrueNeutral,
        ChaoticNeutral,
        LawfulEvil,
        NeutralEvil,
        ChaoticEvil
    }

    public class PlayerBio : IDefault<PlayerBio>, IDefaultId
    {
        [NotMapped]
        public static Guid DefaultId
        {
            get => new( "452b4f91-27ff-43e3-8bb0-ad3aac545dee" );
        }

        public Guid Id { get; set; }

        public required int Age { get; set; }
        public required string Weight { get; set; }
        public required string Height { get; set; }
        public required string Personality { get; set; }
        public required List<PlayerGoal> Goals { get; set; }
        public required CharacterAlignment Alignment { get; set; }

        public required Guid PlayerId { get; set; }
        public required Player Player { get; set; }

        public static PlayerBio GetDefault()
        {
            return Player.GetDefault().Bio;
        }
    }
}