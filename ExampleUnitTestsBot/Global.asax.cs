using Autofac;
using ExampleUnitTestsBot.Dialogs;
using ExampleUnitTestsBot.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ExampleUnitTestsBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Conversation.UpdateContainer(builder =>
            {
                builder.RegisterType<RootDialog>()
                       .InstancePerDependency();

                builder.RegisterType<ChatHelper>()
                        .As<IChatHelper>()
                        .SingleInstance();
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
