﻿// ***********************************************************************
// Assembly         : Cron.Core
// Author           : chris
// Created          : 11-05-2020
//
// Last Modified By : chris
// Last Modified On : 11-17-2020
// ***********************************************************************
// <copyright file="CronTimeSections.cs" company="Microsoft Corporation">
//     copyright(c) 2020 Christopher Winland
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Cron.Core.Enums
{
    /// <summary>
    /// Sections of the Cron indicating the type of time.
    /// </summary>
    public enum CronTimeSections
    {
        /// <summary>
        /// Seconds.
        /// </summary>
        Seconds = 1,

        /// <summary>
        /// Minutes.
        /// </summary>
        Minutes = 2,

        /// <summary>
        /// Hours.
        /// </summary>
        Hours = 3,

        /// <summary>
        /// Day of the Month.
        /// </summary>
        DayMonth = 4,

        /// <summary>
        /// Month.
        /// </summary>
        Months = 5,

        /// <summary>
        /// Day of the Week.
        /// </summary>
        DayWeek = 6,
    }
}
