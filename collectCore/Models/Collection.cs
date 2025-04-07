namespace collectCore.Models
{
    public class Collection
    {
        private long collection_ID;

        public long Collection_ID
        {
            get { return collection_ID; }
            set
            {
                collection_ID = value;
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
