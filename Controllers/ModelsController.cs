using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    //Controller para teste da Models Aluno com DataAnnotations
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            var aluno = new Aluno();

            if(TryValidateModel(aluno))
            {
                return View();
            }

            var ms = ModelState;

            var erros = ModelState.Select(x => x.Value.Errors)
                                    .Where(y => y.Count > 0)
                                    .ToList();

            erros.ForEach(r => Console.WriteLine(r.First().ErrorMessage));

            return View();
        }
    }
}
