using collectCoreBLL.Models;

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

        public List<Item> Content { get; set; }
    }
}
