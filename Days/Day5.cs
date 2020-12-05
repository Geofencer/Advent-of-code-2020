using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    internal static class Day5
    {
        internal static string Part1()
        {
            // Read Inputs
            var Tickets = Input.Read("Day5");

            //Solve Puzzle
            var HighestSeatID = 0;

            foreach (string Ticket in Tickets)
            {
                var SeatInstruction = new SeatInstruction(Ticket);
                var Seat = SeatCalculator(SeatInstruction);

                // sanitycheck on result: Lower and Upperbound should be the same.
                if (Seat.Coords.RowLower != Seat.Coords.RowUpper | Seat.Coords.CollumnLower != Seat.Coords.CollumnUpper) { throw new Exception("Non-convergence!"); }

                // Update solution
                var SeatID = Seat.Coords.RowLower * 8 + Seat.Coords.CollumnLower;
                if (SeatID > HighestSeatID) { HighestSeatID = SeatID; }
            }
            return "Highest SeatID: " + HighestSeatID;
        }


        internal static string Part2()
        {
            // Read Inputs
            var Tickets = Input.Read("Day5");

            //Solve Puzzle
            var OccupiedSeats = new SortedList<int, (int, int)> { };

            foreach (string Ticket in Tickets)
            {
                var SeatInstruction = new SeatInstruction(Ticket);
                var Seat = SeatCalculator(SeatInstruction);

                // sanitycheck on result: Lower and Upperbound should be the same.
                if (Seat.Coords.RowLower != Seat.Coords.RowUpper | Seat.Coords.CollumnLower != Seat.Coords.CollumnUpper) { throw new Exception("Non-convergence!"); }

                // Update solution
                var SeatID = Seat.Coords.RowLower * 8 + Seat.Coords.CollumnLower;
                OccupiedSeats.Add(SeatID, (Seat.Coords.RowLower, Seat.Coords.CollumnLower));
            }

            foreach (var (prevItem, currentItem, _) in OccupiedSeats.SlidingWindow())
            {
                if (currentItem.Key - prevItem.Key == 2) { return "My seat is: " + (currentItem.Key - 1).ToString(); }
            }

            return "No valid seat found!";
        }

        internal static SeatInstruction SeatCalculator(SeatInstruction SeatInstruction)
        {
            while (SeatInstruction.Instruction.Length > 0)
            {
                var Coords = SeatInstruction.Coords;
                var Instruction = SeatInstruction.Instruction[0];
                var IntervalRow = (Coords.RowUpper + 1 - Coords.RowLower) / 2;
                var IntervalCollumn = (Coords.CollumnUpper + 1 - Coords.CollumnLower) / 2;

                Coords = Instruction switch
                {
                    'F' => (Coords.RowLower, Coords.RowUpper - IntervalRow, Coords.CollumnLower, Coords.CollumnUpper),
                    'B' => (Coords.RowLower + IntervalRow, Coords.RowUpper, Coords.CollumnLower, Coords.CollumnUpper),
                    'R' => (Coords.RowLower, Coords.RowUpper, Coords.CollumnLower + IntervalCollumn, Coords.CollumnUpper),
                    'L' => (Coords.RowLower, Coords.RowUpper, Coords.CollumnLower, Coords.CollumnUpper - IntervalCollumn),
                    _ => throw new Exception("Invalid instruction")
                };

                // Update SeatInstruction for next iteration
                SeatInstruction.Coords = Coords;
                SeatInstruction.Instruction = SeatInstruction.Instruction[1..];

                // Recurse until no more instructions are left
                SeatCalculator(SeatInstruction);
            }
            return SeatInstruction;
        }

        // Ok, deze functie is gegoogled, maar wel handig :-)
        internal static IEnumerable<(T PrevItem, T CurrentItem, T NextItem)> SlidingWindow<T>(this IEnumerable<T> source, T emptyValue = default)
        {
            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                    yield break;
                var prevItem = emptyValue;
                var currentItem = iter.Current;
                while (iter.MoveNext())
                {
                    var nextItem = iter.Current;
                    yield return (prevItem, currentItem, nextItem);
                    prevItem = currentItem;
                    currentItem = nextItem;
                }
                yield return (prevItem, currentItem, emptyValue);
            }
        }
    }

    internal class SeatInstruction
    {
        internal string Instruction;
        internal (int RowLower, int RowUpper, int CollumnLower, int CollumnUpper) Coords;

        internal SeatInstruction(string instruction)
        {
            Instruction = instruction;
            Coords = (0, 127, 0, 7);
        }
    }

}
