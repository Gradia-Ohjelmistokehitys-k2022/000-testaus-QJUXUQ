using System.Collections.Generic;
using System.Linq;
using TestingTodoListApp;

namespace TodoListNS
{

    /// <summary>
    /// Todo list. You can inserts things to do. Delete them. Complete them.
    /// </summary>
    public class Program
    {

        public static void Main()
        {
            TodoList todoList = new ();

            todoList.AddItemToList(new TodoTask("Do the dishes"));
          
            todoList.AddItemToList(new TodoTask("Wash your clothes"));
            var list = todoList.All; //for iterations
            var anotherList = todoList._TodoItems; //original style of getting list
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            foreach (var item in anotherList)
            {
                Console.WriteLine(item);
            }
            
            
            TodoList todoList1 = new TodoList();
            todoList1.AddItemToList(new TodoTask("a"));
            var list1 = todoList1.All;
            var anotherList1 = todoList1._TodoItems;
            foreach (var item in list1) 
            {
                Console.WriteLine(item);
            }
            foreach (var item in anotherList1) 
            {
                Console.WriteLine(item);
            }
            
            
        }

    }
}
