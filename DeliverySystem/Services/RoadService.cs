using DeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DeliverySystem.Services
{
    internal class RoadService
    {
        private Dictionary<int, List<Road>> roads { get; set; }

        public RoadService(List<Road> roads)
        {
            this.roads = roads.GroupBy(r => r.FromStreetId)
                .ToDictionary(r =>  r.Key, r => r.ToList());
        }

        public TravelRecord? GetDistanceByStreets(int fromStreetId, int toStreetId)
        {
            if (fromStreetId == toStreetId) return new TravelRecord
            {
                Distance = 0,
                Seconds = 60
            };

            if (!roads.TryGetValue(fromStreetId, out var roadsFrom))
                return null;

            var list = new List<int>();
            list.Add(fromStreetId);

            var record = new TravelRecord
            {
                Distance = 0,
                Seconds = 0
            };

            var records = new List<TravelRecord>();

            foreach (var road in roadsFrom)
            {
                records.Add(GetDistanceByStreets(list, road, record, toStreetId));
            }

            var result = records.Where(r => r != null).MinBy(r => r.Seconds);
            if (result == null) return null;
            return result;
        }

        private TravelRecord? GetDistanceByStreets(List<int> list, Road road, TravelRecord record, int toStreetId)
        {
            if (list.Any(x => x == road.ToStreetId)) return null;

            var newList = new List<int>(list);
            newList.Add(road.ToStreetId);

            double rain = road.DeliveryFactors.Any(d => d == "rain") ? 0.1 : 0;
            double mountain = road.DeliveryFactors.Any(d => d == "mountain") ? 0.2 : 0;

            double speedCourier = 1 - rain - mountain;

            var newRecord = new TravelRecord
            {
                Distance = record.Distance + road.Distance,
                Seconds = record.Seconds + (int)(road.Distance / speedCourier)
            };

            if (road.ToStreetId == toStreetId)
            {
                return newRecord;
            }

            if (!roads.TryGetValue(road.ToStreetId, out var roadsFrom))
                return new TravelRecord { Distance = 0, Seconds = 0 };

            var records = new List<TravelRecord?>();

            foreach (var way in roadsFrom)
            {
                records.Add(GetDistanceByStreets(newList, way, newRecord, toStreetId));
            }

            var result = records.Where(r => r != null).MinBy(r => r.Seconds);
            if (result == null) return null;
            return result;
        }
    }
}
