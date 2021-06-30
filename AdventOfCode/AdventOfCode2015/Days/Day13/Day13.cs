namespace AdventOfCode2015.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2015.Common;
    using Infrastructure;

    public class Day13 : IExercise
    {
        public Answer Solve()
        {
            var input = FileUtils.GetProblemInput();

            var persons = this.BuildRelationships(input);

            var arrangements = this.TryEveryArrangement(persons).OrderByDescending(this.CalculateTotalHappinness).ToList();

            return new Answer { Part1 = this.SolvePart1(arrangements), Part2 = this.SolvePart2(persons, arrangements) };
        }

        private object SolvePart1(List<List<Person>> arrangements)
        {
            var bestArrangement = arrangements.First();

            var totalHappiness = this.CalculateTotalHappinness(bestArrangement);
            
            return totalHappiness;
        }

        private object SolvePart2(List<Person> persons, List<List<Person>> arrangements)
        {
            var myselft = new Person("Myself");
            foreach (var person in persons)
            {
                myselft.Relationships.Add(new Relationship(person, 0));
                person.Relationships.Add(new Relationship(myselft, 0));
            }

            var totalhappiness = 0;
            var arrangement = arrangements.First();
            
            for (var i = 0; i < arrangement.Count; i++)
            {
                var newArrangement = arrangement.ToList();
                newArrangement.Insert(i, myselft);
                var happiness = this.CalculateTotalHappinness(newArrangement);
                if (happiness > totalhappiness)
                {
                    totalhappiness = happiness;
                }
            }

            return totalhappiness;
        }

        private List<Person> BuildRelationships(string[] input)
        {
            var persons = new List<Person>();
            foreach (var s in input)
            {
                var parts = s.Split(' ');
                var person1Name = parts[0];
                var person1 = persons.SingleOrDefault(p => p.Name.Equals(person1Name));
                if (person1 == null)
                {
                    person1 = new Person(person1Name);
                    persons.Add(person1);
                }

                var person2Name = parts[parts.Length - 1];
                person2Name = person2Name.Remove(person2Name.Length - 1, 1);
                var person2 = persons.SingleOrDefault(p => p.Name.Equals(person2Name));
                if (person2 == null)
                {
                    person2 = new Person(person2Name);
                    persons.Add(person2);
                }

                var preference = int.Parse(parts[3]);
                if (parts[2].Equals("lose"))
                {
                    preference *= -1;
                }

                person1.Relationships.Add(new Relationship(person2, preference));
            }

            return persons;
        }

        private List<List<Person>> TryEveryArrangement(List<Person> persons)
        {
            var arrangements = new List<List<Person>>();
            
            this.DoPermutations(persons.ToArray(), arrangements, 0);

            return arrangements;
        }

        private void DoPermutations(Person[] arrangement, List<List<Person>> allArrangements, int seat)
        {
            if (seat == arrangement.Length - 1)
            {
                allArrangements.Add(arrangement.ToList());
            }
            else
            {
                for (var i = seat; i < arrangement.Length; i++)
                {
                    var person1 = arrangement[i];
                    var person2 = arrangement[seat];
                    arrangement[seat] = person1;
                    arrangement[i] = person2;
                    this.DoPermutations(arrangement, allArrangements, seat + 1);
                    arrangement[i] = person1;
                    arrangement[seat] = person2;
                }
            }
        }

        private int CalculateTotalHappinness(List<Person> roundTable)
        {
            var totalHappiness = 0;
            for (var seat = 0; seat < roundTable.Count; seat++)
            {
                var leftSeat = seat == 0 ? roundTable.Count - 1 : seat - 1;
                var rightSeat = seat == roundTable.Count - 1 ? 0 : seat + 1;

                var person = roundTable[seat];
                var atTheLeft = roundTable[leftSeat];
                var atTheRight = roundTable[rightSeat];

                totalHappiness += person.Relationships.Single(r => r.Person == atTheLeft).Preference;
                totalHappiness += person.Relationships.Single(r => r.Person == atTheRight).Preference;
            }

            return totalHappiness;
        }
    }
}
