namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            Player player = new Player();
            player.inventory.items.Add(new Item());


            Console.WriteLine(player.inventory.items[0].name);
        }
    }
}