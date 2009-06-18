/*
 * Created by SharpDevelop.
 * User: Brandon
 * Date: 6/17/2009
 * Time: 8:31 PM
 */
using System;
using System.Configuration;
using System.Globalization;
using LuaInterface;

namespace AuctioneerSharp
{
	public class ScanData : IDisposable
	{
		internal static Lua luaEngine;

		private string accountName = "Unknown";
		private string dataFilePath;
		private LuaTable mainTable;

		public string AccountName {
			get { return accountName; }
			set { accountName = value; }
		}
		public string DataFilePath {
			get { return this.dataFilePath; }
		}

		public ScanData(string path) {
			this.dataFilePath = path;

			luaEngine = new Lua();
			luaEngine.DoFile(dataFilePath);

			mainTable = luaEngine.GetTable(Constants.MasterTablePath);
		}

		public string[] GetRealmInfo() {
			string[] realms = new string[mainTable.Keys.Count];
			mainTable.Keys.CopyTo(realms, 0);
			return realms;
		}
		public string[] GetFactionInfo(string realm) {
			LuaTable table = mainTable[realm] as LuaTable;
			string[] factions = new string[table.Keys.Count];
			table.Keys.CopyTo(factions, 0);
			return factions;
		}
		public ScanImage GetImage(string realm, string faction) {
			string scanPath = String.Format(CultureInfo.CurrentCulture, "{0}.{1}", realm, faction);
			LuaTable scanTable = mainTable[scanPath] as LuaTable;

			return new ScanImage(scanTable, realm, faction);
		}
		#region IDispose Implementation
		private bool disposed;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing) {
			if(!this.disposed) {
				if(disposing) {
					luaEngine.Dispose();
				}
				this.disposed = true;
			}
		}
		#endregion
	}
}