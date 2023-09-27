using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class RPGSystem
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Version { get; set; } = "1.0";
        public required string LinkToRules { get; set; }

        public required List<RPGItem> RPGItems { get; set; } = new List<RPGItem>();

        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
