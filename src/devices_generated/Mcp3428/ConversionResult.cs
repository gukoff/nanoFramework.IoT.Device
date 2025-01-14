// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Mcp3428
{
    /// <summary>
    /// Conversion result
    /// </summary>
    public readonly struct ConversionResult
    {
        /// <summary>
        /// Constructs ConversionResult instance
        /// </summary>
        /// <param name="channel">ADC channel</param>
        /// <param name="rawData">Raw ADC value</param>
        /// <param name="resolution">ADC resolution</param>
        public ConversionResult(byte channel, short rawData, AdcResolution resolution)
        {
            Channel = channel;
            RawValue = rawData;
            VoltageDivisor = Helpers.LsbDivisor(resolution);
        }

        /// <summary>
        /// ID of the measuring channel.
        /// </summary>
        /// <value>The channel.</value>
        public byte Channel { get; }

        /// <summary>
        /// Raw measurement data. Has to be scaled based on the measurement resolution to get voltage.
        /// </summary>
        /// <value>The raw data.</value>
        public short RawValue { get; }

        /// <summary>
        /// Divisor to scale raw data.
        /// </summary>
        /// <value>The divisor.</value>
        public ushort VoltageDivisor { get; }

        /// <summary>
        /// Accuracy of the voltage measurement
        /// </summary>
        /// <value>The LSB value.</value>
        public double Accuracy => 1.0 / VoltageDivisor;

        /// <summary>
        /// Gets the voltage.
        /// </summary>
        /// <value>The voltage.</value>
        /// <autogeneratedoc />
        public double Voltage => (double)RawValue / VoltageDivisor;
    }
}
