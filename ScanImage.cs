//-----------------------------------------------------------------------
// <copyright file="ScanImage.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
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
        private LuaTable scanData;

        private ScanStatisticsCollection scanStats;
        
        /// <summary>
        /// Gets a collection of statistics about this image.
        /// </summary>
        public ScanStatisticsCollection Statistics {
            get { return scanStats; }
        }

        //private string image;
        private LuaTable ropes;
        //private double lastScanTime;
        //private double time;

        private Collection<SessionCollection> sessions;
        
        /// <summary>
        /// Gets a collection of scan sessions in this image.
        /// </summary>
        public Collection<SessionCollection> Sessions {
            get { return sessions; }
        }

        private string serverName;
        
        /// <summary>
        /// Gets the name of the server for this image.
        /// </summary>
        public string ServerName {
            get { return serverName; }
        }

        private string faction;
        
        /// <summary>
        /// Gets the name of the faction for this image.
        /// </summary>
        public string Faction {
            get { return faction; }
        }

        /// <summary>
        /// Initializes an instance of the ScanImage class with the
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

        private void Initialize() {
            foreach(DictionaryEntry entry in scanData) {
                if(entry.Key.Equals(Constants.ImageStatsKey))
                    scanStats = new ScanStatisticsCollection(scanData[Constants.ImageStatsKey] as LuaTable);
                //if(entry.Key.Equals(Constants.ImageTypeKey))
                    //image = scanData[Constants.ImageTypeKey].ToString();
                if(entry.Key.Equals(Constants.ImageRopesKey))
                    ropes = scanData[Constants.ImageRopesKey] as LuaTable;
                //if(entry.Key.Equals(Constants.ImageLastScanKey))
                    //lastScanTime = (double)scanData[Constants.ImageLastScanKey];
                //if(entry.Key.Equals(Constants.ImageTimeKey))
                    //time = (double)scanData[Constants.ImageTimeKey];
            }

            this.BuildSessions();
        }

        private void BuildSessions() {
            // initialize a new list
            sessions = new Collection<SessionCollection>();

            // load the list if there's data
            if(ropes!=null) {
                foreach(DictionaryEntry rope in ropes) {
                    sessions.Add(new SessionCollection(rope.Value.ToString()));
                }
            }
        }
    }
}
