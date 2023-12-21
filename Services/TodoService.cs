using Todo_list.Models;
namespace Todo_list.Services;

public static class TodoService
{
    private static List<Todo> Todoes;

    static TodoService()
    {
        Todoes = new List<Todo>
        {
            new Todo { Id = 1, Descreption = "wash the dishes", Isdone = false},
            new Todo { Id = 2, Descreption = "clean the room", Isdone = false},
            new Todo { Id = 3, Descreption = "clean the house", Isdone = true}
        };
    }

    public static List<Todo> GetAll() => Todoes!;

    public static Todo GetById(int id)
    {
        return Todoes.FirstOrDefault(t => t.Id == id)!;
    }

    public static int Add(Todo newTodo)
    {
        if (Todoes.Count == 0)

        {
            newTodo.Id = 1;
        }
        else
        {
            newTodo.Id = Todoes.Max(p => p.Id) + 1;

        }

        Todoes.Add(newTodo);

        return newTodo.Id;
    }

    public static bool Update(int id, Todo newTodo)
    {
        if (id != newTodo.Id)
            return false;

        var existingTodo = GetById(id);
        if (existingTodo == null)
            return false;

        var index = Todoes.IndexOf(existingTodo);
        if (index == -1)
            return false;

        Todoes[index] = newTodo;

        return true;
    }


    public static bool Delete(int id)
    {
        var existingTodo = GetById(id);
        if (existingTodo == null)
            return false;

        var index = Todoes.IndexOf(existingTodo);
        if (index == -1)
            return false;

        Todoes.RemoveAt(index);
        return true;
    }



}