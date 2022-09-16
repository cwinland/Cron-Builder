﻿// ***********************************************************************
// Assembly         : Cron.Core
// Author           : chris
// Created          : 11-12-2020
//
// Last Modified By : chris
// Last Modified On : 11-17-2020
// ***********************************************************************
// <copyright file="SectionValues.cs" company="Microsoft Corporation">
//     copyright(c) 2020 Christopher Winland
// </copyright>
// <summary></summary>
// ***********************************************************************

using Cron.Core.Enums;
using Cron.Core.Interfaces;
using System;
using System.ComponentModel;

namespace Cron.Core.Sections
{
    /// <summary>
    ///     Class SectionValues.
    /// Implements the <see cref="ISectionValues" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ISectionValues" />
    /// <inheritdoc cref="ISectionValues" />
    public class SectionValues<T> : ISectionValues
    {
        private const string MINUTE_FORMAT = "hh:mm tt";
        private readonly int? maxValue;
        private readonly CronTimeSections time;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SectionValues{T}" /> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="val">The value.</param>
        internal SectionValues(CronTimeSections time, int val)
        {
            this.time = time;
            MinValue = val;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SectionValues{T}" /> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="minVal">The minimum value.</param>
        /// <param name="maxVal">The maximum value.</param>
        internal SectionValues(CronTimeSections time, int minVal, int maxVal) : this(time, minVal)
        {
            maxValue = maxVal;
        }

        /// <summary>
        ///     Maximum value in a value range.
        /// </summary>
        /// <value>The maximum value.</value>
        /// <inheritdoc cref="ISectionValues" />
        public int MaxValue => maxValue ?? MinValue;

        /// <summary>
        ///     Minimum value in a value range. Also represents the only value, if the section is not a range.
        /// </summary>
        /// <value>The minimum value.</value>
        /// <inheritdoc cref="ISectionValues" />
        public int MinValue { get; }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="translate">Translate values.</param>
        /// <param name="enumType">Associated Enum Type.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        /// <inheritdoc cref="ISectionValues" />
        public string ToString(bool translate, Type enumType)
        {
            var isEnum = enumType?.BaseType == typeof(Enum);
            var isEnhanced =
                !isEnum && enumType != null && (enumType.BaseType?.Name.Contains("EnhancedEnum") ?? false);

            var minVal = isEnum
                ? Enum.ToObject(enumType, MinValue)
                      .ToString()
                : isEnhanced
                    ? ((T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(MinValue.ToString()))
                      ?.ToString() ??
                      string.Empty
                    : MinValue.ToString();

            var maxVal = isEnum
                ? Enum.ToObject(enumType, MaxValue)
                      .ToString()
                : isEnhanced
                    ? ((T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(MaxValue.ToString()))
                      ?.ToString() ??
                      string.Empty
                    : MaxValue.ToString();

            minVal = time == CronTimeSections.Hours && translate
                ? new DateTime().AddHours(int.Parse(minVal))
                                .ToString(MINUTE_FORMAT)
                : minVal;
            maxVal = time == CronTimeSections.Hours && translate
                ? new DateTime().AddHours(int.Parse(maxVal))
                                .AddMinutes(59)
                                .AddSeconds(59)
                                .ToString(MINUTE_FORMAT)
                : maxVal;

            return (minVal == maxVal
                ? minVal
                : $"{minVal}-{maxVal}").Trim();
        }

        /// <inheritdoc />
        public override string ToString() => ToString(false, null);
    }
}
