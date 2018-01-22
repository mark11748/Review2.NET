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
            testReview.Author = "testAuthor1";
            Assert.AreEqual("testAuthor1", testReview.Author);
        }
        [TestMethod]
        public void GetComment()
        {
            var testReview = new Review();
            testReview.Comment = "testComment2";
            Assert.AreEqual("testComment2", testReview.Comment);
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
