//-----------------------------------------------------------------------
// <copyright file="ScanData.cs" company="Ejafi Software">
//      Copyright (c) Ejafi Software. All Rights Reserved.
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
        /// <summary>
        /// Static data member for a lua parser.
        /// </summary>
        private static Lua luaEngine = new Lua();
        
        /// <summary>
        /// A flag to specifying whether the object has been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The account used to generate this data file.
        /// </summary>
        private string accountName = "Unknown";
        
        /// <summary>
        /// The path to the data file.
        /// </summary>
        private string dataFilePath;
        
        /// <summary>
        /// The main data table from the data file.
        /// </summary>
        private LuaTable mainTable;
        
        /// <summary>
        /// Initializes a new instance of the ScanData class using the path
        /// specified.
        /// </summary>
        /// <param name="path">Path to the lua data file.</param>
        public ScanData(string path) {
            this.dataFilePath = path;
            LuaEngine.DoFile(this.dataFilePath);

            this.mainTable = LuaEngine.GetTable(Constants.MasterTablePath);
        }
        
        /// <summary>
        /// Gets or sets the name of the account for this scan data.
        /// </summary>
        /// <value>
        /// A string that contains the name of the account.
        /// </value>
        public string AccountName {
            get { return this.accountName; }
            set { this.accountName = value; }
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
        /// Gets the static Lua parser engine.
        /// </summary>
        /// <value>
        /// A LuaEngine object that parses lua statements.
        /// </value>
        internal static Lua LuaEngine {
            get { return luaEngine; }
        }

        /// <summary>
        /// Gets the available realms in the data file.
        /// </summary>
        /// <returns>
        /// A string array of discovered realms.
        /// </returns>
        public string[] GetRealmInfo() {
            string[] realms = new string[this.mainTable.Keys.Count];
            this.mainTable.Keys.CopyTo(realms, 0);
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
            LuaTable table = this.mainTable[realm] as LuaTable;
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
            LuaTable scanTable = this.mainTable[scanPath] as LuaTable;

            return new ScanImage(scanTable, realm, faction);
        }
        #region IDispose Implementation
        /// <summary>
        /// An implementation of the Dispose method for IDispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// An implementation of the Dispose method for IDispose.
        /// </summary>
        /// <param name="disposing">Whether the object is being disposed.</param>
        private void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    LuaEngine.Dispose();
                }
                
                this.disposed = true;
            }
        }
        #endregion
    }
}