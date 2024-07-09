using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Astaberry.Models
{   

    public partial class Temperatures
    {
        [JsonProperty("tracking_data")]
        public TrackingData TrackingData { get; set; }
    }

    public partial class TrackingData
    {
        [JsonProperty("track_status")]
        public long TrackStatus { get; set; }

        [JsonProperty("shipment_status")]
        public long ShipmentStatus { get; set; }

        [JsonProperty("shipment_track")]
        public ShipmentTrack[] ShipmentTrack { get; set; }

        [JsonProperty("shipment_track_activities")]
        public ShipmentTrackActivity[] ShipmentTrackActivities { get; set; }

        [JsonProperty("track_url")]
        public Uri TrackUrl { get; set; }
    }

    public partial class ShipmentTrack
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("awb_code")]
        public string AwbCode { get; set; }

        [JsonProperty("courier_company_id")]
        public long CourierCompanyId { get; set; }

        [JsonProperty("shipment_id")]
        public long ShipmentId { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("pickup_date")]
        public DateTimeOffset PickupDate { get; set; }

        [JsonProperty("delivered_date")]
        public DateTimeOffset DeliveredDate { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("packages")]
        public long Packages { get; set; }

        [JsonProperty("current_status")]
        public string CurrentStatus { get; set; }

        [JsonProperty("delivered_to")]
        public string DeliveredTo { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("consignee_name")]
        public string ConsigneeName { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("courier_agent_details")]
        public object CourierAgentDetails { get; set; }
    }

    public partial class ShipmentTrackActivity
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
