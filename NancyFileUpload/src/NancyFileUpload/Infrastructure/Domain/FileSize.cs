namespace NancyFileUpload.Infrastructure.Domain
{
    using System;
    using System.Collections.Generic;

    public class FileSize
    {
        public enum Unit
        {
            Byte,
            Kilobyte,
            Megabyte,
            Gigabyte,
            Terabyte
        }

        // Constants for Converting between Units:
        private static readonly IDictionary<Unit, double> BinaryScale = new Dictionary<Unit, double>
        {
            {Unit.Byte, 1},
            {Unit.Kilobyte, Math.Pow(2, 10)},
            {Unit.Megabyte, Math.Pow(2, 20)},
            {Unit.Gigabyte, Math.Pow(2, 30)},
            {Unit.Terabyte, Math.Pow(2, 40)}
        };

        private readonly long bytes;

        private FileSize(long bytes)
        {
            this.bytes = bytes;
        }

        public static FileSize Create(long value, Unit unit)
        {
            var bytes = (long) (value*BinaryScale[unit]);

            return new FileSize(bytes);
        }

        public double Get(Unit unit)
        {
            return bytes/BinaryScale[unit];
        }
    }
}