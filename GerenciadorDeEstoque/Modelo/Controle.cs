﻿using GerenciadorDeEstoque.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoque.Modelo
{
    public class Controle
    {
        public bool verificacao;
        public string mensagem = "";

        // Método para acessar a acc
        public bool Acessar(string login, string senha)
        {
            // Instanciando a classe LoginDaoComandos e checando se o user/password estão corretos
            LoginDaoComandos loginDao = new LoginDaoComandos();
            verificacao = loginDao.VerificarLogin(login, senha);
            
            // Armazenando mensagem de erro
            if (!loginDao.mensagem.Equals(""))
            {
                this.mensagem = loginDao.mensagem;
            }
            return verificacao;
        }


        // Método para cadastrar a acc
        public string Cadastrar(string email, string senha, string confirmarsenha, string celular, string lembretesenha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.Cadastrar(email, senha, confirmarsenha, celular, lembretesenha);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }
    }
}
