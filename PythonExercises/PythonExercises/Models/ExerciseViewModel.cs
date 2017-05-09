namespace PythonExercises.Models
{
    public class ExerciseViewModel
    {
        public ExerciseViewModel(Exercise exercise, int count)
        {
            Exercise = exercise;
            Count = count;
        }

        public Exercise Exercise { get; set; }
        public int Count { get; set; }
    }
}