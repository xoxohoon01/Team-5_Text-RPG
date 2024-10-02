using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public static class Town
    {
        public static void EnterTown(ref Player _player)
        {
            while (true)
            {
                if (Program.hasPlayer == false) break; //캐릭터 삭제되면 게임 재시작

                Program.SavePlayerData(_player); //마을로 돌아올 때마다 저장

                Console.Clear();
                Console.WriteLine("1. 캐릭터 정보");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 휴식");
                Console.WriteLine("5. 던전");
                Console.WriteLine();
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");

                try
                {
                    int nowAction = int.Parse(Console.ReadLine());
                    if (nowAction == 1)
                    {
                        StatusScene.EnterStatus(ref _player);
                    }
                    else if (nowAction == 2)
                    {
                        _player.inventory.InventoryMenu(ref _player);
                    }
                    else if (nowAction == 3)
                    {
                        Shop.EnterShop(ref _player);
                    }
                    else if (nowAction == 4)
                    {
                        Program.ShowMsgWrongValue();
                    }
                    else if (nowAction == 5)     //던전입장 추가
                    {
                        DungeonScene.EnterDungeon(ref _player);
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
    }
}
