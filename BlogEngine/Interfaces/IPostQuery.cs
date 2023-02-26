using BlogEngine.Models;

namespace BlogEngine.Interfaces
{
    public interface IPostQuery
    {
        public Post getPost(int id);
        public List<Post> getPosts();
        public void addPost(Post post);
        public void removePost(int id);
        public void updatePost(Post post);
    }
}
