// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Device.I2c;

namespace Iot.Device.Amg88xx.Tests
{
    public class I2cTestDevice : I2cDevice
    {
        public Queue<byte> DataToRead { get; } = new Queue<byte>();
        public Queue<byte> DataWritten { get; } = new Queue<byte>();

        public override I2cConnectionSettings ConnectionSettings => throw new NotImplementedException();

        public override byte ReadByte()
        {
            if (DataToRead.Count == 0)
            {
                throw new InvalidOperationException("No data to read available");
            }

            return DataToRead.Dequeue();
        }

        public override void Read(SpanByte buffer)
        {
            for (int i = 0; i < buffer.Length && DataToRead.Count > 0; i++)
            {
                buffer[i] = DataToRead.Dequeue();
            }
        }

        public override void WriteByte(byte value)
        {
            DataWritten.Enqueue(value);
        }

        public override void Write(ReadOnlySpanByte buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                DataWritten.Enqueue(buffer[i]);
            }
        }

        public override void WriteRead(ReadOnlySpanByte writeBuffer, SpanByte readBuffer)
        {
            Write(writeBuffer);
            Read(readBuffer);
        }
    }
}
