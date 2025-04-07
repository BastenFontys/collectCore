namespace collectCore.Models
{
    public class Item
    {
        private long itemID;

        public long ItemID
        {
            get { return itemID; }
            set
            {
                itemID = value;
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }


        private float itemValue;

        public float ItemValue
        {
            get { return itemValue; }
            set
            {
                itemValue = value;
            }
        }


        private string category;

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
            }
        }
    }
}
