//-----------------------------------------------------------------------
// <copyright file="ScanStatisticItem.cs" company="Ejafi Software">
//      Copyright (c) Ejafi Software. All Rights Reserved.
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
        /// <summary>
        /// Gets the length of time the session executed.
        /// </summary>
        private int elapsed;
        
        /// <summary>
        /// Gets whether the session was interrupted before completion.
        /// </summary>
        private bool wasIncomplete;
        
        /// <summary>
        /// Gets the time the session began.
        /// </summary>
        private double started;
        
        /// <summary>
        /// Gets the time the session ended.
        /// </summary>
        private double ended;
        
        /// <summary>
        /// Gets the session's start time.
        /// </summary>
        private double startTime;
        
        /// <summary>
        /// Gets's the session's end time.
        /// </summary>
        private double endTime;
        
        /// <summary>
        /// Gets the number of items deleted due to expiration.
        /// </summary>
        private int expiredDeleteCount;
        
        /// <summary>
        /// Gets the number of items that were the same from the
        /// previous session.
        /// </summary>
        private int sameCount;
        
        /// <summary>
        /// Gets the number of items in this session.
        /// </summary>
        private int currentCount;
        
        /// <summary>
        /// Gets the number of items missed in this session.
        /// </summary>
        private int missedCount;
        
        /// <summary>
        /// Gets the number of new items in this session.
        /// </summary>
        private int newCount;
        
        /// <summary>
        /// Gets the number of items in the previous session.
        /// </summary>
        private int oldCount;
        
        /// <summary>
        /// Gets the number of items removed prior to their
        /// expected expiration date.
        /// </summary>
        private int earlyDeleteCount;
        
        /// <summary>
        /// Gets the number of items updated since the last
        /// session.
        /// </summary>
        private int updateCount;
        
        /// <summary>
        /// Gets the page number the session stopped at.
        /// </summary>
        private int paused;

        /// <summary>
        /// Initializes a new instance of the ScanStatisticItem class using the
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
            this.expiredDeleteCount = Convert.ToInt32(data[Constants.StatExpiredDeleteCount]);
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
        
        /// <summary>
        /// Gets the length of time the session executed.
        /// </summary>
        /// <value>
        /// A long integer timestamp.
        /// </value>
        public int Elapsed {
            get { return this.elapsed; }
        }

        /// <summary>
        /// Gets a value indicating whether the session was interrupted before 
        /// completion.
        /// </summary>
        /// <value>
        /// True if the scan terminated before completion, otherwise false.
        /// </value>
        public bool WasIncomplete {
            get { return this.wasIncomplete; }
        }

        /// <summary>
        /// Gets the time the session began.
        /// </summary>
        /// <value>
        /// A long integer timestamp.
        /// </value>
        public double Started {
            get { return this.started; }
        }

        /// <summary>
        /// Gets the time the session ended.
        /// </summary>
        /// <value>
        /// A long integer timestamp.
        /// </value>
        public double Ended {
            get { return this.ended; }
        }

        /// <summary>
        /// Gets the session's start time.
        /// </summary>
        /// <value>
        /// A long integer timestamp.
        /// </value>
        public double StartTime {
            get { return this.startTime; }
        }

        /// <summary>
        /// Gets the session's end time.
        /// </summary>
        /// <value>
        /// A long integer timestamp.
        /// </value>
        public double EndTime {
            get { return this.endTime; }
        }

        /// <summary>
        /// Gets the number of items deleted due to expiration.
        /// </summary>
        /// <value>
        /// An integer count of expired items.
        /// </value>
        public int ExpiredDeleteCount {
            get { return this.expiredDeleteCount; }
        }

        /// <summary>
        /// Gets the number of items that were the same from the
        /// previous session.
        /// </summary>
        /// <value>
        /// An integer count of identical items.
        /// </value>
        public int SameCount {
            get { return this.sameCount; }
        }

        /// <summary>
        /// Gets the number of items in this session.
        /// </summary>
        /// <value>
        /// An integer count of current items.
        /// </value>
        public int CurrentCount {
            get { return this.currentCount; }
        }

        /// <summary>
        /// Gets the number of items missed in this session.
        /// </summary>
        /// <value>
        /// An integer count of missed items.
        /// </value>
        public int MissedCount {
            get { return this.missedCount; }
        }

        /// <summary>
        /// Gets the number of new items in this session.
        /// </summary>
        /// <value>
        /// An integer count of new items.
        /// </value>
        public int NewCount {
            get { return this.newCount; }
        }

        /// <summary>
        /// Gets the number of items in the previous session.
        /// </summary>
        /// <value>
        /// An integer count of previously seen items.
        /// </value>
        public int OldCount {
            get { return this.oldCount; }
        }

        /// <summary>
        /// Gets the number of items removed prior to their
        /// expected expiration date.
        /// </summary>
        /// <value>
        /// An integer count of items deleted earlier than expected.
        /// </value>
        public int EarlyDeleteCount {
            get { return this.earlyDeleteCount; }
        }

        /// <summary>
        /// Gets the number of items updated since the last
        /// session.
        /// </summary>
        /// <value>
        /// An integer count of items that were updated.
        /// </value>
        public int UpdateCount {
            get { return this.updateCount; }
        }

        /// <summary>
        /// Gets the page number the session stopped at.
        /// </summary>
        /// <value>
        /// An integer specifying the page being scanned when interrupted.
        /// </value>
        public int Paused {
            get { return this.paused; }
        }
    }
}
