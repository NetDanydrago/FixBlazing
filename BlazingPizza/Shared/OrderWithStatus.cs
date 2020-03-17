using BlazingPizza.ComponentsLibrary.Map;
using System;
using System.Collections.Generic;

namespace BlazingPizza.Shared
{
    public class OrderWithStatus
    {
        public Order Order { get; set; }
        public string StatusText { get; set; }
        public List<Marker> MapMarkers { get; set; }

        public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);
        public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);

        public static OrderWithStatus FromOrder(Order order)
        {
            string Massage;
            List<Marker> Markers;
            var DespacthTime = order.CreatedTime.Add(PreparationDuration);

            if (DateTime.Now < DespacthTime)
            {
                Massage = "Preparando";
                Markers = new List<Marker>
                {
                    ToMapMarker("usted", order.DeliveryLocation, showpoput: true)
                };
            }
            else if (DateTime.Now < DespacthTime + DeliveryDuration)
            {
                Massage = "en camino";
                var startPosition = ComputeStartPosition(order);
                var proportionOfDelliveryCompleted = Math.Min(1, (DateTime.Now - DespacthTime)
                                                     .TotalMilliseconds / DeliveryDuration.TotalMilliseconds);
                var driverPosition = LatLong.Interpolate(startPosition, order.DeliveryLocation, proportionOfDelliveryCompleted);
                Markers = new List<Marker>
                {
                    ToMapMarker("usted", order.DeliveryLocation),
                    ToMapMarker("repartodr", driverPosition, showpoput: true),                
                };
            }
            else
            {
                Massage = "enttegado";
                Markers = new List<Marker>
                {
                    ToMapMarker("ubicaciòn de entrega1",
                    order.DeliveryLocation, showpoput: true),
                };
            }

            return new OrderWithStatus
            {
                Order = order,
                StatusText = Massage,
                MapMarkers = Markers,
            };
        }

        static Marker ToMapMarker(string description, LatLong coords, bool showpoput = false) => new Marker
        {
            Description = description,
            X = coords.Longitude,
            Y = coords.Longitude,
            ShowPopup = showpoput,
        };

        private static LatLong ComputeStartPosition(Order order)
        {
            var randon = new Random(order.OrderId);
            var distance = 0.01 + randon.NextDouble() * 0.02;
            var angle = randon.NextDouble() * Math.PI * 2;
            var offset = (distance * Math.Cos(angle), distance * Math.Sin(angle));

            return new LatLong(order.DeliveryLocation.Latitude + offset.Item1,
                               order.DeliveryLocation.Longitude + offset.Item2);
        }
    }
}
