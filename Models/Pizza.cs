namespace PizzaHut.Models;
using System.ComponentModel.DataAnnotations;

public class  Pizza
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool GlutenFree { get; set; }
}