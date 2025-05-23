using System.Security.Cryptography;

namespace XAlgiz.Security;

public static class SecureRandomBytes
{
    public static byte[] TokenBytes(int n)
    {
        var bytes = new byte[n];
        RandomNumberGenerator.Fill(bytes);
        return bytes;
    }
}