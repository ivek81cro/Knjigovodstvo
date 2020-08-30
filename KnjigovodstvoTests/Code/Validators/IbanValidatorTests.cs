﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Knjigovodstvo.Code.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Code.Validators.Tests
{
    [TestClass()]
    public class IbanValidatorTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            IbanValidator v = new IbanValidator();
            Assert.IsFalse(v.Validate("222223600001111111111"));
            Assert.IsFalse(v.Validate("HR223600001111111111"));
            Assert.IsTrue(v.Validate("HR2223600001111111111"));
        }
    }
}