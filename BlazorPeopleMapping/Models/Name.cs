using AutoMapper;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Identity;
using static BlazorPeopleMapping.Models.PeopleName;

namespace BlazorPeopleMapping.Models
{
    [Table("Names")]
    public class Name
    {
        public Name() { 
            this.PeopleNames =  new HashSet<PeopleName>();
        }
        public long Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string? NameString { get; set; }

        public virtual ICollection<PeopleName> PeopleNames { get; set; }
    }
}
