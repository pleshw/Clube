using Clube.Models.RPG;

namespace Clube.Models.RPG.Systems
{
    public class ClubeSystem : RPGSystem
    {
        public static ClubeSystem Instance
        {
            get
            {
                return new ClubeSystem
                {
                    Id = new Guid( "228f928b-de26-4954-8193-9a98c787663c" ) ,
                    Name = "Sistema do Clube" ,
                    Version = "1.0" ,
                    Description = "RPG do Clube" ,
                    LinkToRules = "",
                    RPGItems = new()
                };
            }
        }
    }
}
