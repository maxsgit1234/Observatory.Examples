using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;

namespace Examples
{
    public class Images : IExample
    {
        private string _Title = "Images";
        public string Title { get { return _Title; } }

        private string _Description = "Add images to a plot, either in absolute (pixel) "
            + "coordinates or by specify all 4 corner locations in 3D.";
        public string Description { get { return _Description; } }


        /// <summary>
        /// This method shows how to add images to a 3D plot in Observatory. Images
        /// can be added to any plot, and in 2D plots the functionality available is 
        /// essentially a subset of that in 3D plots.
        /// </summary>
        public void Run()
        {
            // Create the plot:
            Plot3d plot = new Plot3d();

            // Load images from file:
            string dir = LocalConfig.ExampleDataDir;
            ImageSource saturn = BitmapImage.FromFile(
                LocalConfig.GetFilename("Saturn.jpg"));
            ImageSource lena = BitmapImage.FromFile(
                LocalConfig.GetFilename("Lena.png"));

            // This adds the image of Saturn to the plot. By default it is in the XY
            // plane, sized to be one unit/pixel. Overloads given finer control:
            plot.Images.Add3d(saturn);

            // If you want to add the same image at multiple locations, it is most 
            // efficient to do this by re-using the ImageSource object, rather than 
            // re-loading from file, or even supplying the same Bitmap object 
            // multiple times. This command adds the image again in another location 
            // defined by its corner locations explicitly:
            Vector3d ll = new Vector3d(1000, -2000, 500); // lower-left
            Vector3d dx = new Vector3d(1, 0, 0) * saturn.Height * 0.5;
            Vector3d dy = new Vector3d(0, 1, 0) * saturn.Width * 0.5;
            plot.Images3.Add3d(saturn, ll, ll + dy, ll + dx + dy, ll + dx);
            
            // This adds the image of Lena to the plot. The image is anchored in 
            // data coordinates, but always faces the viewer, and has a constant size 
            // (in pixels) regardless of how the view is manipulated:
            plot.Images3.AddFacingCamera(lena,
                new Vector3d(3000, 1200, 300), 
                new Vector2d(lena.Width / 4, lena.Height / 4));

            // This also adds the image of Lena to the screen at a fixed pixel location
            // and size (relative to the upper left):
            plot.Screen.AddImageLiteral(lena, 600, 10,
                (int)lena.Width / 5, (int)lena.Height / 5);

            plot.Axes.SetScaleEquality(true, D3.X, D3.Y);
            plot.Display();
        }
    }
}
