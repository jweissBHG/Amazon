﻿using System;

namespace Amazon.DynamoDb
{
    public class BatchResult
    {
        public TimeSpan ResponseTime { get; set; }

        public int BatchCount { get; set; }

        public int ItemCount { get; set; }

        public int ErrorCount { get; set; }

        public int RequestCount { get; set; }
    }
}