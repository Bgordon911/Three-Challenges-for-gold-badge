using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BadgeRepo;
using System.Collections.Generic;

namespace UnitTestProjectBadge
{
    [TestClass]
    public class UnitTest1
    {
        protected BadRepository _badRepository;
        protected Badge _badge;
        [TestMethod]
        public void TestToAddBadgeToDictionary()
        {     //Arrange
            _badge = new Badge();
            _badRepository = new BadRepository();
            
            Assert.IsTrue(_badRepository.AddToDictionary(_badge));//Act
        }
        [TestMethod]
       public void TestToGetBadge()
        {
            List<Badge> listofbadges = _badRepository.GetBadges();
            Assert.IsTrue(listofbadges.Count > 0);
        }
        [TestInitialize]
        public void Arrange()
        {
            _badge = new Badge();
            _badRepository = new BadRepository();
            _badRepository.AddToDictionary(_badge);
        }
            
    }
}
    

