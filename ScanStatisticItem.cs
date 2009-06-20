//-----------------------------------------------------------------------
// <copyright file="ScanStatisticItem.cs" company="Ejafi Software">
//      Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Brandon Frie</author>
// <date>6/17/2009</date>
// <summary>
//      This class is a representation of a single set of statistics
// for an auction house scan.
// </summary>
//-----------------------------------------------------------------------
namespace AuctioneerSharp
{
    using System;
    using LuaInterface;
    
    /// <summary>
    /// This class is a representation of a single set of statistics
    /// for an auction house scan.
    /// </summary>
    public class ScanStatisticItem
    {
        private int elapsed;
        
        /// <summary>
        /// Gets the length of time the session executed.
        /// </summary>
        public int Elapsed {
            get { return elapsed; }
        }

        private bool wasIncomplete;
        
        /// <summary>
        /// Gets whether the session was interrupted before completion.
        /// </summary>
        public bool WasIncomplete {
            get { return wasIncomplete; }
        }

        private double started;
        /// <summary>
        /// Gets the time the session began.
        /// </summary>
        public double Started {
            get { return started; }
        }

        private double ended;
        
        /// <summary>
        /// Gets the time the session ended.
        /// </summary>
        public double Ended {
            get { return ended; }
        }

        private double startTime;
        
        /// <summary>
        /// Gets the session's start time.
        /// </summary>
        public double StartTime {
            get { return startTime; }
        }

        private double endTime;
        
        /// <summary>
        /// Gets's the session's end time.
        /// </summary>
        public double EndTime {
            get { return endTime; }
        }

        private int expiredDeleteCount;
        
        /// <summary>
        /// Gets the number of items deleted due to expiration.
        /// </summary>
        public int ExpiredDeleteCount {
            get { return expiredDeleteCount; }
        }

        private int sameCount;
        
        /// <summary>
        /// Gets the number of items that were the same from the 
        /// previous session.
        /// </summary>
        public int SameCount {
            get { return sameCount; }
        }

        private int currentCount;
        
        /// <summary>
        /// Gets the number of items in this session.
        /// </summary>
        public int CurrentCount {
            get { return currentCount; }
        }

        private int missedCount;
        
        /// <summary>
        /// Gets the number of items missed in this session.
        /// </summary>
        public int MissedCount {
            get { return missedCount; }
        }

        private int newCount;
        
        /// <summary>
        /// Gets the number of new items in this session.
        /// </summary>
        public int NewCount {
            get { return newCount; }
        }

        private int oldCount;
        
        /// <summary>
        /// Gets the number of items in the previous session.
        /// </summary>
        public int OldCount {
            get { return oldCount; }
        }

        private int earlyDeleteCount;
        
        /// <summary>
        /// Gets the number of items removed prior to their 
        /// expected expiration date.
        /// </summary>
        public int EarlyDeleteCount {
            get { return earlyDeleteCount; }
        }

        private int updateCount;
        
        /// <summary>
        /// Gets the number of items updated since the last
        /// session.
        /// </summary>
        public int UpdateCount {
            get { return updateCount; }
        }

        private int paused;
        
        /// <summary>
        /// Gets the page number the session stopped at.
        /// </summary>
        public int Paused {
            get { return paused; }
        }

        /// <summary>
        /// Initializes an instance of the ScanStatisticItem class using the 
        /// data provided by the LuaTable.
        /// </summary>
        /// <param name="data">A lua table with the data to initialize the class.</param>
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
