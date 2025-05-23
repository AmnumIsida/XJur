namespace XAlgiz.Security;

public static class JwtSettings
{
    public static readonly byte[] Key = SecureRandomBytes.TokenBytes(64);
}