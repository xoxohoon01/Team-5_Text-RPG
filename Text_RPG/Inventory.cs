using System;

namespace TextRPG
{
    class Inventory
    {
        //보유중인 아이템
        public List<Item> haveItem;

        // 보유중 아이템 구분
        public List<Item> haveItemListWep;

        public List<Item> haveItemListDef;

        //장착중인 아이템
        public Item item_weapon;

        public Item item_head;

        public Item item_armor;

        public Item item_pants;

        // 아이템 스탯 총합
        public Item itemAllStats;

        public void Allitem(ref Player _player)
        {
            int allatk = item_weapon.AttackPower;
            int alldef = (item_head.DefensePower + item_armor.DefensePower + item_pants.DefensePower);
        }

        public Inventory(ref Player _player)
        {
            haveItem = new List<Item>();

            item_weapon = new Item();
            item_head = new Item();
            item_armor = new Item();
            item_pants = new Item();
        }

        public void GetItem(Item item)
        {
            haveItem.Add(item);
        }

        public void InventoryMenu(ref Player _player)
        {
            while(true)
            {
                Console.WriteLine("[ 아이템 목록 ]\n");
                // 무기 목록
                Console.WriteLine("[ 무기 ]");
                for (int i = 0; i < haveItem.Count; i++)
                {
                    if (haveItem[i].Type == ItemType.Weapon)
                    {
                        if (_player.inventory.item_weapon.isEquip == true)
                        { 
                            Console.WriteLine($"- [무기]{haveItem[i].Name}    |   공격력 + {haveItem[i].AttackPower}");
                            haveItemListWep.Add(haveItem[i]);
                        }
                        else
                        {
                            Console.WriteLine($"- {haveItem[i].Name}    |   공격력 + {haveItem[i].AttackPower}");
                            haveItemListWep.Add(haveItem[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("- 아이템이 없습니다.");
                    }
                }
                    //방어구 목록
                Console.WriteLine("\n[ 방어구 ]");
                for (int i = 0; i < haveItem.Count; i++)
                {
                    if (haveItem[i].Type == ItemType.Head ||
                        haveItem[i].Type == ItemType.Armor ||
                        haveItem[i].Type == ItemType.Pants)
                    {
                        if (_player.inventory.item_head.isEquip == true)
                        {
                            Console.WriteLine($"- [머리]{haveItem[i].Name}    |   방어력 + {haveItem[i].DefensePower}");
                            haveItemListDef.Add(haveItem[i]);
                        }
                        else if (_player.inventory.item_armor.isEquip == true)
                        {
                            Console.WriteLine($"- [상의]{haveItem[i].Name}    |   방어력 + {haveItem[i].DefensePower}");
                            haveItemListDef.Add(haveItem[i]);
                        }
                        else if (_player.inventory.item_pants.isEquip == true)
                        {
                            Console.WriteLine($"- [하의]{haveItem[i].Name}    |   방어력 + {haveItem[i].DefensePower}");
                            haveItemListDef.Add(haveItem[i]);
                        }
                        else
                        {
                            Console.WriteLine($"- {haveItem[i].Name}    |   방어력 + {haveItem[i].DefensePower}");
                            haveItemListDef.Add(haveItem[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("- 아이템이 없습니다.");
                    }
                }
                // 소모품
                Console.WriteLine("[ 소모품 ]");
                for (int i = 0; i < haveItem.Count; i++)
                {
                    if (haveItem[i].Type == ItemType.Potion)
                    {
                        Console.WriteLine($"- {haveItem[i].Name}");
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
                            EquipItemMenu(ref _player);
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

        public void EquipItemMenu(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 장착 메뉴 ]\n");

                Console.WriteLine("1. 무기 장착");
                Console.WriteLine("2. 방어구 장착");
                Console.WriteLine("0. 뒤로 가기");

                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                while (true)
                {
                    int select;
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0) // 인벤토리창으로 돌아가기
                        {
                            InventoryMenu(ref _player);
                            break;
                        }
                        else if (select == 1) // 무기 선택 창으로
                        {
                            EquipItemMenuWepaon(ref _player);
                            break;
                        }
                        else if (select == 2) // 방어구 선택 창으로
                        {
                            EquipItemMenuWepaon(ref _player);
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

        public void EquipItemMenuWepaon(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                int num = 1;
                Console.WriteLine("[ 무기 목록 ]");

                for (int i = 0; i < haveItemListWep.Count; i++)
                {
                    if (haveItemListWep[i].Type == ItemType.Weapon)
                    {
                        if (_player.inventory.item_weapon.isEquip == true)
                        {
                            Console.WriteLine($" {num}. [무기]{haveItemListWep[i].Name}    |   공격력 + {haveItemListWep[i].AttackPower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {haveItemListWep[i].Name}    |   공격력 + {haveItemListWep[i].AttackPower}");
                            num++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("- 아이템이 없습니다.");
                    }
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
                        if (select == 0)
                        {
                            EquipItemMenu(ref _player);
                            break;
                        }
                        else if (select > 0 && select <= num)
                        {
                            if (_player.inventory.item_weapon.isEquip == false)
                            {
                                for (int i = 0; i < num; i++);
                                _player.inventory.item_weapon.isEquip = true;
                                _player.inventory.item_weapon = haveItemListWep[select - 1];
                                Console.WriteLine("장착을 완료했습니다.");
                            }
                            else if (_player.inventory.item_weapon.isEquip == true)
                            {
                                _player.inventory.item_weapon.isEquip = false;
                                _player.inventory.item_weapon = null;
                                Console.WriteLine("해제를 완료했습니다.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                        continue;
                    }
                    Console.WriteLine("\n장착하거나 해제하실 번호를 입력해주세요.");
                    Console.WriteLine("0. 나가기");
                    Console.Write(">>");
                }
            }
        }

        public void EquipItemMenuDefense(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                int num = 1;
                Console.WriteLine("[ 방어구 목록 ]");

                Console.WriteLine("\n[ 방어구 목록 ]");
                for (int i = 0; i < haveItemListDef.Count; i++)
                {
                    if (haveItemListDef[i].Type == ItemType.Head)
                    {
                        if (_player.inventory.item_head.isEquip == true)
                        {
                            Console.WriteLine($"{num}. [머리]{haveItemListDef[i].Name}    |   방어력 + {haveItemListDef[i].DefensePower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {haveItemListDef[i].Name}    |   방어력 + {haveItemListDef[i].DefensePower}");
                            num++;
                        }
                    }
                    else if (haveItemListDef[i].Type == ItemType.Armor)
                    {
                        if (_player.inventory.item_armor.isEquip == true)
                        {
                            Console.WriteLine($"{num}. [상의]{haveItemListDef[i].Name}    |   방어력 + {haveItemListDef[i].DefensePower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {haveItemListDef[i].Name}    |   방어력 + {haveItemListDef[i].DefensePower}");
                            num++;
                        }
                    }
                    else if (haveItemListDef[i].Type == ItemType.Pants)
                    {
                        if (_player.inventory.item_pants.isEquip == true)
                        {
                            Console.WriteLine($"{num}. [하의]{haveItemListDef[i].Name}    |   방어력 + {haveItemListDef[i].DefensePower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {haveItemListDef[i].Name}    |   방어력 + {haveItemListDef[i].DefensePower}");
                            num++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("- 아이템이 없습니다.");
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
                            if (select == 0)
                            {
                                EquipItemMenu(ref _player);
                                break;
                            }
                            else if (select > 0 && select <= num)
                            {
                                for (int x = 0; x < haveItemListDef.Count; x++)
                                {
                                    if (haveItemListDef[x].Type == ItemType.Head) 
                                    {
                                        if (_player.inventory.item_head.isEquip == false)
                                        {
                                            _player.inventory.item_head.isEquip = true;
                                            _player.inventory.item_head = haveItemListDef[select - 1];
                                            Console.WriteLine("장착을 완료했습니다.");
                                        }
                                        else if (_player.inventory.item_head.isEquip == true)
                                        {
                                            _player.inventory.item_head.isEquip = false;
                                            Console.WriteLine("해제를 완료했습니다.");
                                            _player.inventory.item_head = null;
                                        }
                                    }
                                    else if (haveItemListDef[x].Type == ItemType.Armor)
                                    {
                                        if (_player.inventory.item_armor.isEquip == false)
                                        {
                                            _player.inventory.item_armor.isEquip = true;
                                            _player.inventory.item_armor = haveItemListDef[select - 1];
                                            Console.WriteLine("장착을 완료했습니다.");
                                        }
                                        else if (_player.inventory.item_armor.isEquip == true)
                                        {
                                            _player.inventory.item_armor.isEquip = false;
                                            Console.WriteLine("해제를 완료했습니다.");
                                            _player.inventory.item_armor = null;
                                        }
                                    }
                                    else if (haveItemListDef[x].Type == ItemType.Pants)
                                    {
                                        if (_player.inventory.item_pants.isEquip == false)
                                        {
                                            _player.inventory.item_pants.isEquip = true;
                                            _player.inventory.item_pants = haveItemListDef[select - 1];
                                            Console.WriteLine("장착을 완료했습니다.");
                                        }
                                        else if (_player.inventory.item_pants.isEquip == true)
                                        {
                                            _player.inventory.item_pants.isEquip = false;
                                            Console.WriteLine("해제를 완료했습니다.");
                                            _player.inventory.item_pants = null;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                            continue;
                        }
                        Console.WriteLine("\n장착하거나 해제하실 번호를 입력해주세요.");
                        Console.WriteLine("0. 나가기");
                        Console.Write(">>");
                    }
                }
            }
        }
    }
}