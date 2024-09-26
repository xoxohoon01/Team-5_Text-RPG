namespace TextRPG
{
    class Inventory 
    {
        //보유중인 아이템
        public List<Item> player_item;

        //장착중인 아이템
        public Item item_weapon;

        public Item item_head;

        public Item item_top;

        public Item item_bottom;

        public bool haveitem = false;

        public Inventory(ref Player _player)
        {
            player_item = new List<Item>();

            item_weapon = new Item();
            item_head = new Item();
            item_top = new Item();
            item_bottom = new Item();
        }

        public void GetItem(Item item)
        {
            player_item.Add(item);
        }

        public void InventoryMenu()
        {
            while(true)
            {
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < player_item.Count; i++)
                {
                    if (player_item[i] != null)
                    {
                        Console.WriteLine($"- {player_item[i].name}");
                    }
                    else
                    {
                        Console.WriteLine("- 아이템이 없습니다.");
                    }
                }
                Console.WriteLine("\n1. 장비 장착");
                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                while (true)
                {
                    int select;
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 1) // 장착창 켜기
                        {
                            EquipItemMenu();
                            break;
                        }
                        else if (select == 0) // 나가기
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                        }
                    }
                }
            }
        }

        public void EquipItemMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < player_item.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player_item[i].name}");
                }

                Console.WriteLine("\n장착하거나 해제하실 번호를 입력해주세요.");
                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                while (true) 
                {
                    int select;
                    if (int.TryParse(Console.ReadLine(), out select))
                    { 

                    }
                }
            }
        }
    }
}