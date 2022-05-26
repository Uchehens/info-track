using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Core.Contants
{
    public static class Refrence
    {
        public enum State
        {
            Current,
            Previous,
            Old,
        }

        public enum Trend
        {
            Up, Down, Flat, Unknown
        }
    }
}
