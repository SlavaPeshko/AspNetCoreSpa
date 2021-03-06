﻿using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AspNetCoreSpa.Application.Helpers
{
    public static class PasswordHasher
    {
        private const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1;
        private const int Pbkdf2IterCount = 1000;
        private const int Pbkdf2SubkeyLength = 256 / 8;
        private const int SaltSize = 128 / 8;
        private static readonly RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public static string GetHashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            return Convert.ToBase64String(GenerateHashPassword(password));
        }

        public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword)) throw new ArgumentNullException(nameof(hashedPassword));
            if (string.IsNullOrEmpty(providedPassword)) throw new ArgumentNullException(nameof(providedPassword));

            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            if (decodedHashedPassword.Length == 0) return false;

            return VerifyHashedPassword(decodedHashedPassword, providedPassword);
        }

        private static byte[] GenerateHashPassword(string password)
        {
            // Produce a version 2 text hash.
            var salt = new byte[SaltSize];
            rngCsp.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
            outputBytes[0] = 0x00; // format marker
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);
            return outputBytes;
        }

        private static bool VerifyHashedPassword(byte[] hashedPassword, string password)
        {
            // We know ahead of time the exact length of a valid hashed password payload.
            if (hashedPassword.Length != 1 + SaltSize + Pbkdf2SubkeyLength) return false; // bad size

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPassword, 1, salt, 0, salt.Length);

            var expectedSubkey = new byte[Pbkdf2SubkeyLength];
            Buffer.BlockCopy(hashedPassword, 1 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            // Hash the incoming password and verify it
            var actualSubkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);
            return ByteArraysEqual(actualSubkey, expectedSubkey);
        }

        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null || a.Length != b.Length) return false;
            var areSame = true;
            for (var i = 0; i < a.Length; i++) areSame &= a[i] == b[i];
            return areSame;
        }
    }
}