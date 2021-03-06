﻿using Sistema_clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_clinica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid) {
                bool usuarioValido = usuario.verificarLogin();
                if (usuarioValido)
                {
                    Session.Add("usuario", usuario.Login);
                    return RedirectToAction("TelaPrincipal", "Home");
                }
                else if(usuario.erro != ""){
                    return View(usuario).Mensagem("Erro com banco de dados! " + usuario.erro);
                }
                else
                {
                    return View(usuario).Mensagem("Usuário e/ou senha incorretos", "Erro");
                }
            }
            return View();
        }

        public ActionResult Deslogar()
        {
            Session.Clear();
            return RedirectToAction("Login").Mensagem("Usuário deslogado com sucesso!", "Sessão encerrada");
        }

        public ActionResult TelaPrincipal()
        {
            if (Session["usuario"] == null || Session["usuario"].ToString() == "")
            {
                return RedirectToAction("Login", "Home").Mensagem("Faça o login para entrar");
            }
            return View();
        }
    }
}