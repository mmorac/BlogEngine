using BlogEngine.Models;

namespace BlogEngine.Interfaces
{
    public interface ICommentQuery
    {
        public Comment getComment(int id);
        public List<Comment> getComments();
        public void addComment(Comment comment);
        public void removeComment(int id);
        public void updateComment(Comment comment);
    }
}
