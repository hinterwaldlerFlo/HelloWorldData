using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HelloWorldData.Models
{
    public partial class MeasuredValues
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Timestamp { get; set; }

        public float Value { get; set; }
    }
}