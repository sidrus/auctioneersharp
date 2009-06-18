/*
 * Created by SharpDevelop.
 * User: Brandon
 * Date: 6/17/2009
 * Time: 10:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

namespace AuctioneerSharp
{
	/// <summary>
	/// Description of ScanImage.
	/// </summary>
	public class ScanImage
	{
		private LuaTable scanData;
		
		private ScanStatistics scanStats;		
		public ScanStatistics Statistics {
			get { return scanStats; }
		}
		
		private string image;
		private LuaTable ropes;
		private double lastScanTime;
		private double time;
		
		private List<Session> sessions;		
		public List<Session> Sessions {
			get { return sessions; }
		}
		
		private string serverName;		
		public string ServerName {
			get { return serverName; }
		}
		
		private string faction;		
		public string Faction {
			get { return faction; }
		}
		
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
					scanStats = new ScanStatistics(scanData[Constants.ImageStatsKey] as LuaTable);
				if(entry.Key.Equals(Constants.ImageTypeKey))
					image = scanData[Constants.ImageTypeKey].ToString();
				if(entry.Key.Equals(Constants.ImageRopesKey))
					ropes = scanData[Constants.ImageRopesKey] as LuaTable;
				if(entry.Key.Equals(Constants.ImageLastScanKey))
					lastScanTime = (double)scanData[Constants.ImageLastScanKey];
				if(entry.Key.Equals(Constants.ImageTimeKey))
					time = (double)scanData[Constants.ImageTimeKey];
			}
						
			this.BuildSessions();
		}
		
		private void BuildSessions() {
			// initialize a new list
			sessions = new List<Session>();
			
			// load the list if there's data
			if(ropes!=null) {
				foreach(DictionaryEntry rope in ropes) {
					sessions.Add(new Session(rope.Value.ToString()));
				}
			}
		}
	}
}
