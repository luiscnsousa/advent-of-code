namespace AdventOfCode2015.Common
{
    public class Relationship
    {
        public Relationship(Person person, int preference)
        {
            this.Person = person;
            this.Preference = preference;
        }

        public Person Person { get; set; }

        public int Preference { get; set; }
    }
}
