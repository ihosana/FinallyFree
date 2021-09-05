using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabalho._2.Models;

namespace Trabalho._2.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioBancodeDados use = new UsuarioBancodeDados();
            if (use != null)
            {
                use.Insert(u);
                ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
                return View("Privado");
            }
            else
            {
                ViewBag.Mensagem = "Erro no cadastro";
                return View();
            }
        }


        public IActionResult Lista()
        {
            UsuarioBancodeDados ur = new UsuarioBancodeDados();
            List<Usuario> usuarios = ur.Query();

            return View(usuarios);

        }

        public IActionResult Privado()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            UsuarioBancodeDados ubd = new UsuarioBancodeDados();
            Usuario pessoa = ubd.QueryLogin(u);
            if (pessoa != null)
            {
                ViewBag.Mensagem = "Logado";
                HttpContext.Session.SetInt32("IDUsuario", u.id);
                HttpContext.Session.SetString("loginUsuario", u.login);
                return RedirectToAction("Lista");
            }
            else
            {
                ViewBag.Mensagem = "erro no login";
                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public IActionResult Editar(int id)
        {
            UsuarioBancodeDados usuarioBanco = new UsuarioBancodeDados();
            Usuario usuario = usuarioBanco.buscar(id);
            return View(usuario);

        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {

            UsuarioBancodeDados usuarioBanco = new UsuarioBancodeDados();
            usuarioBanco.atualizar(usuario);
            ViewBag.Message = " Sucesso na atualização! ";
            return RedirectToAction("Lista");
        }

        public IActionResult Excluir(int id)
        {
           
            UsuarioBancodeDados usuarioBanco = new UsuarioBancodeDados();
            usuarioBanco.Excluir(id);
            return RedirectToAction("Lista");
        }
            public IActionResult work()
        {
            return View();
        }
           [HttpPost]
           public IActionResult work(Usuario u)
        {
            UsuarioBancodeDados use = new UsuarioBancodeDados();
      
                use.Insert(u);
                ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
                return View("Lista");
        


        }
    }
}