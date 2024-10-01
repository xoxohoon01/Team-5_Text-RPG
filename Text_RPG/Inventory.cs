using System;

namespace TextRPG
{
    public class Inventory
    {
        //보유중인 아이템
        public List<Item> itemList;

        // 보유중 아이템 구분
        public List<Item> weaponList;

        public List<Item> armorList;

        //장착중인 아이템
        public Item item_weapon;

        public Item item_head;

        public Item item_top;

        public Item item_bottom;

        // 아이템 스탯 총합
        public Item item_player;

        public void Allitem(ref Player _player)
        {
            int allatk = item_weapon.AttackPower;
            int alldef = (item_head.DefensePower + item_top.DefensePower + item_bottom.DefensePower);
        }

        public Inventory()
        {
            itemList = new List<Item>();

            item_weapon = new Item();
            item_head = new Item();
            item_top = new Item();
            item_bottom = new Item();
        }

        public void GetItem(Item item)
        {
            itemList.Add(item);
        }

        public void InventoryMenu(ref Player _player)
        {
            while(true)
            {
                Console.WriteLine("[ 아이템 목록 ]\n");
                // 무기 목록
                Console.WriteLine("[ 무기 ]");
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].Type == ItemType.Weapon)
                    {
                        if (_player.inventory.item_weapon.isEquip == true)
                        { 
                            Console.WriteLine($"- [무기]{itemList[i].Name}    |   공격력 + {itemList[i].AttackPower}");
                            weaponList.Add(itemList[i]);
                        }
                        else
                        {
                            Console.WriteLine($"- {itemList[i].Name}    |   공격력 + {itemList[i].AttackPower}");
                            weaponList.Add(itemList[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("- 아이템이 없습니다.");
                    }
                }
                    //방어구 목록
                Console.WriteLine("\n[ 방어구 ]");
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].Type == ItemType.Head ||
                        itemList[i].Type == ItemType.Top ||
                        itemList[i].Type == ItemType.Bottom)
                    {
                        if (_player.inventory.item_head.isEquip == true)
                        {
                            Console.WriteLine($"- [머리]{itemList[i].Name}    |   방어력 + {itemList[i].DefensePower}");
                            armorList.Add(itemList[i]);
                        }
                        else if (_player.inventory.item_top.isEquip == true)
                        {
                            Console.WriteLine($"- [상의]{itemList[i].Name}    |   방어력 + {itemList[i].DefensePower}");
                            armorList.Add(itemList[i]);
                        }
                        else if (_player.inventory.item_bottom.isEquip == true)
                        {
                            Console.WriteLine($"- [하의]{itemList[i].Name}    |   방어력 + {itemList[i].DefensePower}");
                            armorList.Add(itemList[i]);
                        }
                        else
                        {
                            Console.WriteLine($"- {itemList[i].Name}    |   방어력 + {itemList[i].DefensePower}");
                            armorList.Add(itemList[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("- 아이템이 없습니다.");
                    }
                }
                // 소모품
                Console.WriteLine("[ 소모품 ]");
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].Type == ItemType.Potion)
                    {
                        Console.WriteLine($"- {itemList[i].Name}");
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
                            Town.EnterTown(ref _player);
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

                for (int i = 0; i < weaponList.Count; i++)
                {
                    if (weaponList[i].Type == ItemType.Weapon)
                    {
                        if (_player.inventory.item_weapon.isEquip == true)
                        {
                            Console.WriteLine($" {num}. [무기]{weaponList[i].Name}    |   공격력 + {weaponList[i].AttackPower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {weaponList[i].Name}    |   공격력 + {weaponList[i].AttackPower}");
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
                                if (_player.PlayerJob == weaponList[select - 1].WeaponJob)
                                {
                                    _player.inventory.item_weapon.isEquip = true;
                                    _player.inventory.item_weapon = weaponList[select - 1];
                                    Console.WriteLine("장착을 완료했습니다.");
                                }
                                else
                                {
                                    Console.WriteLine("장착하려는 장비가 직업에 맞지 않습니다.");
                                }
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
                for (int i = 0; i < armorList.Count; i++)
                {
                    if (armorList[i].Type == ItemType.Head)
                    {
                        if (_player.inventory.item_head.isEquip == true)
                        {
                            Console.WriteLine($"{num}. [머리]{armorList[i].Name}    |   방어력 + {armorList[i].DefensePower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {armorList[i].Name}    |   방어력 + {armorList[i].DefensePower}");
                            num++;
                        }
                    }
                    else if (armorList[i].Type == ItemType.Top)
                    {
                        if (_player.inventory.item_top.isEquip == true)
                        {
                            Console.WriteLine($"{num}. [상의]{armorList[i].Name}    |   방어력 + {armorList[i].DefensePower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {armorList[i].Name}    |   방어력 + {armorList[i].DefensePower}");
                            num++;
                        }
                    }
                    else if (armorList[i].Type == ItemType.Bottom)
                    {
                        if (_player.inventory.item_bottom.isEquip == true)
                        {
                            Console.WriteLine($"{num}. [하의]{armorList[i].Name}    |   방어력 + {armorList[i].DefensePower}");
                            num++;
                        }
                        else
                        {
                            Console.WriteLine($"{num}. {armorList[i].Name}    |   방어력 + {armorList[i].DefensePower}");
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
                                for (int x = 0; x < armorList.Count; x++)
                                {
                                    if (armorList[x].Type == ItemType.Head) 
                                    {
                                        if (_player.inventory.item_head.isEquip == false)
                                        {
                                            _player.inventory.item_head.isEquip = true;
                                            _player.inventory.item_head = armorList[select - 1];
                                            Console.WriteLine("장착을 완료했습니다.");
                                        }
                                        else if (_player.inventory.item_head.isEquip == true)
                                        {
                                            _player.inventory.item_head.isEquip = false;
                                            Console.WriteLine("해제를 완료했습니다.");
                                            _player.inventory.item_head = null;
                                        }
                                    }
                                    else if (armorList[x].Type == ItemType.Top)
                                    {
                                        if (_player.inventory.item_top.isEquip == false)
                                        {
                                            _player.inventory.item_top.isEquip = true;
                                            _player.inventory.item_top = armorList[select - 1];
                                            Console.WriteLine("장착을 완료했습니다.");
                                        }
                                        else if (_player.inventory.item_top.isEquip == true)
                                        {
                                            _player.inventory.item_top.isEquip = false;
                                            Console.WriteLine("해제를 완료했습니다.");
                                            _player.inventory.item_top = null;
                                        }
                                    }
                                    else if (armorList[x].Type == ItemType.Bottom)
                                    {
                                        if (_player.inventory.item_bottom.isEquip == false)
                                        {
                                            _player.inventory.item_bottom.isEquip = true;
                                            _player.inventory.item_bottom = armorList[select - 1];
                                            Console.WriteLine("장착을 완료했습니다.");
                                        }
                                        else if (_player.inventory.item_bottom.isEquip == true)
                                        {
                                            _player.inventory.item_bottom.isEquip = false;
                                            Console.WriteLine("해제를 완료했습니다.");
                                            _player.inventory.item_bottom = null;
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