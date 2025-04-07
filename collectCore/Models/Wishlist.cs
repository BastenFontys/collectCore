namespace collectCore.Models
{
    public class Wishlist
    {
        private long wishlist_ID;

        public long Wishlist_ID
        {
            get { return wishlist_ID; }
            set
            {
                wishlist_ID = value;
            }
        }

        private List<Item> content;

        public List<Item> Content
        {
            get { return content; }
            set
            {
                content = value;
            }
        }
    }
}
