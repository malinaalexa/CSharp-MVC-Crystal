﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcCrystal.Models;

public class Candle
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [Display(Name = "Expiration Date")]
    [DataType(DataType.Date)]
    public DateTime ExpirationDate { get; set; }
    public string? Color { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}