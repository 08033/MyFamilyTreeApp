using System;
using System.Collections.Generic;

namespace MyFamilyTreeApp
{
    public partial class AllPerson
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public long? Cnic { get; set; }
        public string Father { get; set; } = null!;
        public string Mother { get; set; } = null!;
    }
}
