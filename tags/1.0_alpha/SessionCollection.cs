//-----------------------------------------------------------------------
// <copyright file="SessionCollection.cs" company="Ejafi Software">
//      Copyright (c) Ejafi Software. All Rights Reserved.
// </copyright>
// <author>Brandon Frie</author>
// <date>6/17/2009</date>
// <summary>
//      A collection of AuctionItems.
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
    /// A collection of AuctionItems.
    /// </summary>
    public class SessionCollection : Collection<AuctionItem>
    {
        /// <summary>
        /// The raw lua data for this session.
        /// </summary>
        private LuaTable sessionTable;

        /// <summary>
        /// Initializes a new instance of the SessionCollection class using
        /// the data provided.
        /// </summary>
        /// <param name="rope">
        /// A string to be parsed by the lua interpreter which contains a
        /// table of data.
        /// </param>
        public SessionCollection(string rope) :
            base(new List<AuctionItem>())
        {
            object[] tmp = ScanData.LuaEngine.DoString(rope);

            if (tmp.Length > 0) {
                this.sessionTable = tmp[0] as LuaTable;
                foreach (DictionaryEntry item in this.sessionTable) {
                    this.Add(new AuctionItem(item.Value as LuaTable));
                }
            }
        }
    }
}
