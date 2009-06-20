//-----------------------------------------------------------------------
// <copyright file="ScanImage.cs" company="Ejafi Software">
//      Copyright (c) Ejafi Software. All Rights Reserved.
// </copyright>
// <author>Brandon Frie</author>
// <date>6/17/2009</date>
// <summary>
//      This class is a representation of a single auction house scan.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    using LuaInterface;

    /// <summary>
    /// This class is a representation of a single auction house scan.
    /// </summary>
    public class ScanImage
    {
        /// <summary>
        /// The raw data from the lua file.
        /// </summary>
        private LuaTable scanData;

        /// <summary>
        /// A collection of auctioneer statistics about this image.
        /// </summary>
        private ScanStatisticsCollection scanStats = new ScanStatisticsCollection(null);

        /// <summary>
        /// The raw strings (ropes) containing scan data.
        /// </summary>
        private LuaTable ropes;

        /// <summary>
        /// A collection of <see cref="SessionCollection" /> data.
        /// </summary>
        private Collection<SessionCollection> sessions;

        /// <summary>
        /// The server on which this data was collected.
        /// </summary>
        private string serverName;
        
        /// <summary>
        /// The faction on which this data was collected.
        /// </summary>
        private string faction;

        /// <summary>
        /// Initializes a new instance of the ScanImage class with the
        /// data from a LuaTable.
        /// </summary>
        /// <param name="data">
        /// A LuaTable with the data to use to initialize the class.
        /// </param>
        /// <param name="server">The server this data was collected on.</param>
        /// <param name="fact">The faction this data was collected on.</param>
        public ScanImage(LuaTable data, string server, string fact)
        {
            this.scanData = data;
            this.serverName = server;
            this.faction = fact;
            this.Initialize();
        }
        
        /// <summary>
        /// Gets the name of the server for this image.
        /// </summary>
        /// <value>
        /// A string which is the name of the server.
        /// </value>
        public string ServerName {
            get { return this.serverName; }
        }
        
        /// <summary>
        /// Gets a collection of scan sessions in this image.
        /// </summary>
        /// <value>
        /// A collection of <see cref="SessionCollection" /> objects.
        /// </value>
        public Collection<SessionCollection> Sessions {
            get { return this.sessions; }
        }
        
        /// <summary>
        /// Gets a collection of statistics about this image.
        /// </summary>
        /// <value>
        /// A collection of <see cref="ScanStatisticItem" />s.
        /// </value>
        public ScanStatisticsCollection Statistics {
            get { return this.scanStats; }
        }
        
        /// <summary>
        /// Gets the name of the faction for this image.
        /// </summary>
        /// <value>
        /// A string which is the name of the faction.
        /// </value>
        public string Faction {
            get { return this.faction; }
        }

        /// <summary>
        /// Initializes the data members of the object.
        /// </summary>
        private void Initialize() {
            foreach (DictionaryEntry entry in this.scanData) {
                if (entry.Key.Equals(Constants.ImageStatsKey)) {
                    this.scanStats = new ScanStatisticsCollection(this.scanData[Constants.ImageStatsKey] as LuaTable);
                }
                ////if(entry.Key.Equals(Constants.ImageTypeKey))
                    ////image = scanData[Constants.ImageTypeKey].ToString();
                if (entry.Key.Equals(Constants.ImageRopesKey)) {
                    this.ropes = this.scanData[Constants.ImageRopesKey] as LuaTable;
                }
                ////if(entry.Key.Equals(Constants.ImageLastScanKey))
                   ////lastScanTime = (double)scanData[Constants.ImageLastScanKey];
                ////if(entry.Key.Equals(Constants.ImageTimeKey))
                    ////time = (double)scanData[Constants.ImageTimeKey];
            }

            this.BuildSessions();
        }

        /// <summary>
        /// Builds the <see cref="SessionCollection" /> objects from the data.
        /// </summary>
        private void BuildSessions() {
            // initialize a new list
            this.sessions = new Collection<SessionCollection>();

            // load the list if there's data
            if (this.ropes != null) {
                foreach (DictionaryEntry rope in this.ropes) {
                    this.sessions.Add(new SessionCollection(rope.Value.ToString()));
                }
            }
        }
    }
}
