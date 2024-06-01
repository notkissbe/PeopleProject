namespace PeopleProject
{
    public class Person
    {
        private int id;
        private string name;
        private int age;
        private bool isStudent;
        private int score;

        public Person(int id, string name, int age, bool isStudent, int score)
        {
            if (age < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }

            if (score < 0 || score > 100)
            {
                throw new ArgumentException("Score must be between 0 and 100.");
            }

            this.id = id;
            this.name = name;
            this.age = age;
            this.isStudent = isStudent;
            this.score = score;
        }

        public int Id => id;
        public string Name => name;
        public int Age => age;
        public bool IsStudent => isStudent;
        public int Score => score;
    }
}