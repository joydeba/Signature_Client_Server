using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FormatterDeformatter
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class SignatueFormatterDeformatter
	{
		string _hashfn;
		AsymmetricAlgorithm _alg;
		public SignatueFormatterDeformatter(string hashfn,AsymmetricAlgorithm alg)
		{
			_hashfn = hashfn;
			_alg = alg;
		}

		public byte[] Sign(string message)
		{
			DSASignatureFormatter dsfm = new DSASignatureFormatter(_alg);
			dsfm.SetHashAlgorithm(_hashfn);
			Byte[] messagebyte = new UnicodeEncoding().GetBytes(message);
			Byte[] hash = HashAlgorithm.Create(_hashfn).ComputeHash(messagebyte);
			return dsfm.CreateSignature(hash);
		}

		public bool Verify(string message, byte[] signature)
		{
			DSASignatureDeformatter dsdfm = new DSASignatureDeformatter(_alg);
			dsdfm.SetHashAlgorithm(_hashfn);
			Byte[] messagebyte = new UnicodeEncoding().GetBytes(message);
			Byte[] hash = HashAlgorithm.Create(_hashfn).ComputeHash(messagebyte);
			return dsdfm.VerifySignature(hash,signature);
		}

	}

	class KeyExchangeFormatterDeformatter
	{
		AsymmetricAlgorithm _alg;
		public KeyExchangeFormatterDeformatter(AsymmetricAlgorithm alg)
		{
			_alg = alg;
		}

		public byte[] CreateEnvelope(string secretkey)
		{
			RSAPKCS1KeyExchangeFormatter  kefm = new RSAPKCS1KeyExchangeFormatter (_alg);
			Byte[] secretkeybyte = new UnicodeEncoding().GetBytes(secretkey);
			return kefm.CreateKeyExchange(secretkeybyte);
		}

		public string GetSecretKey(byte[] envelope)
		{
			RSAPKCS1KeyExchangeDeformatter  kedfm = new RSAPKCS1KeyExchangeDeformatter (_alg);
			Byte[] secretkeybyte = kedfm.DecryptKeyExchange(envelope);
			return new UnicodeEncoding().GetString(secretkeybyte);
		}

	}

	class TestFormatterDeformatter
	 {
		 /// <summary>
		 /// The main entry point for the application.
		 /// </summary>
		 [STAThread]
		 static void Main(string[] args)
		 {
			SignatueFormatterDeformatter sigfd = new SignatueFormatterDeformatter("SHA1",AsymmetricAlgorithm.Create("DSA"));
			string message = "this is a test message";
			byte[] sign = sigfd.Sign(message);
			bool fVerified = sigfd.Verify(message,sign);

			KeyExchangeFormatterDeformatter kefd = new KeyExchangeFormatterDeformatter(AsymmetricAlgorithm.Create("RSA"));
			 string secretkey = "secretkey"; //In real applications this should be a symmetric key
			 byte[] envelope = kefd.CreateEnvelope(secretkey);
			 string secretkey2 = kefd.GetSecretKey(envelope);
			 bool fSame = secretkey == secretkey2;
		 }
	 }
}

