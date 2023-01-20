using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FPIMusicUWP.Helpers
{
    public class NBSongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter is int number)
            {
                if (number == 1)
                    return "Une seule morceau";
                else if (number == 0)
                    return "Aucun morceau";
                else
                    return $"{number} morceaux";
            }
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
