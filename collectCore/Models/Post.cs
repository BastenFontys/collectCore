namespace collectCore.Models
{
    public class Post
    {
        private long postID;

        public long PostID
        {
            get { return postID; }
            set
            {
                postID = value;
            }
        }


        private string caption;

        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
            }
        }


        private DateTime datePosted;

        public DateTime DatePosted
        {
            get { return datePosted; }
            set
            {
                datePosted = value;
            }
        }
    }
}
