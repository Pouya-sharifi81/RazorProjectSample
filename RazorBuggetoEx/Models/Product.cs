﻿namespace RazorBuggetoEx.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        //asus-k551
        public string Slug { get; set; }
    }
}
