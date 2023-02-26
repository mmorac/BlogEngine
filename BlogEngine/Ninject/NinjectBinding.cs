using BlogEngine.DAL;
using BlogEngine.Interfaces;
using Ninject.Modules;

namespace BlogEngine.Ninject
{
    public class NinjectBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<IPostQuery>().To<Posts>();
        }
    }
}
