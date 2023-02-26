using BlogEngine.Interfaces;
using BlogEngine.Models;
using Ninject;
using System.Reflection;

namespace BlogEngine.DAL
{
    public class Posts : IPostQuery
    {
        BlogEngineContext context = new BlogEngineContext();
        public Post getPost(int id)
        {
            Post post = context.Posts.Where(p => p.Id == id).FirstOrDefault();
            return post;
        }

        public List<Post> getPosts()
        {
            List<Post> posts = context.Posts.Where(p => p != null).ToList();
            return posts;
        }

        public void addPost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public void removePost(int id)
        {
            //Using an IDisposable to perform the delete task
            using (context) {
                var entity = context.Posts.FirstOrDefault(p => p.Id == id);
                if (entity != null)
                {
                    context.Remove(entity);
                    context.SaveChanges();
                }
            }
        }
        public void updatePost(Post post)
        {
            using (context)
            {
                var entity = context.Posts.FirstOrDefault(p => p.Id == post.Id);
                if(entity != null)
                {
                    entity.Statusid = post.Statusid;
                    entity.Title = post.Title;
                    entity.Content = post.Content;
                    entity.Createdby = post.Createdby;
                    entity.Lastmodifiedby = post.Lastmodifiedby;

                    context.SaveChanges();
                }
            }
        }
    }
}
