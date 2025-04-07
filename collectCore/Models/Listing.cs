namespace collectCore.Models
{
    public class Listing
    {
        private long listingID;

        public long ListingID
        {
            get { return listingID; }
            set
            {
                listingID = value;
            }
        }


        private float price;

        public float Price
        {
            get { return price; }
            set
            {
                price = value;
            }
        }


        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }
    }
}
