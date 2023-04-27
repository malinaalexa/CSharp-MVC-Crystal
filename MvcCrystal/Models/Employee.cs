using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcCrystal.Models;

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [Display(Name = "Hire Date")]
    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; }
    public string? Position { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Salary { get; set; }
}