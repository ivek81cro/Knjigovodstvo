using Microsoft.VisualStudio.TestTools.UnitTesting;
using Knjigovodstvo.Code.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Code.Validators.Tests
{
    [TestClass()]
    public class OibValidatorTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            OibValidator o = new OibValidator();
            Assert.IsFalse(o.Validate("1111111111"));
            Assert.IsFalse(o.Validate("1111111111a"));
            Assert.IsTrue(o.Validate("11111111111"));
        }
    }
}