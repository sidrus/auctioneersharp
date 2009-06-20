//-----------------------------------------------------------------------
// <copyright file="ScanData.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Brandon Frie</author>
// <date>6/17/2009</date>
// <summary>
//      This class represents a single Auctioneer scan data set.  It may
// consist of one or more auction house images.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.Resources;
    using LuaInterface;

    /// <summary>
    /// This class represents a single Auctioneer scan data set.  It may
    /// consist of one or more auction house images.
    /// </summary>
	public class ScanData : IDisposable
	{
		internal static Lua luaEngine;

		private string accountName = "Unknown";
		private string dataFilePath;
		private LuaTable mainTable;

		/// <summary>
		/// Gets or sets the name of the account for this scan data.
		/// </summary>
		/// <value>
		/// A string that contains the name of the account.
		/// </value>
		public string AccountName {
			get { return accountName; }
			set { accountName = value; }
		}
		
		/// <summary>
		/// Gets the path to the lua file that contains the scan data to 
		/// import.
		/// </summary>
		/// <value>
		/// A string that contains the path.
		/// </value>
		public string DataFilePath {
			get { return this.dataFilePath; }
		}

		/// <summary>
		/// Initializes an instance of the ScanData class using the path
		/// specified.
		/// </summary>
		/// <param name="path">Path to the lua data file.</param>
		public ScanData(string path) {
			this.dataFilePath = path;

			luaEngine = new Lua();
			luaEngine.DoFile(dataFilePath);
			
			mainTable = luaEngine.GetTable(Constants.MasterTablePath);
		}

		/// <summary>
		/// Gets the available realms in the data file.
		/// </summary>
		/// <returns>
		/// A string array of discovered realms.
		/// </returns>
		public string[] GetRealmInfo() {
			string[] realms = new string[mainTable.Keys.Count];
			mainTable.Keys.CopyTo(realms, 0);
			return realms;
		}
		
		/// <summary>
		/// Gets the available factions for the specified realm
		/// in the data file.
		/// </summary>
		/// <param name="realm">The realm to search.</param>
		/// <returns>
		/// A string array containing the available factions.
		/// </returns>
		public string[] GetFactionInfo(string realm) {
			LuaTable table = mainTable[realm] as LuaTable;
			string[] factions = new string[table.Keys.Count];
			table.Keys.CopyTo(factions, 0);
			return factions;
		}
		
		/// <summary>
		/// Returns a <see cref="ScanImage" /> containing the data
		/// for the specified realm and faction.
		/// </summary>
		/// <param name="realm">The requested realm.</param>
		/// <param name="faction">The requested faction.</param>
		/// <returns>
		/// A <see cref="ScanImage" /> with the loaded data set.
		/// </returns>
		public ScanImage GetImage(string realm, string faction) {
			string scanPath = String.Format(CultureInfo.CurrentCulture, "{0}.{1}", realm, faction);
			LuaTable scanTable = mainTable[scanPath] as LuaTable;

			return new ScanImage(scanTable, realm, faction);
		}
		#region IDispose Implementation
		private bool disposed;
		
		/// <summary>
		/// An implementation of the Dispose method for IDispose.
		/// </summary>
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