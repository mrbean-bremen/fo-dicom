﻿// Copyright (c) 2012-2021 fo-dicom contributors.
// Licensed under the Microsoft Public License (MS-PL).

using System;

using Xunit;

namespace Dicom.Bugs
{
    [Collection("General")]
    public class GH328
    {

        [Fact]
        public void DicomDateTime_FractionalSecondsAndTimezone_SupportedFormat()
        {
            var dt = DateTime.Now.ToString("yyyyMMddHHmmss.ffffffzzz");
            if (dt.Contains("-"))
            {
                // the test is currently executed in a time zone with negative offset.
                // negative time offset are not allowed in DateTimeRange since the "-" is
                // reserved for the range-delimiter
                dt = dt.Replace('-', '+');
            }
            // Remove invalid ':' character from the time zone
            dt = dt.Replace(":", string.Empty);

            var dataset = new DicomDataset { new DicomDateTime(DicomTag.ScheduledProcedureStepStartDateTime, dt) };

            var exception = Record.Exception(() => dataset.Get<DicomDateRange>(DicomTag.ScheduledProcedureStepStartDateTime));
            Assert.Null(exception);
        }

    }
}
