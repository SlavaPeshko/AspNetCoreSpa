using System;
using AspNetCoreSpa.Application.Helpers;
using NUnit.Framework;

namespace AspNetCoreSpa.Tests.Unit.Helpers
{
    [TestFixture]
    [Category("country")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class PasswordHasherTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void GetHashPasswordIfNullOrEmpty(string data)
        {
            Assert.Throws<ArgumentNullException>(() => PasswordHasher.GetHashPassword(data));
        }

        [Test]
        [TestCase("123456aA!")]
        [TestCase("avc!")]
        [TestCase("%429gnt56")]
        public void GetHashPassword_Should_Be_String(string data)
        {
            Assert.IsInstanceOf<string>(PasswordHasher.GetHashPassword(data));
        }

        [Test]
        [TestCase("123456aA!")]
        [TestCase("avc!")]
        [TestCase("%429gnt56")]
        public void GetHashPassword_IsNotNullOrEmpty(string data)
        {
            var result = PasswordHasher.GetHashPassword(data);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        [TestCase("123456aA!")]
        [TestCase("avc!")]
        [TestCase("%429gnt56")]
        public void GetHashPassword_Count(string data)
        {
            var actual = PasswordHasher.GetHashPassword(data).Length;

            Assert.AreEqual(actual, 68);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("", null)]
        public void VerifyHashedPassword_IsNullOrEmpry(string intput1, string intput2)
        {
            Assert.Throws<ArgumentNullException>(() => PasswordHasher.VerifyHashedPassword(intput1, intput2));
        }

        [Test]
        [TestCase("123456aA!")]
        [TestCase("avc!")]
        [TestCase("%429gnt56")]
        public void VerifyHashedPassword_IsTrue(string data)
        {
            var hash = PasswordHasher.GetHashPassword(data);

            Assert.IsTrue(PasswordHasher.VerifyHashedPassword(hash, data));
        }
    }
}