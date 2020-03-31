using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Test_manager.Source.Services
{
    public static class Utils
    {
        public static double GetUnixTimestamp() {
            return DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static double CalculateStandardDeviation(IEnumerable<double> values) {
            double standardDeviation = 0;

            if (!values.Any()) return standardDeviation;
            var avg = values.Average();
            var sum = values.Sum(d => Math.Pow(d - avg, 2));
            standardDeviation = Math.Sqrt(sum / (values.Count() - 1));

            return standardDeviation;
        }
    }
}