using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DnD_Creator_2._0.AllClasses
{
    public class ImageLoader
    {
        public static void LoadImage(string imageName, Image image)
        {
            //string res = Directory.GetCurrentDirectory().Replace(@"bin\Debug", imageName);
            image.Source = new BitmapImage(new Uri($"/Img1/{imageName}", UriKind.Relative));

        }
    }
}
