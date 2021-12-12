using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace ApplicationManga.Converter
{
    class Converter_Image : IValueConverter
    {
        private static string imagesPath;

        static Converter_Image()
        {
            imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\Images\\");
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;
            if (string.IsNullOrWhiteSpace(imageName)) return null;
            string imagePath = Path.Combine(imagesPath, imageName);
            return new Uri(imagePath, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
