using System.Diagnostics;
using TestingTodoListApp;

namespace ToDoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddITemToList_Success()
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            int taskCounterExpected = 1;

            todoList.AddItemToList(task);
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(taskCounterExpected, actual);

        }

        [TestMethod]
        public void AddSameITemToList_TwoTimes_WillSucceed() //lis‰t‰‰n kaksi samaa teht‰v‰‰
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");

            int taskCounterExpected = 2;
            todoList.AddItemToList(task);
            todoList.AddItemToList(task);

            int actual = todoList._TodoItems.Count;

            Assert.AreEqual(taskCounterExpected, actual);

        }

        [TestMethod]
        public void AddTwoItems_Success() //lis‰t‰‰n kaksi teht‰v‰‰
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            TodoTask task1 = new TodoTask("tiskaus");
            int taskCounterExpected = 2;

            todoList.AddItemToList(task);
            todoList.AddItemToList(task1);

            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(taskCounterExpected, actual);
        }

        [TestMethod]
        public void AddItem_WithSpecialLetters_Success() //ei ota alt code-symboleita
        {
            TodoList toDoList = new TodoList();
            TodoTask toDoTask = new TodoTask("<3~!");
            int toDoCounterExpected = 1;
            toDoList.AddItemToList(toDoTask);
            int actual = toDoList._TodoItems.Count;
            Assert.AreEqual(toDoCounterExpected, actual);
        }

        [TestMethod]
        public void ToDoList_IsEmpty_Success() //lista voi olla tyhj‰
        {
            TodoList toDoList = new TodoList();

            int toDoCounterExpected = 0;
            int actual = toDoList._TodoItems.Count;
            Assert.AreEqual(toDoCounterExpected, actual);
        }

        [TestMethod]
        public void ToDoTask_IsEmpty_Fail() //teht‰v‰/item ei voi olla tyhj‰
        {
            TodoList toDoList = new TodoList();
            TodoTask toDoTask = new TodoTask("");

            Assert.ThrowsException<System.ArgumentNullException>(() => toDoList.AddItemToList(toDoTask));
        }

        [TestMethod]
        public void TodoTask_RemoveFromList_Success() //poista teht‰v‰ listasta
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            TodoTask task1 = new TodoTask("tiskaus");
            todoList.AddItemToList(task1);
            todoList.AddItemToList(task);
            todoList.RemoveItemFromList(2); //poistetaan teht‰v‰ ID:ll‰

            int expected = 1;
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TodoTask_Remove_FromEmpty() //poista teht‰v‰ tyhj‰st‰ listasta
        {
            TodoList todoList = new TodoList();
            todoList.RemoveItemFromList(1);
            int expected = 0;
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TodoTask_RemoveLastTask() //poista viimeinen teht‰v‰ listasta
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            TodoTask task1 = new TodoTask("tiskaus");
            todoList.AddItemToList(task1);
            todoList.AddItemToList(task);
            TodoTask task2 = new TodoTask("imurointi");
            todoList.AddItemToList(task2);
            todoList.RemoveItemFromList(todoList._TodoItems.Count - 1);
            int expected = 2;
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

        }
        //poista teht‰v‰ jota ei ole olemassa
        [TestMethod]
        public void TodoTask_RemoveTaskThatIsNotThere()
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            TodoTask task1 = new TodoTask("tiskaus");
            todoList.AddItemToList(task1);
            todoList.AddItemToList(task);
            todoList.RemoveItemFromList(3);
            int expected = 2;
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);
        }
        //poista useampi teht‰v‰ per‰kk‰in
        [TestMethod]
        public void TodoTask_RemoveMultiple_Success()
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            TodoTask task1 = new TodoTask("tiskaus");
            todoList.AddItemToList(task1);
            todoList.AddItemToList(task);
            TodoTask task2 = new TodoTask("imurointi");
            todoList.AddItemToList(task2);
            todoList.RemoveItemFromList(1);
            todoList.RemoveItemFromList(2);
            int expected = 1;
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CompletedItem_Done_Success() //merkitse teht‰v‰ tehdyksi id:n perusteella
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            todoList.AddItemToList(task);
            todoList.CompleteItem(1);

            int expected = 0;
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void CompletedItem_LastItemInList_Completed() 
        {
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            todoList.AddItemToList(task);
            TodoTask task2 = new TodoTask("pyykki");
            todoList.AddItemToList(task2);  
            todoList.CompleteItem(2);
            int expected = 1;
            int actual = todoList._TodoItems.Count; 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void CompletedItem_NullItemDone_Success() 
        {
            TodoList todoList = new TodoList();
            todoList.CompleteItem(1);
            int expected = 0;
            int actual= todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CompleteProgram() 
        {
            //task added to list
            TodoList todoList = new TodoList();
            TodoTask task = new TodoTask("kissanpesu");
            int taskCounterExpected = 1;

            todoList.AddItemToList(task);
            int actual = todoList._TodoItems.Count;
            Assert.AreEqual(taskCounterExpected, actual);

            //same task added two times

            todoList.AddItemToList(task);
            todoList.AddItemToList(task);
            taskCounterExpected = 3;
            actual = todoList._TodoItems.Count;

            Assert.AreEqual(taskCounterExpected, actual);

            //add more items

            TodoTask task1 = new TodoTask("tiskaus");
            taskCounterExpected = 5;

            todoList.AddItemToList(task);
            todoList._TodoItems.Add(task1);

            actual = todoList._TodoItems.Count;
            Assert.AreEqual(taskCounterExpected, actual);

            //special letters task
            TodoTask toDoTask = new TodoTask("<3~!");
            int toDoCounterExpected = 6;
            todoList.AddItemToList(toDoTask);
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(toDoCounterExpected, actual);

            //to do list empty
            TodoList toDoList = new TodoList();

            int toDoListEmptyCounterExpected = 0;
             actual = toDoList._TodoItems.Count;
            Assert.AreEqual(toDoListEmptyCounterExpected, actual);

            //task cant be empty
            TodoTask todoTask = new TodoTask("");

            Assert.ThrowsException<System.ArgumentNullException>(() => todoList.AddItemToList(todoTask));

            //remove item from list
            todoList.RemoveItemFromList(2);

            int expected = 5;
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //remove from empty list
            TodoList todoEmptyList = new TodoList();
            todoEmptyList.RemoveItemFromList(1);
            expected = 0;
            actual = todoEmptyList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //remove last from list
            todoList.RemoveItemFromList(todoList._TodoItems.Count - 1);
            expected = 4;
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //remove item that is not on list
            todoList.RemoveItemFromList(10); 
            expected = 4;
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //clear todolist
            todoList._TodoItems.Clear();
            expected = 0;
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //remove multiple tasks from list
            todoList = new TodoList();
            TodoTask remove = new TodoTask("bake");
            TodoTask remove2= new TodoTask("cook");
            todoList.AddItemToList(remove2);
            todoList.AddItemToList(remove);
            todoList.RemoveItemFromList(1);
            todoList.RemoveItemFromList(2);
            expected = 0;
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //completed items
            TodoTask task3 = new TodoTask("task");
            todoList.AddItemToList(task3);
            
            todoList.CompleteItem(1);

            expected = 0;
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //last item in list completed, making a new list to try this

            TodoList toDolist = new TodoList();
            TodoTask task4 = new TodoTask("kissanpesu");
            toDolist.AddItemToList(task4);
            TodoTask task5 = new TodoTask("pyykki");
            toDolist.AddItemToList(task5);
            toDolist.CompleteItem(2);
            expected = 1;
            actual = toDolist._TodoItems.Count;
            Assert.AreEqual(expected, actual);

            //null item completed
            toDolist._TodoItems.Clear();
            toDolist.CompleteItem(1);
            expected = 0;
            actual = todoList._TodoItems.Count;
            Assert.AreEqual(expected, actual);

        }
    }
}