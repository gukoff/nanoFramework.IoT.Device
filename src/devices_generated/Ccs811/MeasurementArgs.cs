// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UnitsNet;

namespace Iot.Device.Ccs811
{
    /// <summary>
    /// Arguments of the Measurement Threshold event
    /// Contains the measurements done and potential error
    /// </summary>
    public class MeasurementArgs
    {
        /// <summary>
        /// True if measurement is successful
        /// </summary>
        public bool MeasurementSuccess { get; set; }

        /// <summary>
        /// Equivalent CO2, best is to use PartsPerMilion for a readable range
        /// </summary>
        public VolumeConcentration EquivalentCO2 { get; set; }

        /// <summary>
        /// Equivalent Total Volatile Organic Compound, best is to use PartsPerBilion for a readable range
        /// </summary>
        public VolumeConcentration EquivalentTotalVolatileOrganicCompound { get; set; }

        /// <summary>
        /// Raw current selected, best to use MicroAmpere for a readable range
        /// </summary>
        public ElectricCurrent RawCurrentSelected { get; set; }

        /// <summary>
        /// Raw ADC reading
        /// </summary>
        public int RawAdcReading { get; set; }
    }
}
