using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NgTodoList.Data.Mapping;
using NgTodoList.Domain;

namespace NgTodoList.Data.Context
{
    public class NgTodoListDataContext : DbContext    
    {
        public NgTodoListDataContext() 
            : base("NgTodoListConnectionString")
        {
            //Database.SetInitializer<NgTodoListDataContext>(new NgTodoListDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TodoMap());
            //base.OnModelCreating(modelBuilder);
        }
    }

    //public class NgTodoListDataContextInitializer : DropCreateDatabaseIfModelChanges<NgTodoListDataContext>
    //{
    //    protected override void Seed(NgTodoListDataContext context)
    //    {
    //        base.Seed(context);
    //    }
    //}
}
