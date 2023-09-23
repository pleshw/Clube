using Clube.Services;
using Clube.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clube.Models.RPG
{
    public class Note
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }
        public required string Value { get; set; }

        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public DateTime Created { get; set; } = DateTime.Now;

        public Note()
        {
            Id = Guid.NewGuid();
            Title = string.Empty;
            Value = string.Empty;
        }

        public bool TryRemoveFromDB()
        {
            return RPGNoteService.TryRemoveNoteById( Id );
        }

        public static Note GetEmpty()
        {
            return new Note
            {
                Id = Guid.NewGuid() ,
                Title = "" ,
                Value = ""
            };
        }

        [NotMapped]
        private static Validation<Note>? _validation;

        [NotMapped]
        public static Validation<Note> Validation
        {
            get
            {
                _validation ??= new Validation<Note>
                {
                    Methods = new List<Validation<Note>.Validator>
                    {
                        ( Note elementToValidade , in List<string> errorMessages ) =>
                        {
                            if( string.IsNullOrEmpty(elementToValidade.Title) && string.IsNullOrEmpty(elementToValidade.Value) )
                            {
                                errorMessages.Add("Título e descrição vazios.");
                                return false;
                            }

                            return true;
                        },

                        ( Note elementToValidade , in List<string> errorMessages ) =>
                        {
                            if( elementToValidade.Id == Guid.Empty )
                            {
                                errorMessages.Add("Id vazio.");
                                return false;
                            }

                            return true;
                        }
                    }
                };

                return _validation;
            }
        }
    }
}
