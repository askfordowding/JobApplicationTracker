using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
	private static readonly string Key = "your-32-char-long-key";
	private static readonly string IV = "your-16-char-long-iv";

	static void Main(string[] args)
	{
		string originalConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

		string encrypted = Encrypt(originalConnectionString);
		Console.WriteLine($"Encrypted: {encrypted}");

		string decrypted = Decrypt(encrypted);
		Console.WriteLine($"Decrypted: {decrypted}");
	}

	public static string Encrypt(string plainText)
	{
		using (Aes aesAlg = Aes.Create())
		{
			aesAlg.Key = Encoding.UTF8.GetBytes(Key);
			aesAlg.IV = Encoding.UTF8.GetBytes(IV);

			ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

			using (MemoryStream msEncrypt = new MemoryStream())
			{
				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write(plainText);
					}
					return Convert.ToBase64String(msEncrypt.ToArray());
				}
			}
		}
	}

	public static string Decrypt(string cipherText)
	{
		using (Aes aesAlg = Aes.Create())
		{
			aesAlg.Key = Encoding.UTF8.GetBytes(Key);
			aesAlg.IV = Encoding.UTF8.GetBytes(IV);

			ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

			using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
			{
				using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				{
					using (StreamReader srDecrypt = new StreamReader(csDecrypt))
					{
						return srDecrypt.ReadToEnd();
					}
				}
			}
		}
	}
}
