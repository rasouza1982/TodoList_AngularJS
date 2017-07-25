using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NgTodoList.Domain.Tests
{
    [TestClass]
    public class Dado_um_novo_usuario
    {
        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_nome_deve_ser_valido()
        {
            var user = new User("", "souza.rafael@gmail.com", "rasouza");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_email_deve_ser_valido()
        {
            var user = new User("rasouza", "teste", "rasouza");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_email_nao_pode_ser_vazio()
        {
            var user = new User("rasouza", "", "rasouza");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void A_senha_deve_ser_valida()
        {
            var user = new User("rasouza", "souza.rafael@gmail.com", "123");
        }


        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        public void O_usuario_e_valido()
        {
            var user = new User("rasouza", "souza.rafael@gmail.com", "rasouza");
            Assert.AreNotEqual(null, user);
        }
    }

    [TestClass]
    public class Ao_alterar_senha
    {
        private User user = new User("Rafael Souza", "souza.rafael@gmail.com", "rasouza");

        [TestMethod]
        [TestCategory("User - Alterar senha")]
        [ExpectedException(typeof(Exception))]
        public void O_email_deve_ser_valido()
        {
            user.ChangePassword("", "rasouza", "rasouza2", "rasouza2");
        }

        [TestMethod]
        [TestCategory("User - Alterar senha")]
        [ExpectedException(typeof(Exception))]
        public void A_nova_senha_deve_ser_valida()
        {
            user.ChangePassword("souza.rafael@gmail.com", "rasouza", "asd", "asd");
        }

        [TestMethod]
        [TestCategory("User - Alterar senha")]
        [ExpectedException(typeof(Exception))]
        public void Usuario_e_senha_devem_ser_validos()
        {
            user.ChangePassword("souza.rafael@gmail.com", "asd", "rasouza2", "rasouza2");
        }

        [TestMethod]
        [TestCategory("User - Alterar senha")]
        [ExpectedException(typeof(Exception))]
        public void A_confirmacao_de_senha_deve_ser_igual_a_nova_senha()
        {
            user.ChangePassword("souza.rafael@gmail.com", "rasouza", "rasouza2", "rasouza3");
        }

        [TestMethod]
        [TestCategory("User - Alterar senha")]
        public void A_senha_deve_ser_encriptada()
        {
            var password = "minhasenhasegura";
            user.ChangePassword("souza.rafael@gmail.com", "rasouza", password, password);
            Assert.AreNotEqual(password, user.Password);
        }
    }

}
