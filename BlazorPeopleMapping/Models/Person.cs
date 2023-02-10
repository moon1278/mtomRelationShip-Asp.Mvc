using AutoMapper;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Identity;
using static BlazorPeopleMapping.Models.PeopleName;

namespace BlazorPeopleMapping.Models
{
    [Table("People")]
    public class Person
    {
        public Person() { 
            this.PersonNames = new HashSet<PeopleName>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Age { get; set; }
        [StringLength(20)]
        public string? Gender { get; set; }
        [StringLength(10)]
        public string? SSNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<PeopleName> PersonNames { get; set; } 
    }
}
