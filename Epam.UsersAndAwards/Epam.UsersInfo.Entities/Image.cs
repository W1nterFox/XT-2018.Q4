using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersInfo.Entities
{
    public class Image
    {
        public int ImageId { get; set; }

        public string MimeType { get; set; }

        public string ImageData { get; set; }
    }
}
