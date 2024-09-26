namespace TextRPG
{
    class Inventory
    {
        //보유중인 아이템
        public List<Item> items;

        //장착중인 아이템
        public Item weapon;
        public Item head;
        public Item top;
        public Item bottom;

        public Inventory()
        {
            items = new List<Item>();

            weapon = new Item();
            head = new Item();
            top = new Item();
            bottom = new Item();
        }

        public void GetItem(Item item)
        {
            items.Add(item);
        }
    }
}