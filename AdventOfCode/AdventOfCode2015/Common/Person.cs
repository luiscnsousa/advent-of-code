namespace AdventOfCode2015.Common
{
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Relationships = new List<Relationship>();
        }

        public string Name { get; set; }

        public List<Relationship> Relationships { get; private set; }

        public void SortRelationshipsByPreference()
        {
            this.Relationships = this.Relationships.OrderByDescending(r => r.Preference).ToList();
        }
    }
}
