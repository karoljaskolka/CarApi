using System.ComponentModel.DataAnnotations;

namespace CarApi.Models;

public class Car {
    [Key]
    public long Id { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
}
