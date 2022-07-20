using System;
using System.Linq;

namespace KevinZonda.Extension.EncodingHelper;

public class Base64Encoding
{
    public static string GetString(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
}
