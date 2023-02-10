using AutoMapper;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlazorPeopleMapping.Models
{
    [Table("PeopleNames")]
    public  class PeopleName
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Key]
        [ForeignKey("Person"), Required, Column(Order = 1)]
        public long PersonId { get; set; }
        [Key]
        [ForeignKey("Name"), Required, Column(Order = 2)]
        public long NameId { get; set; }
        [Key]
        [Column("NameType")]
        [MaxLength(50)]

        public virtual Name Name { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
    }
}