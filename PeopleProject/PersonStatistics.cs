namespace PeopleProject;

public class PersonStatistics
{
    private Person[] people;

    public PersonStatistics(Person[] people)
    {
        this.people = people;
    }

    public Person[] People
    {
        private get => people;
        set => people = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double getAverageAge()
    {
        if (people.Length == 0)
            return 0;

        int sum = people.Sum(person => person.Age);
        return (double)sum / people.Length;
    }

    public int getNumberOfStudents()
    {
        return people.Length;
    }

    public Person getPersonWithHighestScore()
    {
        if (people.Length == 0)
            return null;

        var hiScorePersons = people.OrderByDescending(p => p.Score).ToList();
        int hiScore = hiScorePersons.First().Score;
        var highestScorers = hiScorePersons.Where(p => p.Score == hiScore).ToList();

        if (highestScorers.Count > 1)
        {
            throw new Exception("Pontegyezés van a legmagasabb pontszámnál");
        }

        return highestScorers.First();
    }

    public double getAverageScore()
    {
        if (people.Length == 0)
            return 0;
        
        return people.Average(p => p.Score);
    }

    public Person getOldestStudent()
    {
        return people.OrderByDescending(p => p.Age).FirstOrDefault();
    }

    public bool isAnyoneFailing()
    {
        return people.Any(p => p.Score < 40);
    }

}