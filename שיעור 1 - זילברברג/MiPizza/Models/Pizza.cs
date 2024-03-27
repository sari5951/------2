namespace MiPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsGlutenFree { get; set; }
    public bool IsVegan { get; set; }
    
}