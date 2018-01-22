using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Review2_NET.Models;

namespace Review2_NET.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void GetAuthor()
        {
            var testReview = new Review();
            testReview.Author = "test1";
            Assert.AreEqual("test1", testReview.Author);
        }
        [TestMethod]
        public void GetComment()
        {
            var testReview = new Review();
            testReview.Comment = "test2";
            Assert.AreEqual("test2", testReview.Comment);
        }
        [TestMethod]
        public void GetRating()
        {
            var testReview = new Review();
            testReview.Rating = 3;
            Assert.AreEqual(3, testReview.Rating);
        }
    }
}
