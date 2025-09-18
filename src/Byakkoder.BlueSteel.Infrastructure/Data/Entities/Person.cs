using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Byakkoder.BlueSteel.Infrastructure.Data.Entities
{
    [Table("person")]
    public class Person : EntityBase
    {
        public Person()
        {
            MovieActors = new List<MovieActor>();
            MovieDirectors = new List<MovieDirector>();
            MovieWriters = new List<MovieWriter>();
        }

        #region Properties

        [Column("full_name")]
        public string? Name { get; set; }

        [Column("photo")]
        public string? Photo { get; set; }

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        [Column("place_of_birth")]
        public string? PlaceOfBirth { get; set; }

        [Column("gender")]
        public string? Gender { get; set; }

        [Column("biography")]
        public string? Biography { get; set; }

        public virtual List<MovieActor> MovieActors { get; set; }

        public virtual List<MovieDirector> MovieDirectors { get; set; }

        public virtual List<MovieWriter> MovieWriters { get; set; }

        #endregion
    }
}
