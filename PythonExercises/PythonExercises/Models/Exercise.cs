namespace PythonExercises.Models
{
    public class Exercise
    {
        public Exercise(int id, string question, string hints, string solution, string level)
        {
            Id = id;
            Question = question;
            Hints = hints;
            Solution = solution;
            Level = level;
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public string Hints { get; set; }
        public string Solution { get; set; }
        public string Level { get; set; }
    }
}