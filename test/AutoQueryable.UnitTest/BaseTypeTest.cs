﻿using System.Linq;
using AutoQueryable.Core.Models;
using AutoQueryable.Extensions;
using AutoQueryable.UnitTest.Mock;
using AutoQueryable.UnitTest.Mock.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AutoQueryable.UnitTest
{
    [TestClass]
    public class BaseTypeTest
    {
        [TestMethod]
        public void SelectAllProducts()
        {
            using (AutoQueryableContext context = new AutoQueryableContext())
            {
                DataInitializer.InitializeSeed(context);
                var query = context.Product.AutoQueryable("", new AutoQueryableProfile {UseBaseType = true});
                IEnumerable<Product> pp = query as IEnumerable<Product>;
                Assert.AreEqual(pp.Count(), DataInitializer.ProductSampleCount);
            }
        }
    }
}