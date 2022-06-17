using System;

namespace SortNumbers.Models
{
    public class SortInput
    {
        public int Id { get; set; }

        public string Numbers { get; set; }
        public string? OrderedNumbers { get; set; } = String.Empty;

        public string OrderAscending { get; set; }
        public string? TimeToOrder { get; set; }
    }
}
