using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JobApplicationService.Core.Helpers
{
	public static class EncryptionHelper
	{
		private static readonly byte[] Key = Encoding.UTF8.GetBytes("your-32-byte-key-for-aes-encryption"); // 32-byte key for AES
		private static readonly byte[] IV = Encoding.UTF8.GetBytes("your-16-byte-IV"); // 16-byte IV for AES

		public static string Decrypt(string encryptedText)
		{
			using (var aes = Aes.Create())
			{
				aes.Key = Key;
				aes.IV = IV;

				var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
				var cipherBytes = Convert.FromBase64String(encryptedText);

				using (var ms = new MemoryStream(cipherBytes))
				{
					using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						using (var sr = new StreamReader(cs))
						{
							return sr.ReadToEnd();
						}
					}
				}
			}
		}
	}
}
