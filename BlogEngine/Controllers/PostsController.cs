using BlogEngine.DAL;
using BlogEngine.Interfaces;
using BlogEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using System.Reflection;

namespace BlogEngine.Controllers
{
    public class PostsController : Controller
    {

        public IPostQuery GetPostQuery()
        {
            //USING NINJECT TO IMPLEMENT DEPENDENCY INJECTION
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel.Get<IPostQuery>();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Post getPost(int id)
        {
            return GetPostQuery().getPost(id);
        }

        [HttpGet]
        public List<Post> getPosts()
        {
            return GetPostQuery().getPosts();
        }

        [HttpPost]
        public void addPost(Post post)
        {
            GetPostQuery().addPost(post);
        }

        [HttpPut]
        public void updatePost(Post post)
        {
            GetPostQuery().updatePost(post);
        }

        [HttpDelete]
        public void deletePost(int id)
        {
            GetPostQuery().removePost(id);
        }
    }
}
