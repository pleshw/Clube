namespace Clube.Data.RPG
{
    public enum AttributeType
    {
        PRIMARY,
        SECONDARY
    }

    public record struct PlayerAttribute
    {
        public required int Value;
        public required string Name;
        public required string Description;
        public required AttributeType Type;
    }

    public class PlayerAttributes : List<PlayerAttribute>
    {
        public static PlayerAttributes ClubeAttributesTranslatedTemplate
        {
            get
            {
                return new PlayerAttributes
                {
                    new PlayerAttribute
                    {
                        Type = AttributeType.PRIMARY,
                        Value = 0 ,
                        Name = "Vigor" ,
                        Description = "O atributo Vigor mede a resistência física e a força do seu personagem. Cada ponto de Vigor aumenta a vida do personagem em +5 e melhora suas chances de sucesso em tarefas que requerem força física, como levantar objetos pesados ou resistir a danos."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.PRIMARY,
                        Value = 0 ,
                        Name = "Inteligência" ,
                        Description = "Este atributo reflete a perspicácia e capacidade intelectual do seu personagem. Influencia suas habilidades arcanas, tornando mais fácil aprender e manipular magias. Também é vital para resolver enigmas e superar desafios intelectuais."
                    },

                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Trapaça" ,
                        Description = "Reflete a capacidade do seu personagem de enganar e trapacear. Pode ser útil para jogadas de truque, persuasão e evitar armadilhas."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Intuição" ,
                        Description = "Representa a sensibilidade do seu personagem a situações e pistas ocultas. Influencia a capacidade de perceber ameaças ou oportunidades sutis."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Percepção" ,
                        Description = "Sua habilidade em observar e perceber detalhes do ambiente ao seu redor. Afeta a detecção de objetos ocultos ou a observação de pistas importantes."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Intimidação" ,
                        Description = "Mede a capacidade do seu personagem de amedrontar ou coagir os outros. Pode ser útil para obter informações ou ganhar vantagem em negociações."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Conhecimento" ,
                        Description = "Reflete o conhecimento geral e cultural do seu personagem. Pode ser usado para lembrar fatos históricos, identificar criaturas ou compreender culturas estrangeiras."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Iniciativa" ,
                        Description = "Sua rapidez de reflexos e prontidão em situações de combate. Afeta a ordem em que seu personagem age durante os combates."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "História" ,
                        Description = "O conhecimento do seu personagem sobre eventos passados e lendas. Pode ser valioso para resolver enigmas ou compreender a história do mundo."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Furtividade" ,
                        Description = "Sua habilidade de mover-se silenciosamente e passar despercebido. Útil para se esconder ou surpreender inimigos."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Performance" ,
                        Description = "Reflete o talento artístico e capacidade de atuação do seu personagem. Pode ser usado para entreter, influenciar ou enganar."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Perícia com Animais" ,
                        Description = "Mede a afinidade e habilidade do seu personagem em lidar com criaturas animais. Útil para treinar animais de estimação ou comunicar-se com animais selvagens."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Conhecimento Médico" ,
                        Description = "Sua compreensão da anatomia e medicina. Pode ser crucial para tratar ferimentos, diagnosticar doenças ou realizar procedimentos médicos."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Habilidade com as Mãos" ,
                        Description = "Reflete a destreza manual do seu personagem. Pode ser útil para realizar tarefas que exigem precisão manual, como arrombar fechaduras ou criar objetos."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Persuasão" ,
                        Description = "Sua habilidade em convencer e influenciar os outros. Pode ser usada para ganhar aliados, obter informações ou negociar vantagens."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Equilíbrio" ,
                        Description = "Mede a estabilidade física e agilidade do seu personagem. Útil para evitar quedas, equilibrar-se em situações precárias ou realizar acrobacias."
                    }
                };
            }
        }

        public static PlayerAttributes ClubeAttributesTemplate
        {
            get
            {
                return new PlayerAttributes
                {
                    new PlayerAttribute
                    {
                        Type = AttributeType.PRIMARY,
                        Value = 0 ,
                        Name = "Strength" ,
                        Description = "Measures your character's physical power and ability to lift, carry, and perform feats of raw strength."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.PRIMARY,
                        Value = 0 ,
                        Name = "Intelligence" ,
                        Description = "Measures your character's mental acuity, knowledge, and problem-solving ability."
                    },

                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Deception" ,
                        Description = "Reflects your character's ability to deceive and cheat. Useful for trickery, persuasion, and avoiding traps." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Intuition" ,
                        Description = "Represents your character's sensitivity to hidden situations and clues. Influences the ability to perceive subtle threats or opportunities." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Perception" ,
                        Description = "Your ability to observe and notice details in your surroundings. Affects the detection of hidden objects or the observation of important clues." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Intimidation" ,
                        Description = "Measures your character's ability to intimidate or coerce others. Useful for gathering information or gaining an advantage in negotiations." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Knowledge" ,
                        Description = "Reflects your character's general and cultural knowledge. Can be used to recall historical facts, identify creatures, or understand foreign cultures." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Initiative" ,
                        Description = "Your quick reflexes and readiness in combat situations. Affects the order in which your character acts during battles." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "History" ,
                        Description = "Your character's knowledge of past events and legends. Can be valuable for solving puzzles or understanding the world's history." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Stealth" ,
                        Description = "Your ability to move silently and go unnoticed. Useful for hiding or surprising enemies." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Performance" ,
                        Description = "Reflects your character's artistic talent and acting ability. Can be used for entertaining, influencing, or deceiving." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Animal Handling" ,
                        Description = "Measures your character's affinity and skill in dealing with animals. Useful for training pets or communicating with wild animals." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 ,
                        Name = "Medical Knowledge" ,
                        Description = "Your understanding of anatomy and medicine. Crucial for treating injuries, diagnosing illnesses, or performing medical procedures." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 , Name = "Manual Dexterity" ,
                        Description = "Reflects your character's manual dexterity. Useful for tasks that require manual precision, such as picking locks or crafting objects." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 , Name = "Persuasion" ,
                        Description = "Your ability to convince and influence others. Can be used to gain allies, obtain information, or negotiate advantages." 
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0 , 
                        Name = "Balance" ,
                        Description = "Measures your character's physical stability and agility. Useful for avoiding falls, balancing in precarious situations, or performing acrobatics." 
                    }
                };
            }
        }

        public static PlayerAttributes DndAttributesTemplate
        {
            get
            {
                return new PlayerAttributes
                {
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Strength",
                        Description = "Measures your character's physical power and ability to lift, carry, and perform feats of raw strength."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Dexterity",
                        Description = "Represents your character's agility, reflexes, and ability to perform tasks requiring finesse."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Constitution",
                        Description = "Reflects your character's health, stamina, and resistance to injury and illness."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Intelligence",
                        Description = "Measures your character's mental acuity, knowledge, and problem-solving ability."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Wisdom",
                        Description = "Represents your character's perception, insight, and ability to make sound decisions."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Charisma",
                        Description = "Reflects your character's charm, persuasiveness, and ability to influence others."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Acrobatics",
                        Description = "Your character's skill in performing acrobatic maneuvers and maintaining balance."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Arcana",
                        Description = "Your character's knowledge of arcane magic and mystical forces."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Survival",
                        Description = "Measures your character's ability to navigate, find food, and survive in the wild."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Perception",
                        Description = "Your character's keenness of senses and ability to notice hidden details and threats."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Stealth",
                        Description = "Your character's ability to move silently and go unnoticed by others."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Persuasion",
                        Description = "Your character's charm and eloquence in convincing others to see things their way."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Athletics",
                        Description = "Measures your character's physical prowess in sports, climbing, and swimming."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Religion",
                        Description = "Your character's knowledge of religious practices, deities, and beliefs."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Medicine",
                        Description = "Reflects your character's ability to provide first aid, treat injuries, and diagnose illnesses."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Investigation",
                        Description = "Measures your character's aptitude for examining clues, solving mysteries, and finding hidden objects."
                    },
                };
            }
        }

        public static PlayerAttributes DndAttributesTranslatedTemplate
        {
            get
            {
                return new PlayerAttributes
                {
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Força",
                        Description = "Mede o poder físico do seu personagem e a habilidade de levantar, carregar e realizar proezas de força bruta."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Destreza",
                        Description = "Representa a agilidade, reflexos e habilidade do seu personagem para realizar tarefas que exigem destreza."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Constituição",
                        Description = "Reflete a saúde, resistência e resistência a lesões e doenças do seu personagem."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Inteligência",
                        Description = "Mede a acuidade mental, conhecimento e habilidade de resolução de problemas do seu personagem."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Sabedoria",
                        Description = "Representa a percepção, perspicácia e capacidade do seu personagem de tomar decisões acertadas."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Carisma",
                        Description = "Reflete o charme, a persuasão e a capacidade do seu personagem de influenciar os outros."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Acrobacia",
                        Description = "Habilidade do seu personagem em realizar manobras acrobáticas e manter o equilíbrio."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Arcana",
                        Description = "Conhecimento do seu personagem sobre magia arcana e forças místicas."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Sobrevivência",
                        Description = "Mede a capacidade do seu personagem de navegar, encontrar comida e sobreviver na natureza selvagem."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Percepção",
                        Description = "Agudeza dos sentidos do seu personagem e habilidade de perceber detalhes e ameaças ocultas."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Furtividade",
                        Description = "Habilidade do seu personagem de mover-se silenciosamente e passar despercebido pelos outros."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Persuasão",
                        Description = "O charme e a eloquência do seu personagem em convencer os outros a ver as coisas do seu jeito."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Atletismo",
                        Description = "Mede a destreza física do seu personagem em esportes, escalada e natação."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Religião",
                        Description = "Conhecimento do seu personagem sobre práticas religiosas, divindades e crenças."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Medicina",
                        Description = "Reflete a capacidade do seu personagem de prestar primeiros socorros, tratar ferimentos e diagnosticar doenças."
                    },
                    new PlayerAttribute
                    {
                        Type = AttributeType.SECONDARY,
                        Value = 0,
                        Name = "Investigação",
                        Description = "Mede a aptidão do seu personagem para examinar pistas, resolver mistérios e encontrar objetos ocultos."
                    },
                };
            }
        }
    }
}
