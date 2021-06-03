using UnityEngine;

namespace PixelAdventure
{
    public static class StringExtension
    {
        public static string ChangeStringColor(this string str, string _hexColor)
        {
            str = $"<color={_hexColor}>{str}";
            return str;
        }
    }
}
