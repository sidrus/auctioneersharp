/*
 * Created by SharpDevelop.
 * User: Brandon
 * Date: 6/17/2009
 * Time: 10:18 PM
 */
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

namespace AuctioneerSharp
{
    public class ScanStatistics : List<ScanStatisticItem>
    {
        private LuaTable statistics;

        public ScanStatistics(LuaTable stats)
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
