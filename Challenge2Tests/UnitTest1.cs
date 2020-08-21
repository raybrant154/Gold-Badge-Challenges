using System;
using System.Collections.Generic;
using Challenges2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge2Tests
{
    [TestClass]
    public class Challenge2UnitTests
    {
        private ClaimRepo _claimRepo;
        private Claim _claimContent;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepo();
            _claimContent = new Claim(1, ClaimType.Home, "House fire", 2300, Convert.ToDateTime(8 / 15 / 2020), Convert.ToDateTime(8 / 20 / 2020), true);

            _claimRepo.AddClaimToList(_claimContent);


        }

        [TestMethod]
        public void GetList_SeeAllClaims()
        {
            ClaimRepo testRepo = new ClaimRepo();
            Claim newClaim = new Claim(1, ClaimType.Home, "House fire", 2300, Convert.ToDateTime(8 / 15 / 2020), Convert.ToDateTime(8 / 20 / 2020), true);
            testRepo.AddClaimToList(newClaim);

            List<Claim> claimList = testRepo.SeeAllClaims();

            bool theClaimList = claimList.Contains(newClaim);

            Assert.IsTrue(theClaimList);
        }
    }
}
