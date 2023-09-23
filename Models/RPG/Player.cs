using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class Player
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Class { get; set; }
        public required int Age { get; set; }
        public required string Race { get; set; }
        public required string ProfileImg { get; set; }
        public required string BackgroundHistory { get; set; }

        public PlayerAttributeList Attributes { get; set; }

        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public DateTime Created { get; set; } = DateTime.Now;

        public Player( )
        {
            Id = Guid.NewGuid();
            Name = "";
            Class = "";
            Age = 0;
            Race = "";
            ProfileImg = "";
            BackgroundHistory = "";
            Attributes = new PlayerAttributeList { };
        }

        public Player( Guid id, string name , string @class , int age , string race, string profileImg , string backgroundHistory, PlayerAttributeList attributes )
        {
            Id = id;
            Name = name;
            Class = @class;
            Age = age;
            Race = race;
            ProfileImg = profileImg;
            BackgroundHistory = backgroundHistory;
            Attributes = attributes;
        }

        public Player( PlayerAttributeList attributes ): this()
        {
            Attributes = attributes;
        }

        public static Player GetEmpty()
        {
            return new Player
            {
                Id = Guid.NewGuid(),
                Name = "" ,
                Class = "" ,
                Age = 0 ,
                Race = "" ,
                ProfileImg = "" ,
                BackgroundHistory = "",
                Attributes = PlayerAttributeList.ClubeAttributesTranslatedTemplate
            };
        }
    }
}
