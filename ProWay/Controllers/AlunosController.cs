using Microsoft.AspNetCore.Mvc;
using ProWay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProWay.Controllers
{
    public class AlunosController : Controller
    {
        public IActionResult Index()
        {
            List<Aluno> list = new List<Aluno>();
            list.Add(new Aluno { IdAluno = 1, Nome = "Bruno", Sobrenome = "Marques" });
            list.Add(new Aluno { IdAluno = 2, Nome = "Igor", Sobrenome = "Brandão" });

            return View(list);
        }
    }
}
