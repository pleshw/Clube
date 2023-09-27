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
                Race = "Human" ,
                Class = "Thief" ,
                PlayerId = DefaultId ,
                BackgroundHistory = "Fui morar nas ruas e conheci Svija, que era mais velha que eu, tinha 16 anos. Com ela eu\r\ndescobri o que era ter uma família. Roubávamos juntas, éramos eu e ela contra o mundo, e\r\nisso funcionou por um longo tempo. Um dia ela decidiu roubar a casa de um ricaço, dono de\r\numa grande loja, e tudo deu errado. Na fuga ela foi morta na minha frente pela polícia ao\r\ntentar me proteger, bem diante dos meus olhos.\r\nDepois da morte de Svija, minha vida nas ruas se tornou ainda mais difícil. Eu estava\r\nsozinha e com um vazio profundo dentro de mim. Aquela perda me assombrava todos os\r\ndias, e a culpa por ter permitido que ela entrasse naquele perigo era esmagadora.\r\nAos 16 anos, eu não era uma das melhores batedoras de carteiras da cidade de Júpiter. Ao\r\ntentar roubar um comerciante da praça principal, fui descoberta, mas, surpreendentemente,\r\no comerciante não gritou pela polícia. Ele viu meu potencial e me recrutou para algo que\r\njamais teria imaginado: entrar na organização Cofre, uma organização que controla em\r\ntodos os países um \"sistema bancário\" de itens, mas eu não seria comerciante e sim uma\r\ntreinada para matar seus concorrentes.\r\nApós Meses de treinamento, me tornei especialista em estratégia, armas de fogo, arco e\r\nflecha. Comecei a realizar crimes e assassinatos para organização. A primeira vez que tirei\r\numa vida, senti uma mistura de choque, culpa e nojo de mim mesma. Era uma mulher e\r\nseus dois filhos, e foi terrível, mas eu precisava do dinheiro. Ela usava um anel que eu\r\npeguei e carrego comigo até hoje. Com o tempo fui me acostumando lidando melhor com as\r\nmorte. Tinha um intervalo de 2 a 3 meses, no máximo, entre um assassinato e outro. Às\r\nvezes, eu sou contratada para eliminar mais de um membro de uma família e tenho que\r\nfazer bem meu trabalho.\r\nCom o tempo, minha fama cresceu entre os poderosos e ricos do país, que entravam em\r\ncontato comigo procurando meus serviços. Isso me permitiu ganhar mais dinheiro e viajar\r\nrastreando meus alvos pelo país, matando inimigos e rivais de meus clientes, tornando-me\r\na melhor assassina de aluguel da República de Vermílio e uma ótima atiradora.\r\ne agora fui contratada por um homem misterioso, que não revelou sua voz e rosto para\r\nmim, ele vai me pagar o triplo do que eu cobraria para matar um comerciante do Cofre na\r\ncapital do Reino do Meio, Fronteira."
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
