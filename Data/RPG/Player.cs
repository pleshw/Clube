using static Clube.Shared.ProfileHeader;

namespace Clube.Data.RPG
{
    public class Player
    {
        public string Name;
        public string Class;
        public int Age;
        public string Race;
        public string ProfileImg;

        public PlayerAttributes Attributes;

        public Player( )
        {
            Name = "";
            Class = "";
            Age = 0;
            Race = "";
            ProfileImg = "";
            Attributes = new PlayerAttributes { };
        }

        public Player( string name , string @class , int age , string race, string profileImg , PlayerAttributes attributes )
        {
            Name = name;
            Class = @class;
            Age = age;
            Race = race;
            ProfileImg = profileImg;
            Attributes = attributes;
        }

        public Player( PlayerAttributes attributes ): this()
        {
            Attributes = attributes;
        }

        public static Player GetEmpty()
        {
            return new Player
            {
                Name = "" ,
                Class = "" ,
                Age = 0 ,
                Race = "" ,
                ProfileImg = "" ,
                Attributes = PlayerAttributes.ClubeAttributesTranslatedTemplate
            };
        }
    }
}
