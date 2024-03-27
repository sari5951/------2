// using Microsoft.AspNetCore.Mvc;
// using Tasks.moduls;
// namespace Tasks.Controllers;
// [ApiController]
// [Route("[controller]")]
// public class TaskController : ControllerBase
// {
//     private List<Task> arr;
//     public TaskController()  
//     {
//         arr = new List<Task>
//         {
//             new Task { Id = 1, Name = "whash", Isdoing = false},
//             new Task { Id = 2, Name = "clear", Isdoing = false},
//             new Task { Id = 3, Name = "teady", Isdoing = true},
//         };
//     }

// [HttpGet]
//     public IEnumerable<Tasks> Get()
//     {
//         return arr;
//     }
    
//     [HttpGet("{id}")]
//     public Tasks Get(int id)
//     {
//         return arr.FirstOrDefault(p => p.Id == id);
//     }

        
//     [HttpPost]
//     public int Post(Tasks newTask)
//     {
//         int max = arr.Max(p => p.Id);
//         newTask.Id = max + 1;
//         arr.Add(newTask);  
//         return newTask.Id;      
//     }
        
//     [HttpPut("{id}")]
//     public void Put(int id, Tasks newTask)
//     {
//         if (id == newTask.Id)
//         {
//             var task = arr.Find(p => p.Id == id);
//             if (task != null)
//             {
//                 int index = arr.IndexOf(task);
//                 arr[index] =newTask;
//             }
//         }
//     }
        
//     [HttpDelete("{id}")]
//     public void Delete(int id)
//     {

//             var task = arr.Find(p => p.Id == id);
//             if (task != null)
//             {
//                 arr.Remove(task);
//             }

//     }



// }
// using Microsoft.AspNetCore.Mvc;
// using Tasks.moduls;
// using System.Collections.Generic;
// using System.Linq;

// namespace Tasks.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class TaskController : ControllerBase
//     {
//         private List<Task> arr;

//         public TaskController()
//         {
//             arr = new List<Task>
//             {
//                 new Task { Id = 1, Name = "whash", IsDoing = false },
//                 new Task { Id = 2, Name = "clear", IsDoing = false },
//                 new Task { Id = 3, Name = "teady", IsDoing = true },
//             };
//         }

//         [HttpGet]
//         public IEnumerable<Task> Get()
//         {
//             return arr;

//         }

//         [HttpGet("{id}")]
//         public Task Get(int id)
//         {
//             return arr.FirstOrDefault(p => p.Id == id);
//         }

//         [HttpPost]
//         public int Post(Task newTask)
//         {
//             int max = arr.Max(p => p.Id);
//             newTask.Id = max + 1;
//             arr.Add(newTask);
//             return newTask.Id;
//         }

//           [HttpPut("{id}")]
//     public void Put(int id, Task newTask)
//     {
//         if (id == newTask.Id)
//         {
//             var task = arr.Find(p => p.Id == id);
//             if (task != null)
//             {
//                 int index = arr.IndexOf(task);
//                 arr[index] =newTask;
//             }
//         }
//     }
//             [HttpDelete("{id}")]
//     public void Delete(int id)
//     {

//             var task = arr.Find(p => p.Id == id);
//             if (task != null)
//             {
//                 arr.Remove(task);
//             }

//     }



// }};
using Microsoft.AspNetCore.Mvc;
using Tasks.moduls;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private static List<Task> arr;

     static TaskController()
        {
            arr = new List<Task>
            {
               new Task { Id = 1, Name = "whash", IsDoing = false },
                new Task { Id = 2, Name = "clear", IsDoing = false },
                new Task { Id = 3, Name = "teady", IsDoing = true }
            };
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return arr;
        }

        [HttpGet("{id}")]
        public Task Get(int id)
        {
            return arr.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public int Post(Task newTask)
        {
            int max = arr.Max(p => p.Id);
            newTask.Id = max + 1;
            arr.Add(newTask);
            return newTask.Id;
        }

        [HttpPut("{id}")]
        public void Put(int id, Task newTask)
        {
            if (id == newTask.Id)
            {
                var task = arr.Find(p => p.Id == id);
                if (task != null)
                {
                    int index = arr.IndexOf(task);
                    arr[index] = newTask;
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = arr.Find(p => p.Id == id);
            if (task != null)
            {
                arr.Remove(task);
            }
        }
    }
}

