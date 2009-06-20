//-----------------------------------------------------------------------
// <copyright file="Session.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Brandon Frie</author>
// <date>6/17/2009</date>
// <summary>
//      A collection of AuctionItems.
// </summary>
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LuaInterface;

namespace AuctioneerSharp
{
    /// <summary>
    /// A collection of AuctionItems.
    /// </summary>
    public class SessionCollection : Collection<AuctionItem>
    {
        private LuaTable sessionTable;

        /// <summary>
        /// Initializes an instance of the SessionCollection class using
        /// the data provided.
        /// </summary>
        /// <param name="rope">
        /// A string to be parsed by the lua interpreter which contains a
        /// table of data.
        /// </param>
        public SessionCollection(string rope) :
            base(new List<AuctionItem>())
        {
            object[] tmp = ScanData.luaEngine.DoString(rope);

            if(tmp.Length>0) {
                this.sessionTable = tmp[0] as LuaTable;
                foreach(DictionaryEntry item in this.sessionTable) {
                    this.Add(new AuctionItem(item.Value as LuaTable));
                }
            }
        }
    }
}
