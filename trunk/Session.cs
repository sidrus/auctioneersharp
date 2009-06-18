/*
 * Created by SharpDevelop.
 * User: Brandon
 * Date: 6/17/2009
 * Time: 11:15 PM
 */
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

namespace AuctioneerSharp
{
	public class Session : List<AuctionItem>
	{
		private string rope;
		private LuaTable sessionTable;
		
		public Session(string rope)
		{
			this.rope = rope;
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
