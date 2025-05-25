using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreDAL.DTO
{
    public class PostDTO
    {
        public int PostID { get; set; }

        public byte[] ImageData { get; set; }

        public string MimeType { get; set; }

        public string Caption { get; set; }

        public DateOnly DatePosted { get; set; }
    }
}
