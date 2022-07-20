using System;
using System.Linq;
using System.Text;

namespace KevinZonda.Extension.EncodingHelper;

public class Base64Decoding
{
    public static byte[] GetBytes(string b64Str)
    {
        return Convert.FromBase64String(b64Str);
    }
    public static string GetString(string b64Str)
    {
        return Encoding.UTF8.GetString(GetBytes(b64Str));
    }
}
