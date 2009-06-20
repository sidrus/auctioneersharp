//-----------------------------------------------------------------------
// <copyright file="AuctionItemTest.cs" company="Ejafi Software">
//    Copyright (c) Ejafi Software. All Rights Reserved.
// </copyright>
// <author>Brandon</author>
// <date>6/20/2009</date>
// <summary>
//      A unit test for the AuctionItem class
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp.UnitTests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using NUnit.Framework;
    using LuaInterface;

    [TestFixture]
    public class AuctionItemTest
    {
        private static Lua parser = new Lua();
        
        [Test]
        public void ConstructionTest()
        {
            string data = File.ReadAllText("UnitTests\\data\\test_data.lua");
            Debug.WriteLine(String.Format("AuctionItemTest data: {0}", data));
            Assert.NotNull(data);
            
            object[] results = parser.DoString(data);
            Assert.NotNull(results);
            Assert.True(results.Length > 0);
            
            if (results.Length > 0) {
                
            }
        }
    }
}
