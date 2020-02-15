﻿using System.Collections.Generic;

namespace Amazon.Kms
{
    public sealed class GrantConstraints
    {
        // Match all
        public IReadOnlyDictionary<string, string>? EncryptionContextEquals { get; set; }

        // Match any
        public IReadOnlyDictionary<string, string>? EncryptionContextSubset { get; set; }
    }
}