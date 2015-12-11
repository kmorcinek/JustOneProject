using System.Drawing;

namespace JustOneProject.VariousStuff
{
    public class DoNotUseDefaultParameters
    {
        // ..._screenService whatever

        //public void DrawShape(Rectangle rectangle, Image image, double heightRatio = 0.0D)
        //{
        //    if (heightRatio == 0.0D)
        //    {
        //        heightRatio = _screenService.DefaultHeightRatio;
        //    } 

        //    // ...
        //} 

        //public void DrawShapeBetter(Rectangle rectangle, Image image, double heightRatio)
        //{
        //    DrawShapeBetterInternal(rectangle, image, heightRatio);
        //}

        //public void DrawShapeBetter(Rectangle rectangle, Image image)
        //{
        //    var heightRatio = _screenService.DefaultHeightRatio;
            
        //    DrawShapeBetterInternal(rectangle, image, heightRatio);
        //}

        //private void DrawShapeBetterInternal(Rectangle rectangle, Image image, double heightRatio)
        //{
        //    // ...
        //}
    }
}