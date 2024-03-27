using Microsoft.AspNetCore.Mvc;
using MiPizza.Models;

namespace MiPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private static List<Pizza> pizzas;
    static PizzaController()
    {
        pizzas = new List<Pizza>();
    }

    [HttpGet]
    public IEnumerable<Pizza> Get()
    {
        return pizzas;
    }

    [HttpGet("{id}")]
    public Pizza Get(int id)
    {
        return pizzas[id];
    } 

    [HttpPost]
    public void Post(Pizza newPizza)
    {
        pizzas.Add(newPizza);
    } 

    [HttpPut("{id}")]
    public void Put(int id, Pizza newPizza)
    {
        var oldPizza = pizzas
            .FirstOrDefault
            (p => p.Id == id);
        var index = pizzas.IndexOf(oldPizza);
        pizzas[index] = newPizza;
    } 

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var oldPizza = pizzas
            .FirstOrDefault
            (p => p.Id == id);
        //pizzas.Remove(oldPizza);
        var index = pizzas.IndexOf(oldPizza);
        pizzas.RemoveAt(index);
    } 



       
}
