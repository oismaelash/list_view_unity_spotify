using System;
using System.Collections.Generic;

namespace IsmaelNascimentoAssets.Models
{
    public partial class NewReleasesModel
    {
        public Albums Albums { get; set; }
    }

    public partial class Albums
    {
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public long Limit { get; set; }
        public string Next { get; set; }
        public long Offset { get; set; }
        public object Previous { get; set; }
        public long Total { get; set; }
    }

    public partial class Item
    {
        public string AlbumType { get; set; }
        public List<Artist> Artists { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseDatePrecision { get; set; }
        public long TotalTracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public partial class Artist
    {
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public partial class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public partial class Image
    {
        public long Height { get; set; }
        public string Url { get; set; }
        public long Width { get; set; }
    }
}