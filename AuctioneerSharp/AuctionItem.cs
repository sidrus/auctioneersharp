/*
 * Created by SharpDevelop.
 * User: Brandon
 * Date: 6/17/2009
 * Time: 11:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using LuaInterface;

namespace AuctioneerSharp
{
	/// <summary>
	/// Description of AuctionItem.
	/// </summary>
	public class AuctionItem
	{
		private LuaTable itemData;
		public AuctionItem(LuaTable data)		
		{
			this.itemData = data;
		}
	}
}
