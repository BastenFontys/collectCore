namespace collectCore.Models
{
    public class User
    {
        private long userID;

        public long UserID
        {
            get { return userID; }
            set
            {
                userID = value;
            }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }


        private string adressStreet;

        public string AdressStreet
        {
            get { return adressStreet; }
            set
            {
                adressStreet = value;
            }
        }


        private int adressNumber;

        public int AdressNumber
        {
            get { return adressNumber; }
            set
            {
                adressNumber = value;
            }
        }


        private string biography;

        public string Biography
        {
            get { return biography; }
            set
            {
                biography = value;
            }
        }
    }
}
