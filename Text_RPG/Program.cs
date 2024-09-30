using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;

namespace TextRPG
{
    internal class Program
    {

        static void Main()
        {
            Player player = new Player();
            Item newItem = new Item("검", "설명", ItemType.Weapon, 10);
            newItem.Name = "New";

            player.inventory.itemList.Add(new Item("갈치", "신선하다", ItemType.Weapon, 10, 0, 0, 0, 0, 0, 0));
            for (int i = 0; i < 10; i++)
            {
                player.inventory.itemList.Add(newItem);
            }
            
            EnterTutorial(ref player);
            EnterTown(ref player);
        }

        public static void EnterTutorial(ref Player _player)
        {
            while (true)
            {
                if (_player.Name == "")
                {
                    Console.Clear();
                    Console.WriteLine("이름을 입력해주세요.");
                    Console.Write("이름: ");
                    string name = Console.ReadLine();
                    if (name != "")
                    {
                        _player.Name = name;
                    }
                }
                else if (_player.PlayerJob == Job.None)
                {
                    Console.Clear();
                    Console.WriteLine("1. 전사");
                    Console.WriteLine("2. 도적");
                    Console.WriteLine("3. 마법사");
                    Console.WriteLine("4. 궁수");
                    Console.WriteLine();
                    Console.WriteLine("직업을 선택해주세요.");
                    Console.Write("직업: ");

                    //예외작업 필요
                    int classType = int.Parse(Console.ReadLine());
                    if (classType > 0 &&  classType <= 4)
                    {
                        _player.PlayerJob = (Job)classType;
                    }
                }
                else break;
            }
        }

        public static void EnterTown(ref Player _player)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("1. 캐릭터 정보");
                Console.WriteLine("2. 장비");
                Console.WriteLine("3. 인벤토리");
                Console.WriteLine("4. 상점");
                Console.WriteLine("5. 휴식");
                Console.WriteLine("6. 던전");
                Console.WriteLine();
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");
                int nowAction = int.Parse(Console.ReadLine());
                if (nowAction == 1)
                {
                    EnterStatus(ref _player);
                }
                else if (nowAction == 2)
                {
                    EnterEquipment(ref _player);
                }
                else if (nowAction == 3)
                {
                    EnterInventory(ref _player);
                }
                else if (nowAction == 4)
                {
                    EnterShop(ref _player);
                }
                else
                {
                    ShowMsgWrongValue();
                }
            }
        }

        public static void EnterStatus(ref Player _player)
        {
            Console.Clear();
            Console.WriteLine($"이름: {_player.Name}");
            Console.WriteLine($"직업: {_player.PlayerJob}");
            Console.WriteLine($"레벨: {_player.Level}");
            Console.WriteLine();
            Console.WriteLine($"공격력: {_player.Damage}");
            Console.WriteLine($"방어력: {_player.Defense}");
            Console.WriteLine($"속도: {_player.Speed}");
            Console.WriteLine($"치명타확률: {_player.CriticalChance}");
            Console.WriteLine($"치명타데미지: {_player.CriticalDamage}");
            Console.WriteLine();
            Console.WriteLine("계속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }

        public static void EnterEquipment(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("현재 장착중인 장비");
                Console.WriteLine($"무기: {_player.inventory.equipmentWeapon.Name}");
                Console.WriteLine($"머리: {_player.inventory.equipmentHead.Name}");
                Console.WriteLine($"상의: {_player.inventory.equipmentTop.Name}");
                Console.WriteLine($"하의: {_player.inventory.equipmentBottom.Name}");
                Console.WriteLine();
                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine("1. 장비 장착");
                Console.WriteLine("2. 장비 해제");
                Console.WriteLine();
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");
                int nowAction = int.Parse(Console.ReadLine());
                if (nowAction == 0)
                {
                    break;
                }
                else if (nowAction == 1)
                {
                    EnterChangeEquipment(ref _player);
                }
                else if (nowAction == 2)
                {
                    break;
                }
                else
                {
                    ShowMsgWrongValue();
                }
            }
        }

        public static void EnterChangeEquipment(ref Player _player)
        {
            int nowPage = 1;
            int maxPage = 1;
            while (true)
            {
                Console.Clear();
                if (_player.inventory.itemList.Count > 10)
                {
                    maxPage = (int)MathF.Ceiling(_player.inventory.itemList.Count / 10);
                }
                else maxPage = 1;

                if (nowPage != maxPage)
                {
                    for (int i = 0; i <= 10; i ++)
                    {
                        Console.WriteLine($"{((nowPage - 1) * 10) + (i)}. {_player.inventory.itemList[((nowPage - 1) * 10) + (i)].Name}");
                    }
                }
                else
                {
                    for (int i = 0; i <= _player.inventory.itemList.Count - ((int)_player.inventory.itemList.Count / 10); i++)
                    {
                        Console.WriteLine($"{((nowPage - 1) * 10) + (i)}. {_player.inventory.itemList[((nowPage - 1) * 10) + (i)].Name}");
                    }
                }

                Console.ReadKey();
            }
        }

        public static void EnterInventory(ref Player _player)
        {

        }

        public static void EnterShop(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");

                int nowAction = int.Parse(Console.ReadLine());
                if (nowAction == 0) break;
                else if (nowAction == 1)
                {
                    EnterBuyItem(ref _player);
                }
                else if (nowAction == 2)
                {
                    EnterSellItem(ref _player);
                }
                else
                {
                    ShowMsgWrongValue();
                }
            }
        }

        public static void EnterBuyItem(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                break;
            }
        }

        public static void EnterSellItem(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                break;
            }    
        }

        public static void EnterRest(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine("1. 휴식하기");
                Console.WriteLine();
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");
                int nowAction = int.Parse(Console.ReadLine());
                if (nowAction == 0) break;
                else if (nowAction == 1)
                {
                    break;
                }
                else
                {
                    ShowMsgWrongValue();
                }
            }
        }

        public static void EnterDungeon(ref Player _player)
        {
            while(true)
            {

            }
        }
     
        public static void ShowMsgWrongValue()
        {
            Console.WriteLine("올바른 값을 입력하세요.");
            Console.WriteLine("계속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }
        
    }
}