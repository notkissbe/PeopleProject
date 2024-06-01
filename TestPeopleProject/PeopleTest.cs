using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PeopleProject;

namespace TestPeopleProject;

public class Tests
{
    private PersonStatistics _personStatistics;
    private PersonStatistics _emptyPersonStatistics;

    [SetUp]
    public void Setup()
    {
        var people = new Person[]
        {
            new Person(1, "Alice", 20, true, 85),
            new Person(2, "Bob", 22, true, 90),
            new Person(3, "Charlie", 19, false, 30),
            new Person(4, "David", 21, true, 50),
            new Person(5, "Eva", 23, true, 70)
        };
        var emptyPeople = new Person[] { };
        
        _personStatistics = new PersonStatistics(people);
        _emptyPersonStatistics = new PersonStatistics(emptyPeople);
    }

    [Test]
    public void GetAverageAge_NegativeShouldFail()
    {
        Assert.Throws<ArgumentException>(() => 
        {
            var negativeAgePeople = new Person[]
            {
                new Person(1, "Alice", -20, true, 70),
                new Person(2, "Bob", 22, true, 70)
            };
            var personStatistics = new PersonStatistics(negativeAgePeople);
        }, "Age cannot be negative.");
    }


    [Test]
    public void GetAverageAge_ShouldReturnCorrectAverageAge()
    {
        double averageAge = _personStatistics.getAverageAge();
        Assert.AreEqual(21, averageAge);
    }

    [Test]
    public void GetAverageAge_ShouldHandleEmptyList()
    {
        double averageAge = _emptyPersonStatistics.getAverageAge();
        Assert.AreEqual(0, averageAge);
    }

    [Test]
    public void GetNumberOfStudents_ShouldReturnCorrectNumberOfStudents()
    {
        int numberOfStudents = _personStatistics.getNumberOfStudents();
        Assert.AreEqual(5, numberOfStudents);
    }

    [Test]
    public void GetNumberOfStudents_ShouldHandleEmptyList()
    {
        int numberOfStudents = _emptyPersonStatistics.getNumberOfStudents();
        Assert.AreEqual(0, numberOfStudents);
    }

    [Test]
    public void GetPersonWithHighestScore_ShouldReturnPersonWithHighestScore()
    {
        Person personWithHighestScore = _personStatistics.getPersonWithHighestScore();
        Assert.AreEqual("Bob", personWithHighestScore.Name);
    }

    [Test]
    public void GetPersonWithHighestScore_ShouldHandleEmptyList()
    {
        Person personWithHighestScore = _emptyPersonStatistics.getPersonWithHighestScore();
        Assert.IsNull(personWithHighestScore);
    }

    [Test]
    public void GetPersonWithHighestScore_ShouldThrowExceptionOnTie()
    {
        var peopleWithTie = new Person[]
        {
            new Person(1, "Alice", 20, true, 90),
            new Person(2, "Bob", 22, true, 90)
        };

        var personStatisticsWithTie = new PersonStatistics(peopleWithTie);

        Assert.Throws<Exception>(() => personStatisticsWithTie.getPersonWithHighestScore());
    }

    [Test]
    public void GetPersonWithHighestScore_ShouldHandleAllSameScore()
    {
        var peopleWithSameScore = new Person[]
        {
            new Person(1, "Alice", 20, true, 70),
            new Person(2, "Bob", 22, true, 70)
        };

        var personStatisticsWithSameScore = new PersonStatistics(peopleWithSameScore);

        Assert.Throws<Exception>(() => personStatisticsWithSameScore.getPersonWithHighestScore());
    }

    [Test]
    public void GetAverageScoreOfStudents_ShouldReturnCorrectAverageScore()
    {
        double averageScore = _personStatistics.getAverageScore();
        Assert.AreEqual(65, averageScore, 0.01);
    }

    [Test]
    public void GetAverageScoreOfStudents_ShouldHandleEmptyList()
    {
        double averageScore = _emptyPersonStatistics.getAverageScore();
        Assert.AreEqual(0, averageScore);
    }

    [Test]
    public void GetOldestStudent_ShouldReturnOldestStudent()
    {
        Person oldestStudent = _personStatistics.getOldestStudent();
        Assert.AreEqual("Eva", oldestStudent.Name);
    }

    [Test]
    public void GetOldestStudent_ShouldHandleEmptyList()
    {
        Person oldestStudent = _emptyPersonStatistics.getOldestStudent();
        Assert.IsNull(oldestStudent);
    }

    [Test]
    public void IsAnyoneFailing_ShouldReturnTrueIfAnyStudentIsFailing()
    {
        bool isAnyoneFailing = _personStatistics.isAnyoneFailing();
        Assert.IsTrue(isAnyoneFailing);
    }

    [Test]
    public void IsAnyoneFailing_ShouldReturnFalseIfNoStudentIsFailing()
    {
        var people = new Person[]
        {
            new Person(1, "Alice", 20, true, 85),
            new Person(2, "Bob", 22, true, 90),
            new Person(4, "David", 21, true, 50),
            new Person(5, "Eva", 23, true, 70)
        };

        var personStatistics = new PersonStatistics(people);

        bool isAnyoneFailing = personStatistics.isAnyoneFailing();
        Assert.IsFalse(isAnyoneFailing);
    }

    [Test]
    public void IsAnyoneFailing_ShouldHandleEmptyList()
    {
        bool isAnyoneFailing = _emptyPersonStatistics.isAnyoneFailing();
        Assert.IsFalse(isAnyoneFailing);
    }

    [Test]
    public void IsAnyoneFailing_ShouldHandleScoreAtBoundary()
    {
        var peopleWithBoundaryScore = new Person[]
        {
            new Person(1, "Alice", 20, true, 40)
        };

        var personStatisticsWithBoundaryScore = new PersonStatistics(peopleWithBoundaryScore);

        bool isAnyoneFailing = personStatisticsWithBoundaryScore.isAnyoneFailing();
        Assert.IsFalse(isAnyoneFailing);
    }
}