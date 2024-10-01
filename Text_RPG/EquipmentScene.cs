using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public static class EquipmentScene
    {
        public static void EnterEquipment(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("현재 장착중인 장비");
                Console.WriteLine($"무기: {_player.inventory.item_weapon.Name}");
                Console.WriteLine($"머리: {_player.inventory.item_head.Name}");
                Console.WriteLine($"상의: {_player.inventory.item_top.Name}");
                Console.WriteLine($"하의: {_player.inventory.item_bottom.Name}");
                Console.WriteLine();
                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine("1. 장비 장착");
                Console.WriteLine("2. 장비 해제");
                Console.WriteLine();
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");

                try
                {
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
                        Console.Clear();
                        Program.ShowMsgWrongValue();
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Program.ShowMsgWrongValue();
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
                    for (int i = 0; i <= 10; i++)
                    {
                        Console.WriteLine($"{((nowPage - 1) * 10) + (i)}. {_player.inventory.itemList[((nowPage - 1) * 10) + (i)].Name}");
                    }
                }
                else
                {
                    if (_player.inventory.itemList.Count > 0)
                    {
                        for (int i = 0; i <= _player.inventory.itemList.Count - ((int)_player.inventory.itemList.Count / 10); i++)
                        {
                            Console.WriteLine($"{((nowPage - 1) * 10) + (i)}. {_player.inventory.itemList[((nowPage - 1) * 10) + (i)].Name}");
                        }
                    }
                }

                Console.ReadKey();
                break;
            }
        }
    }
}
