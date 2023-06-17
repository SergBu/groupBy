using System;
using System.Collections.Generic;
using System.Linq;

namespace groupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleMoves = new List<VehicleTimeslotMoveHistories>();
            vehicleMoves.Add(new VehicleTimeslotMoveHistories { TerminalTimeslotVehicleId = 1, DateCreated = DateTime.Today.AddDays(-3) });
            vehicleMoves.Add(new VehicleTimeslotMoveHistories { TerminalTimeslotVehicleId = 1, DateCreated = DateTime.Today.AddDays(-2) });
            vehicleMoves.Add(new VehicleTimeslotMoveHistories { TerminalTimeslotVehicleId = 2, DateCreated = DateTime.Today.AddDays(-1) });
            vehicleMoves.Add(new VehicleTimeslotMoveHistories { TerminalTimeslotVehicleId = 3, DateCreated = DateTime.Today });

            var movesByTimeslotVehicles = from vm in vehicleMoves
                                          group vm by vm.TerminalTimeslotVehicleId
                                          into movesDict
                                          select movesDict;

            //var res = (from mdict in movesByTimeslotVehicles
            //          select mdict.OrderBy(m => m.DateCreated).LastOrDefault(md => md.TerminalTimeslotVehicleId == mdict.Key)).ToList();

            var res = (from mdict in movesByTimeslotVehicles
                       select mdict.OrderBy(m => m.DateCreated).LastOrDefault()).ToList();

            Console.ReadKey();
        }
    }

    public class VehicleTimeslotMoveHistories
    {
        public int TerminalTimeslotVehicleId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
