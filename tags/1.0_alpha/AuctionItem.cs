//-----------------------------------------------------------------------
// <copyright file="AuctionItem.cs" company="Ejafi Software">
//      Copyright (c) Ejafi Software. All Rights Reserved.
// </copyright>
// <author>Brandon Frie</author>
// <date>6/19/2009</date>
// <summary>
//      Defines an individual item in an Auctioneer scan image.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;
    using LuaInterface;

    /// <summary>
    /// Defines an individual item in an Auctioneer scan image.
    /// </summary>
    public class AuctionItem
    {
        /// <summary>
        /// A WoW-formatted string that defines a link to the item in-game.
        /// </summary>
        private string itemWowLink;
        
        /// <summary>
        /// The item's level.
        /// </summary>
        private int itemLevel;
        
        /// <summary>
        /// The main item type.
        /// </summary>
        private string itemType;
        
        /// <summary>
        /// The item subtype.
        /// </summary>
        private string subType;
        
        /// <summary>
        /// The slot the item can occupy.
        /// </summary>
        private int equipmentSlot;
        
        /// <summary>
        /// The item's name.
        /// </summary>
        private string name;
        
        /// <summary>
        /// Initializes a new instance of the AuctionItem class using the
        /// provided LuaTable as a data source.
        /// </summary>
        /// <param name="data">The scan data to use to build the AuctionItem.</param>
        public AuctionItem(LuaTable data)
        {
            this.name = data[(int)AuctionItemFields.Name].ToString();
            this.itemWowLink = data[(int)AuctionItemFields.WowLink].ToString();
            this.itemLevel = Convert.ToInt32(data[(int)AuctionItemFields.ItemLevel]);
            this.itemType = data[(int)AuctionItemFields.ItemType].ToString();
            this.subType = data[(int)AuctionItemFields.ItemSubtype].ToString();
            this.equipmentSlot = Convert.ToInt32(data[(int)AuctionItemFields.EquipmentSlot]);
        }
        
        /// <summary>
        /// Gets a WoW-formatted string that defines a link to the item in-game.
        /// </summary>
        /// <value>
        /// Gets a WoW-formatted string that defines a link to the item in-game.
        /// </value>
        public string ItemWowLink {
            get {
                return this.itemWowLink.Replace("|", "\\124");
            }
        }      
        
        /// <summary>
        /// Gets the item's level.
        /// </summary>
        /// <value>
        /// Gets the item's level.
        /// </value>
        public int ItemLevel {
            get { return this.itemLevel; }
        }        
        
        /// <summary>
        /// Gets the main item type.
        /// </summary>
        /// <value>
        /// Gets the main item type.
        /// </value>
        public string ItemType {
            get { return this.itemType; }
        }
        
        /// <summary>
        /// Gets the item subtype.
        /// </summary>
        /// <value>
        /// Gets the item subtype.
        /// </value>
        public string Subtype {
            get { return this.subType; }
        }
        
        /// <summary>
        /// Gets the slot the item can occupy.
        /// </summary>
        /// <value>
        /// Gets the slot the item can occupy.
        /// </value>
        public int EquipmentSlot {
            get { return this.equipmentSlot; }
        }
        
        /// <summary>
        /// Gets the item's name.
        /// </summary>
        /// <value>
        /// Gets the item's name.
        /// </value>
        public string Name {
            get { return this.name; }
        }
    }
}
