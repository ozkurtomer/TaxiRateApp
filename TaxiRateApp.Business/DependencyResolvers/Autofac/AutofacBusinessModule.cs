using Autofac;
using Castle.DynamicProxy;
using Autofac.Extras.DynamicProxy;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Core.Utilities.Interceptors;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostsManager>().As<IPostsService>().SingleInstance();
            builder.RegisterType<EfPostsDal>().As<IPostsDal>().SingleInstance();
            
            builder.RegisterType<CommentsManager>().As<ICommentsService>().SingleInstance();
            builder.RegisterType<EfCommentsDal>().As<ICommentsDal>().SingleInstance();
            
            builder.RegisterType<UsersManager>().As<IUsersService>().SingleInstance();
            builder.RegisterType<EfUsersDal>().As<IUsersDal>().SingleInstance();

            builder.RegisterType<CitiesManager>().As<ICitiesService>().SingleInstance();
            builder.RegisterType<EfCitiesDal>().As<ICitiesDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
