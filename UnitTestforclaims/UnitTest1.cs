using ClaimsChallenge;
using ClamsChallegeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestforclaims
{
    [TestClass]
    public class ClaimsrepoTest
    {
        private ClaimsRepo _repo;
        private Claim _claims;
        [TestMethod]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claims = new Claim(1, Claim.ClaimType.Car, "Rear-ended", 4000, new DateTime(1999, 07, 01), new DateTime(1999, 07, 21), true);
            _repo.AddClaimToQueue(_claims);
        }
        [TestMethod]
        public void AddToQueue_ShouldNotGetNull()
        {
           
            
            Claim testClaim = new Claim(2, Claim.ClaimType.Car, "Rear-ended", 4000, new DateTime(1999, 07, 01), new DateTime(1999, 07, 21), true);
            ClaimsRepo repository = new ClaimsRepo();
            Queue<Claim> testQueue = repository.GetClaims();
            int test = testQueue.Count();
            repository.AddClaimToQueue(testClaim);
            Queue<Claim> testQueue2 = repository.GetClaims();
            int test2 = testQueue2.Count();
            Assert.IsTrue(test < test2);
        }

    }
}
