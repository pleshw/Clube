using Clube.Models.RPG.Systems;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class Player : IDefault<Player>, IDefaultId
    {
        public Guid Id { get; set; }
        public PlayerLore Lore { get; set; }
        public PlayerBio Bio { get; set; }
        public PlayerProfile Profile { get; set; }
        public PlayerInventory Inventory { get; set; }
        public PlayerAttributeList Attributes { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.Now;

        [NotMapped]
        public static Guid DefaultId
        {
            get => new( "db25eb15-1496-4588-a09a-e4f5202dd11c" );
        }

        [NotMapped]
        private static Player? _defaultPlayerInstance;

        private Player()
        {
            Id = DefaultId;
            Lore = DefaultLore;
            Bio = DefaultBio;
            Profile = DefaultProfile;
            Inventory = DefaultInventory;
            Attributes = new PlayerAttributeList { };
        }

        public static Player GetDefault()
        {
            _defaultPlayerInstance ??= new Player();
            return _defaultPlayerInstance;
        }

        [NotMapped]
        private PlayerLore DefaultLore
        {
            get => new()
            {
                Id = PlayerLore.DefaultId ,
                Player = this ,
                Race = "Humana" ,
                Class = "Ladra" ,
                PlayerId = DefaultId ,
                BackgroundHistory = "Fui morar nas ruas e conheci Svija, que era mais velha que eu, tinha 16 anos. Com ela eu descobri o que era ter uma família. Roubávamos juntas, éramos eu e ela contra o mundo, e isso funcionou por um longo tempo. Um dia ela decidiu roubar a casa de um ricaço, dono de uma grande loja, e tudo deu errado. Na fuga ela foi morta na minha frente pela polícia ao tentar me proteger, bem diante dos meus olhos. Depois da morte de Svija, minha vida nas ruas se tornou ainda mais difícil. Eu estava sozinha e com um vazio profundo dentro de mim. Aquela perda me assombrava todos os dias, e a culpa por ter permitido que ela entrasse naquele perigo era esmagadora. Aos 16 anos, eu não era uma das melhores batedoras de carteiras da cidade de Júpiter. Ao tentar roubar um comerciante da praça principal, fui descoberta, mas, surpreendentemente, o comerciante não gritou pela polícia. Ele viu meu potencial e me recrutou para algo que jamais teria imaginado: entrar na organização Cofre, uma organização que controla em todos os países um \"sistema bancário\" de itens, mas eu não seria comerciante e sim uma treinada para matar seus concorrentes. Após Meses de treinamento, me tornei especialista em estratégia, armas de fogo, arco e flecha. Comecei a realizar crimes e assassinatos para organização. A primeira vez que tirei uma vida, senti uma mistura de choque, culpa e nojo de mim mesma. Era uma mulher e seus dois filhos, e foi terrível, mas eu precisava do dinheiro. Ela usava um anel que eu peguei e carrego comigo até hoje. Com o tempo fui me acostumando lidando melhor com as morte. Tinha um intervalo de 2 a 3 meses, no máximo, entre um assassinato e outro. Às vezes, eu sou contratada para eliminar mais de um membro de uma família e tenho que fazer bem meu trabalho. Com o tempo, minha fama cresceu entre os poderosos e ricos do país, que entravam em contato comigo procurando meus serviços. Isso me permitiu ganhar mais dinheiro e viajar rastreando meus alvos pelo país, matando inimigos e rivais de meus clientes, tornando-me a melhor assassina de aluguel da República de Vermílio e uma ótima atiradora. e agora fui contratada por um homem misterioso, que não revelou sua voz e rosto para mim, ele vai me pagar o triplo do que eu cobraria para matar um comerciante do Cofre na capital do Reino do Meio, Fronteira."
            };
        }

        [NotMapped]
        private PlayerProfile DefaultProfile
        {
            get => new()
            {
                Id = PlayerProfile.DefaultId ,
                Player = this ,
                PlayerId = DefaultId ,
                Name = "Hazel Peralta",
                Image= "hazel.png"
            };
        }

        [NotMapped]
        private PlayerInventory DefaultInventory
        {
            get => new()
            {
                Id = PlayerInventory.DefaultId ,
                Player = this ,
                PlayerId = DefaultId ,
                Items = new()
                {

                }
            };
        }

        [NotMapped]
        private PlayerBio DefaultBio
        {
            get
            {
                PlayerBio tmpBio = new()
                {
                    Id = PlayerBio.DefaultId ,
                    Player = this ,
                    PlayerId = DefaultId ,
                    Age = 22 ,
                    Weight = "70kg" ,
                    Height = "180cm" ,
                    Personality = "Bipolar" ,
                    Goals = new List<PlayerGoal>
                    {

                    } ,
                    Alignment = CharacterAlignment.ChaoticGood
                };

                tmpBio.Goals.Add( new PlayerGoal
                {
                    Id = PlayerGoal.DefaultId ,
                    Completed = true ,
                    Title = "Have Fun!" ,
                    Description = "Enjoy the game, rest and comeback anytime you want :)" ,
                    Player = this ,
                    PlayerId = DefaultId ,
                    PlayerBio = tmpBio ,
                    PlayerBioId = PlayerBio.DefaultId ,
                } );

                return tmpBio;
            }
        }
    }
}
