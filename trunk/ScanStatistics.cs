//-----------------------------------------------------------------------
// <copyright file="ScanStatistics.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Brandon Frie</author>
// <date>6/17/2009</date>
// <summary>
//      A collection of ScanStatisticsItems.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using LuaInterface;
    
    /// <summary>
    /// A collection of ScanStatisticsItems.
    /// </summary>
    public class ScanStatisticsCollection : Collection<ScanStatisticItem>
    {
        private LuaTable statistics;

        /// <summary>
        /// Initializes an instance of the ScanStatisticsCollection class
        /// using the data provided.
        /// </summary>
        /// <param name="stats">A lua table with the initialization data.</param>
        public ScanStatisticsCollection(LuaTable stats) :
            base(new List<ScanStatisticItem>())
        {
            this.statistics = stats;
            if(this.statistics==null)
                return;

            // build the list
            foreach(DictionaryEntry item in statistics)
                this.Add(new ScanStatisticItem(item.Value as LuaTable));
        }
    }
}
