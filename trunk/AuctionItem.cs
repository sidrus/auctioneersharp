/*
 * Created by SharpDevelop.
 * User: Brandon
 * Date: 6/17/2009
 * Time: 11:14 PM
 */
using System;
using LuaInterface;

namespace AuctioneerSharp
{
	public class AuctionItem
	{
		private LuaTable itemData;
		
		private string itemWowLink;		
		public string ItemWowLink {
			get { 
				return itemWowLink.Replace("|", "\\124");; 
			}
		}
		private int itemLevel;		
		public int ItemLevel {
			get { return itemLevel; }
		}
		private string type;		
		public string Type {
			get { return type; }
		}
		private string subType;		
		public string SubType {
			get { return subType; }
		}
		private int equipmentSlot;		
		public int EquipmentSlot {
			get { return equipmentSlot; }
		}
		private string name;		
		public string Name {
			get { return name; }
		}
		
		
		public AuctionItem(LuaTable data)		
		{
			this.itemData = data;
			
			name = data[(int)AuctionItemField.Name].ToString();
			itemWowLink = data[(int)AuctionItemField.WowLink].ToString();
			itemLevel = Convert.ToInt32(data[(int)AuctionItemField.ItemLevel]);
			type = data[(int)AuctionItemField.ItemType].ToString();
			subType = data[(int)AuctionItemField.ItemSubtype].ToString();
			equipmentSlot = Convert.ToInt32(data[(int)AuctionItemField.EquipmentSlot]);
		}
	}
}
