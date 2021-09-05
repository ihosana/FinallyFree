using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabalho._2.Models;


namespace Trabalho._2.Controllers
{
    public class ViagemController : Controller
    {
           public IActionResult Listapacote()
        {

            ViagemBanco usr = new ViagemBanco();
            List<Viagem> viagems= usr.Query();
            
                   return View(viagems);   
        }
         public IActionResult CadastroPacotes()
        {  
                  return View();
        }

      [HttpPost]
       public IActionResult CadastroPacotes(Viagem V)
       {
             ViagemBanco viagem= new ViagemBanco();
                if(HttpContext.Session.GetInt32("IDUsuario")==null){
                   ViewBag.Mensagem="Se cadastre no site primeiro";
                 return View();
             }
             else{
        
           viagem.Insert(V, (int) HttpContext.Session.GetInt32("IDUsuario"));
           ViewBag.Mensagem="Pacote cadastrado";
           return RedirectToAction("Listapacote");
             }
          
       }
     
                public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();       
        }
          public IActionResult Excluir(int IDProduto)
        {    
            ViagemBanco viagem= new ViagemBanco();
            viagem.Excluir(IDProduto);
            return RedirectToAction("Listapacote");
            
        }
    }

}

/*
        [HttpPost]
        public IActionResult CadastroPacotes(Viagem novo)
        {
             if(HttpContext.Session.GetInt32("nomePacote")==null)
            return View();
            else{
            ViagemBanco use = new ViagemBanco();
            use.Insert(novo,(int) HttpContext.Session.GetInt32
            ("IDUsuario"));
            ViewBag.Mensagem = "Pacote Cadastrado com sucesso";
            return View("Listapacote");
            }

        }


    }
}

        [HttpPost]
        public IActionResult CadastroPacotes(Compra novo)
        { 
             if(HttpContext.Session.GetInt32("IDUsuario")==null)
            return RedirectToAction("Cadastro","Home");
            CompraBanco use = new CompraBanco();

            use.Insert(novo,(int) HttpContext.Session.GetInt32
            ("IDUsuario"));
            ViewBag.Mensagem = "Pacote Cadastrado com sucesso";
            return View();
        }
        public IActionResult listapacote(){
           if(HttpContext.Session.GetInt32("IDUsuario")==null)
            return RedirectToAction("Cadastro","Home");
            CompraBanco ur = new CompraBanco();
            List<Compra> lista = ur.Query();
            
                   return View(lista );   
        }
    } 
}     
*/
