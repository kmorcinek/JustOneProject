using System.Linq;

namespace JustOneProject
{
    public class FileUrlsGenerator
    {
        private readonly string[] _fishNames = new[]
            {
                "berit",
                "knut",
                "lars",
                "morten",
                "orjan",
                "silje",
                "sissel",
                "tora"
            };

        public void Run()
        {
            var feed = string.Join("", _fishNames.Select(GenerateImgFeed));
            var viewFeed = GenerateViewFeed();
            var slideshow = string.Join("", _fishNames.Select(GenerateImgSlideshow));
        }

        private static string GenerateImgFeed(string fish)
        {
            var fishes = Enumerable.Range(1, 9)
                      .Where(n => n != 3)
                      .Select(n => string.Format("{0}{1}.jpg", n, fish));

            var joinedFishes = string.Join(";", fishes);

            return string.Format("<{0} files=\"{1}\"/>", fish, joinedFishes);
        }

        private string GenerateViewFeed()
        {
            var fishes = _fishNames.Select(fish => string.Format("feed_{0}.ejs", fish));

            var joinedFishes = string.Join(";", fishes);

            return string.Format("<feed files=\"{0}\"/>", joinedFishes);
        }

        private static string GenerateImgSlideshow(string fish)
        {
            var fishes = Enumerable.Range(1, 9)
                      .Select(n => string.Format("{0}.jpg", n));

            var joinedFishes = string.Join(";", fishes);
            return string.Format("<{0} files=\"{1}\"/>", fish, joinedFishes);
        }
    }
}