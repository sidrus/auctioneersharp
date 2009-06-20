//-----------------------------------------------------------------------
// <copyright file="Flags.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Brandon Frie</author>
// <date>6/19/2009</date>
// <summary>
//      Auction scan status flags for Auctioneer records.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;

    /// <summary>
    /// Auction scan status flags for Auctioneer records.
    /// </summary>
    [FlagsAttribute()]
    public enum Flags
    {
        /// <summary>
        /// Indicates no flag has been set.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that the auction has changed.
        /// </summary>
        Dirty = 1,

        /// <summary>
        /// Indicates that this auction was previously unseen.
        /// </summary>
        Unseen = 2,

        /// <summary>
        /// Unknown flag.
        /// </summary>
        Filter = 4,
    }
}
