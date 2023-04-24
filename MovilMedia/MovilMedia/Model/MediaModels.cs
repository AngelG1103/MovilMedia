using System;
using System.Collections.Generic;
using System.Text;
using MovilMedia.Movil;
using Xamarin.Forms;

namespace MovilMedia.Models
{
    public class MediaModels
    {
        public Guid MediaID { get; set; }
        public string Path { get; set; }
        public DateTime LocalDataTime { get; set; }

        private FileImageSource source = null;
        public FileImageSource Source => source ?? (source = new FileImageSource() { File = Path });
    }
}
