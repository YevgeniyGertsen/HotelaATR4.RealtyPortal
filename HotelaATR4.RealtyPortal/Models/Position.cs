﻿namespace HotelaATR4.RealtyPortal.Models
{
    public class Position
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "admin";

        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
