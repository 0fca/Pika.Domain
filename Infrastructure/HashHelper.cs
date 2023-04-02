using System.Security.Cryptography;

namespace Pika.Domain.Infrastructure;

public static class HashHelper
{
    internal static string HashUtf8Bytes(byte[] utf8Bytes)
    {
        using var sha256 = SHA256.Create();
        var secretHash = sha256.ComputeHash(utf8Bytes);
        return Convert.ToHexString(secretHash);
    } 
}