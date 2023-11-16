using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantsBook.Data;
using System;

namespace MyApp.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetSearchResult()
        {
            //Arrange 
            var search = PlantRepository.NameSearch();
        }
    }
}
