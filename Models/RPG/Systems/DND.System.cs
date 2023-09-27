namespace Clube.Models.RPG.Systems
{
    public class DNDSystem : RPGSystem
    {
        public static DNDSystem Instance
        {
            get
            {
                return new DNDSystem
                {
                    Id = new Guid( "6e4628a6-36d6-4cfb-b625-2baf0d27258a" ) ,
                    Name = "Dungeons and Dragons" ,
                    Description = "RPG antigo divertidinho." ,
                    Version = "1.0" ,
                    LinkToRules = "",
                    RPGItems = new()
                };
            }
        }
    }
}
