using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PythonExercises.Models;

namespace PythonExercises.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExercisesService exercisesService;

        public ExercisesController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        public ActionResult Index()
        {
            var exercises = exercisesService.Exercises;

            return View(exercises);
        }

        public ActionResult Show(int id)
        {
            Exercise exercise = exercisesService.GetExercise(id);
            var viewModel = new ExerciseViewModel(exercise, exercisesService.Count);

            return View(viewModel);
        }
    }
}