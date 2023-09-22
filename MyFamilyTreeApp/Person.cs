using System;
using System.Collections.Generic;

namespace MyFamilyTreeApp
{
    public partial class Person
    {
        public Person()
        {
            InverseFatherNavigation = new HashSet<Person>();
            InverseMotherNavigation = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public long? Cnic { get; set; }
        public int? Father { get; set; }
        public int? Mother { get; set; }

        public virtual Person? FatherNavigation { get; set; }
        public virtual Person? MotherNavigation { get; set; }
        public virtual ICollection<Person> InverseFatherNavigation { get; set; }
        public virtual ICollection<Person> InverseMotherNavigation { get; set; }
    }
}
