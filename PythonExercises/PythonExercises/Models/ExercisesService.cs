using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
using PythonExercises.Properties;

namespace PythonExercises.Models
{
    public interface IExercisesService
    {
        IEnumerable<Exercise> Exercises { get; }
        int Count { get; }
        Exercise GetExercise(int id);
    }

    public class ExercisesService : IExercisesService
    {
        public ExercisesService()
        {
            Exercises = GetExercises();
            Count = Exercises.Count();
        }

        public IEnumerable<Exercise> Exercises { get; }

        public int Count { get; }

        public Exercise GetExercise(int id)
        {
            return Exercises.First(x => x.Id == id);
        }

        protected IEnumerable<Exercise> GetExercises()
        {
            string resource = Resources.PythonCourseFile;
            foreach (string exerciseRaw in resource.Split(new[] { "#----------------------------------------#" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (exerciseRaw.IsNullOrWhiteSpace())
                {
                    continue;
                }

                string[] lines = exerciseRaw.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string[] sections = exerciseRaw.Split(new[] { "Question:", "Hints:", "Solution:" }, StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(lines[0].Trim().Replace(":", "").Split(' ').Last());
                string level = lines[1].Contains("Level") ? lines[1].Last().ToString() : "Unknown";
                string question = sections[1].Trim();
                string hints = sections[2].Trim();
                string solution = sections[3].Trim();

                yield return new Exercise(id, question, hints, solution, level);
            }
        }
    }
}