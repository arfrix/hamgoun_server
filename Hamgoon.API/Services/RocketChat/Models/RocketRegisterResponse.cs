namespace HamgoonAPIV1.Services.RocketChat
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RocketRegisterResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public partial class User
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("utcOffset")]
        public long UtcOffset { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public partial class RocketRegisterResponse
    {
        public static RocketRegisterResponse FromJson(string json) => JsonConvert.DeserializeObject<RocketRegisterResponse>(json, HamgoonAPIV1.Services.RocketChat.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RocketRegisterResponse self) => JsonConvert.SerializeObject(self, HamgoonAPIV1.Services.RocketChat.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}