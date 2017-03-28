using System.Configuration;
using Host.Request;
using Presentation.Request;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Host.App_Start.AppHost), "Start")]

namespace Host.App_Start
{
	public class AppHost : AppHostBase
	{		
		public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("Mancation", typeof(UserRequest).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

			//Uncomment to change the default ServiceStack configuration
            //SetConfig(new HostConfig {
            //});

			//Enable Authentication
			//ConfigureAuth(container);

			//Register all your dependencies
			//container.Register(new TodoRepository());			
		}

		/* Example ServiceStack Authentication and CustomUserSession */
		private void ConfigureAuth(Funq.Container container)
		{
			var appSettings = new AppSettings();

			//Default route: /auth/{provider}
			Plugins.Add(new AuthFeature(() => new CustomUserSession(),
				new IAuthProvider[] {
					new CredentialsAuthProvider(appSettings), 
					new FacebookAuthProvider(appSettings), 
					new TwitterAuthProvider(appSettings), 
					new BasicAuthProvider(appSettings), 
				})); 

			//Default route: /register
			Plugins.Add(new RegistrationFeature()); 

			//Requires ConnectionString configured in Web.Config
			var connectionString = ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
			container.Register<IDbConnectionFactory>(c =>
				new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider));

			container.Register<IUserAuthRepository>(c =>
				new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

            container.Resolve<IUserAuthRepository>().InitSchema();
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}
