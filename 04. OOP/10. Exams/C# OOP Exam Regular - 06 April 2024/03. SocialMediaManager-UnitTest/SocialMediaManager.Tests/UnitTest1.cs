using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SocialMediaManager.Tests
{
    public class Tests
    {

        private InfluencerRepository influencers;

        private Influencer test11 = new Influencer("test11", 11);
        private Influencer test12 = new Influencer("test12", 12);
        private Influencer test13 = new Influencer("test13", 13);

        [SetUp]
        public void Setup()
        {
            influencers = new InfluencerRepository();
        }

        [Test]
        public void RegisterInfluencerIsNullExceptoion()
        {
            Assert.Throws<ArgumentNullException>(() => influencers.RegisterInfluencer(null));
        }

        [Test]
        public void RegisterInfluencerInvalidOperationException()
        {
            Assert.AreEqual($"Successfully added influencer test11 with 11",
                influencers.RegisterInfluencer(test11));

            Assert.Throws<InvalidOperationException>(()
                => influencers.RegisterInfluencer(test11));
        }

        [Test]
        public void ValidRegistration()
        {
            Assert.AreEqual($"Successfully added influencer test11 with 11",
                influencers.RegisterInfluencer(test11));
            Assert.AreEqual(1, influencers.Influencers.Count);
        }

        [Test]
        public void RemoveInfluencerIsNullOrWhiteSpace()
        {
            ArgumentNullException ae = Assert.Throws<ArgumentNullException>(()
                => influencers.RemoveInfluencer(" "));
            Assert.Throws<ArgumentNullException>(()=> influencers.RemoveInfluencer(null));
        }

        [Test]
        public void RemoveInfluencer()
        {
            influencers.RegisterInfluencer(test11);
            Assert.That(influencers.RemoveInfluencer(nameof(test11)), Is.True);
        }

        [Test]
        public void GetInfluencerMostFollowers()
        {
            influencers.RegisterInfluencer(test11);
            influencers.RegisterInfluencer(test12);
            influencers.RegisterInfluencer(test13);

            Assert.AreEqual(test13, influencers.GetInfluencerWithMostFollowers());
        }

        [Test]
        public void GetInfluencer()
        {
            influencers.RegisterInfluencer(test11);
            Assert.AreEqual(test11, influencers.GetInfluencer("test11"));
        }
    }
}