//-----------------------------------------------------------------------
// <copyright file="AuctionItemFields.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Brandon Frie</author>
// <date>6/18/2009</date>
// <summary>
//      Defines an individual item in an Auctioneer scan image.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;
    
    /// <summary>
    /// Specifies the index of the AuctionItem field in an 
    /// Auctioneer scan item.
    /// </summary>
    [FlagsAttribute()]
    public enum AuctionItemFields
    {
        /// <summary>
        /// Specifies no field selected.  In practice, this should
        /// never be used.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Index of the field containing the in-game link string.
        /// </summary>
        WowLink = 1,
        
        /// <summary>
        /// Index of the field containing the item's level.
        /// </summary>
        ItemLevel = 2,
        
        /// <summary>
        /// Index of the field containing the item type (eg. 'Armor' or 'Weapon').
        /// </summary>
        ItemType = 3,
        
        /// <summary>
        /// Index of the field containing the item subtype (eg. 'Mail' or 'Plate').
        /// </summary>
        ItemSubtype = 4,
        
        /// <summary>
        /// Index of the field containing the character slot where this item
        /// can be equipped.
        /// </summary>
        EquipmentSlot = 5,
        
        /// <summary>
        /// Index of the field containing the scanned price of the item (in copper).
        /// </summary>
        Price = 6,
        
        /// <summary>
        /// Index of the field containing the time remaining on the item's auction.
        /// </summary>
        TimeLeft = 7,
        
        /// <summary>
        /// Index of the field containing the time of seen.
        /// </summary>
        Time = 8,
        
        /// <summary>
        /// Index of the field containing the name of the item.
        /// </summary>
        Name = 9,
        
        /// <summary>
        /// Index of the field containing the path to the item's image resource 
        /// (from the WoW root folder).
        /// </summary>
        Texture = 10,
        
        /// <summary>
        /// Index of the field containing the quantity of this item in the auction.
        /// </summary>
        Count = 11,
        
        /// <summary>
        /// Index of the field containing the item's quality.
        /// </summary>
        Quality = 12,
        
        /// <summary>
        /// Index of the field that determines if the character can use the item.
        /// </summary>
        CanUse = 13,
        
        /// <summary>
        /// Index of the field containing the item's minimum usable level.
        /// </summary>
        RequiredLevel = 14,
        
        /// <summary>
        /// Index of the field containing the MinBid (unknown).
        /// </summary>
        MinBid = 15,
        
        /// <summary>
        /// Index of the field containing the MinInc (unknown).
        /// </summary>
        MinInc = 16,
        
        /// <summary>
        /// Index of the field containing the buyout price (in copper).
        /// </summary>
        Buyout = 17,
        
        /// <summary>
        /// Index of the field containing the current bid price for the 
        /// auction (in copper).
        /// </summary>
        CurrentBid = 18,
                
        /// <summary>
        /// Index of the field containing the name of the seller.
        /// </summary>AmHigh = 19,
        Seller = 20,
        
        /// <summary>
        /// Index of the field containing a scan status flag.
        /// </summary>
        Flag = 21,
        
        /// <summary>
        /// Index of the field containing the Id (unknown).
        /// </summary>
        Id = 22,
        
        /// <summary>
        /// Index of the field containing the item's itemId.
        /// </summary>
        ItemId = 23,
        
        /// <summary>
        /// Index of the field containing a suffix (eg. 'of the bear').
        /// </summary>
        Suffix = 24,
        
        /// <summary>
        /// Index of the field containing the Factor (unknown).
        /// </summary>
        Factor = 25,
        
        /// <summary>
        /// Index of the field containing the Enchant (unknown).
        /// </summary>
        Enchant = 26,
        
        /// <summary>
        /// Index of the field containing the Seed (unknown).
        /// </summary>
        Seed = 27,
    }
}
