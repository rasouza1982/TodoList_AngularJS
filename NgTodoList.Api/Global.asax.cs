using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using NgTodoList.Data.Context;

namespace NgTodoList.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["_EntityContext"] = new NgTodoListDataContext();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var entityContext = HttpContext.Current.Items["_EntityContext"] as NgTodoListDataContext;
            if (entityContext != null)
                entityContext.Dispose();
        }
    }
}
