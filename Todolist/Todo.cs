namespace Todolist
{
    public class Todo
    {
        internal static string? todoText;

        public Todo() { }
        public Todo(int id, string todoText, DateTime dato, bool @checked)
        {
            this.id = id;
            TodoText = todoText;
            Dato = dato;
            Checked = @checked;
        }

        public int id { get; set; }
        public string TodoText { get; set; }
        public DateTime Dato { get; set; }
        public bool Checked { get; set; }
        public bool isCheck { get; set; }


        public string NewText { get; set; }
        public  string OldText { get; set; }
    }
}
