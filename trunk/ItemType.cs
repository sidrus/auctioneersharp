//-----------------------------------------------------------------------
// <copyright file="ItemType.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Brandon Frie</author>
// <date>6/19/2009</date>
// <summary>
//      An enumeration of various item types.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;
    
    /// <summary>
    /// An enumeration of various item types.
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// No type specified.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// An item that can be equipped in the Head slot.
        /// </summary>
        Head = 1,
        
        /// <summary>
        /// An item that can be equipped in the Neck slot.
        /// </summary>
        Neck = 2,
        
        /// <summary>
        /// An item that can be equipped in the Shoulder slot.
        /// </summary>
        Shoulder = 3,
        
        /// <summary>
        /// An item that can be equipped in the Body slot.
        /// </summary>
        Body = 4,
        
        /// <summary>
        /// An item that can be equipped in the Chest slot.
        /// </summary>
        Chest = 5,
        
        /// <summary>
        /// An item that can be equipped in the Waist slot.
        /// </summary>
        Waist = 6,
        
        /// <summary>
        /// An item that can be equipped in the Legs slot.
        /// </summary>
        Legs = 7,
        
        /// <summary>
        /// An item that can be equipped in the Feet slot.
        /// </summary>
        Feet = 8,
        
        /// <summary>
        /// An item that can be equipped in the Wrist slot.
        /// </summary>
        Wrist = 9,
        
        /// <summary>
        /// An item that can be equipped in the Hand slot.
        /// </summary>
        Hand = 10,
        
        /// <summary>
        /// An item that can be equipped in a Finger slot.
        /// </summary>
        Finger = 11,
        
        /// <summary>
        /// An item that can be equipped in a Trinket slot.
        /// </summary>
        Trinket = 12,
        
        /// <summary>
        /// An item that can be equipped as a Weapon.
        /// </summary>
        Weapon = 13,
        
        /// <summary>
        /// An item that can be equipped in the Shield slot.
        /// </summary>
        Shield = 14,
                
        /// <summary>
        /// An item that can be equipped in the Ranged Right slot.
        /// </summary>
        RangedRight = 15,
        
        /// <summary>
        /// An item that can be equipped in the Cloak slot.
        /// </summary>
        Cloak = 16,
        
        /// <summary>
        /// An item that can be equipped as a Two Hand Weapon.
        /// </summary>
        TwoHandWeapon = 17,
        
        /// <summary>
        /// An item that can be equipped in a Bag slot.
        /// </summary>
        Bag = 18,
        
        /// <summary>
        /// An item that can be equipped in the Tabard slot.
        /// </summary>
        Tabard = 19,
        
        /// <summary>
        /// An item that can be equipped as a Robe.
        /// </summary>
        Robe = 20,
        
        /// <summary>
        /// An item that can be equipped in the Main-Hand slot.
        /// </summary>
        MainHand = 21,
        
        /// <summary>
        /// An item that can be equipped in the Off-Hand slot.
        /// </summary>
        OffHand = 22,
        
        /// <summary>
        /// An item that is holdable.
        /// </summary>
        Holdable = 23,
        
        /// <summary>
        /// An item that can be equipped in the Ammunition slot.
        /// </summary>
        Ammunition = 24,
        
        /// <summary>
        /// An item that can be equipped in the Thrown slot.
        /// </summary>
        Thrown = 25,
        
        /// <summary>
        /// An item that can be equipped as a Ranged item.
        /// </summary>
        Ranged = 26
    }
}
