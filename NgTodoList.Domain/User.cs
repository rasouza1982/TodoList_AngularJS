using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NgTodoList.Utils.Security;

namespace NgTodoList.Domain
{
    public class User
    {
        private IList<Todo> _todos;

        protected User() { }

        public User(string name, string email, string password)
        {
            if (name.Length < 3)
                throw new Exception("Nome inválido!");

            if (!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido!");

            if (password.Length < 6)
                throw new Exception("Senha inválida!");

            this.Id = 0;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.IsActive = true;
            this._todos = new List<Todo>();
            this.Todos = new List<Todo>();

        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public bool IsActive { get; protected set; }
        public virtual ICollection<Todo> Todos
        {
            get { return _todos; }
            protected set { _todos = new List<Todo>(value); }
        }


        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            if (!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido!");

            if (password.Length < 6)
                throw new Exception("Senha inválida!");

            if (!(this.Email.ToLower() == email.ToLower()) && !(this.Password == password))
                throw new Exception("Usuário ou senha inválidos!");

            if (newPassword != confirmNewPassword)
                throw new Exception("As senhas digitadas não conferem!");

            if (newPassword.Length < 6)
                throw new Exception("A nova senha é inválida!");

            var pass = EncryptHelper.Encrypt(newPassword);
            this.Password = pass;

        }

        public string ResetPassword(string email)
        {
            if (!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido!");

            var password = System.Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = EncryptHelper.Encrypt(password);

            return password;
        }

        public void Authenticate(string email, string password)
        {
            if (!this.IsActive)
                throw new Exception("Usuário inativo!");

            if (!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido!");

            var pass = EncryptHelper.Encrypt(password);

            if (!(this.Email.ToLower() == email.ToLower()) && !(this.Password == pass))
                throw new Exception("Usuário ou senha inválidos!");
        }

        public void UpdateInfo(string name)
        {
            if (name.Length < 3)
                throw new Exception("Nome inválido!");

            this.Name = name;
        }

        //public void SyncTodos(IList<Todo> todos)
        //{
        //    Contract.Requires<Exception>(todos != null, "Lista de tarefas inválida");

        //    this._todos = new List<Todo>();

        //    foreach (var item in todos)
        //    {
        //        var todo = new Todo(item.Title, this.Id);
        //        this._todos.Add(todo);
        //    }
        //}

        public void ClearTodos()
        {
            this._todos = new List<Todo>();
        }

        public void Inactivate()
        {
            this.IsActive = false;
        }

        public void Activate()
        {
            this.IsActive = true;
        }
    }
}