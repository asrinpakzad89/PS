using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CMMSAPP.Common.Utilities;

public static class ImageProcessor
{
    public static async Task CropAndSaveImageAsync(string originalImagePath, string newImageName, int width, int height)
    {
        try
        {
            using (var image = Image.Load<Rgba32>(originalImagePath))
            {
                //var size = image.Size;
                //var l = width / 4;
                //var t = size.Height / 4;
                //var r = 3 * (size.Width / 4);
                //var b = 3 * (size.Height / 4);

                //image.Mutate(x => x.Crop(Rectangle.FromLTRB(l, t, r, b)));
                //image.Mutate(x => x.Crop(width, height));
                image.Mutate(x => x
                   .AutoOrient() // this is the important thing that needed adding
                   .Resize(new ResizeOptions
                   {
                       Mode = ResizeMode.Crop,
                       Position = AnchorPositionMode.Center,
                       Size = new Size(width, height)
                   }));


                // Get the directory of the original image
                var directory = Path.GetDirectoryName(originalImagePath);

                // Generate the new image path
                var newImagePath = Path.Combine(directory, newImageName);

                // Save the resized image with the new name
                await using (var outputStream = new FileStream(newImagePath, FileMode.Create))
                {
                    image.SaveAsPng(outputStream);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, log or return appropriate error message
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public static async Task ResizeAndSaveImageAsync(string originalImagePath, string newImageName, int width, int height)
    {
        try
        {
            using (var image = Image.Load(originalImagePath))
            {
                // Resize the image
                image.Mutate(x => x.Resize(width, height));

                // Get the directory of the original image
                var directory = Path.GetDirectoryName(originalImagePath);

                // Generate the new image path
                var newImagePath = Path.Combine(directory, newImageName);

                // Save the resized image with the new name
                await using (var outputStream = new FileStream(newImagePath, FileMode.Create))
                {
                    image.SaveAsPng(outputStream);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, log or return appropriate error message
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}