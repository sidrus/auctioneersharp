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
    public class AuctioneerSharpTests
    {        
        [Test]
        public void TestScanData()
        {            
            using(ScanData sd = new ScanData("UnitTests\\data\\Auc-ScanData.lua")) {
                Assert.NotNull(sd);
                Assert.NotNull(sd.DataFilePath);
                
                sd.AccountName = "Test Name";
                Assert.NotNull(sd.AccountName);
                
                string[] realms = sd.GetRealmInfo();
                Assert.NotNull(realms);
                Assert.True(realms.Length == 2);    // Icecrown and Baelgun
                Assert.True(realms[0].Equals("Icecrown"));
                Assert.True(realms[1].Equals("Baelgun"));
                
                string[] factions = sd.GetFactionInfo("Icecrown");
                Assert.NotNull(factions);
                Assert.True(factions.Length == 2);  // Alliance and Horde
                Assert.True(factions[0].Equals("Horde"), "Testing for Horde");
                Assert.True(factions[1].Equals("Alliance"), "Testing for Alliance");
                
                ScanImage si = sd.GetImage("Icecrown", "Alliance");
                Assert.NotNull(si);
                Assert.NotNull(si.Faction);
                Assert.NotNull(si.ServerName);
                Assert.NotNull(si.Sessions);
                Assert.NotNull(si.Statistics);
                
                foreach (ScanStatisticItem ssi in si.Statistics) {
                    Assert.NotNull(ssi.CurrentCount);
                    Assert.NotNull(ssi.EarlyDeleteCount);
                    Assert.NotNull(ssi.Elapsed);
                    Assert.NotNull(ssi.Ended);
                    Assert.NotNull(ssi.EndTime);
                    Assert.NotNull(ssi.ExpiredDeleteCount);
                    Assert.NotNull(ssi.MissedCount);
                    Assert.NotNull(ssi.NewCount);
                    Assert.NotNull(ssi.OldCount);
                    Assert.NotNull(ssi.Paused);
                    Assert.NotNull(ssi.SameCount);
                    Assert.NotNull(ssi.Started);
                    Assert.NotNull(ssi.StartTime);
                    Assert.NotNull(ssi.UpdateCount);
                    Assert.NotNull(ssi.WasIncomplete);
                }
                
                foreach (SessionCollection sc in si.Sessions) {
                    foreach (AuctionItem ai in sc) {
                        Assert.NotNull(ai.EquipmentSlot);
                        Assert.NotNull(ai.ItemLevel);
                        Assert.NotNull(ai.ItemType);
                        Assert.NotNull(ai.ItemWowLink);
                        Assert.NotNull(ai.Name);
                        Assert.NotNull(ai.Subtype);
                    }
                }
            }
        }
    }
}
