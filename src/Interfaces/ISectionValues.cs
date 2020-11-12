﻿using System;

namespace Cron.Core.Interfaces
{
    /// <summary>
    ///   Stores the values for a section list.
    /// </summary>
    public interface ISectionValues
    {
        /// <summary>
        ///   Maximum value in a value range.
        /// </summary>
        int MaxValue { get; }

        /// <summary>
        ///   Minimum value in a value range. Also represents the only value, if the section is not a range.
        /// </summary>
        int MinValue { get; }

        /// <summary>
        ///   Convert to a string and translate to Enum, if applicable.
        /// </summary>
        /// <param name="translate">Translate values.</param>
        /// <param name="enumType">Associated Enum Type.</param>
        string ToString(bool translate, Type enumType);
    }
}
