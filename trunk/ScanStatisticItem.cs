/*
 * Created by SharpDevelop.
 * User: Brandon
 * Date: 6/17/2009
 * Time: 10:19 PM
 */
using System;
using LuaInterface;

namespace AuctioneerSharp
{
	public class ScanStatisticItem
	{
		private int elapsed;		
		public int Elapsed {
			get { return elapsed; }
		}
		
		private bool wasIncomplete;		
		public bool WasIncomplete {
			get { return wasIncomplete; }
		}
		
		private double started;		
		public double Started {
			get { return started; }
		}
		
		private double ended;		
		public double Ended {
			get { return ended; }
		}
		
		private double startTime;		
		public double StartTime {
			get { return startTime; }
		}
		
		private double endTime;		
		public double EndTime {
			get { return endTime; }
		}
		
		private int expiredDeleteCount;		
		public int ExpiredDeleteCount {
			get { return expiredDeleteCount; }
		}
		
		private int sameCount;		
		public int SameCount {
			get { return sameCount; }
		}
		
		private int currentCount;		
		public int CurrentCount {
			get { return currentCount; }
		}
		
		private int missedCount;		
		public int MissedCount {
			get { return missedCount; }
		}
		
		private int newCount;		
		public int NewCount {
			get { return newCount; }
		}
		
		private int oldCount;		
		public int OldCount {
			get { return oldCount; }
		}
		
		private int earlyDeleteCount;		
		public int EarlyDeleteCount {
			get { return earlyDeleteCount; }
		}
		
		private int updateCount;		
		public int UpdateCount {
			get { return updateCount; }
		}
		
		private int paused;		
		public int Paused {
			get { return paused; }
		}
		
		public ScanStatisticItem(LuaTable data)
		{
			this.currentCount = Convert.ToInt32(data[Constants.StatCurrentCount]);
			this.earlyDeleteCount = Convert.ToInt32(data[Constants.StatEarlyDeleteCount]);			
			this.elapsed = Convert.ToInt32(data[Constants.StatElapsed]);
			this.ended = Convert.ToDouble(data[Constants.StatEnded]);
			this.endTime = Convert.ToDouble(data[Constants.StatEndTime]);
			this.expiredDeleteCount = Convert.ToInt32(data[Constants.StatEarlyDeleteCount]);
			this.missedCount = Convert.ToInt32(data[Constants.StatMissedCount]);
			this.newCount = Convert.ToInt32(data[Constants.StatNewCount]);
			this.oldCount = Convert.ToInt32(data[Constants.StatOldCount]);
			this.paused = Convert.ToInt32(data[Constants.StatPaused]);
			this.sameCount = Convert.ToInt32(data[Constants.StatSameCount]);
			this.started = Convert.ToDouble(data[Constants.StatStarted]);
			this.startTime = Convert.ToDouble(data[Constants.StatStartTime]);
			this.updateCount = Convert.ToInt32(data[Constants.StatUpdateCount]);
			this.wasIncomplete = Convert.ToBoolean(data[Constants.StatWasIncomplete]);
		}
	}
}
