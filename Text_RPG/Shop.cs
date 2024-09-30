using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Shop
    {
        public void ShopMenu(ref Player _player) // 상점가
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점가에 오신 것을 환영합니다.");
                Console.WriteLine("어느 상점으로 이동하시겠습니까?\n");

                Console.WriteLine("1. 대장간으로 이동");
                Console.WriteLine("2. 포션 상점으로 이동");
                Console.WriteLine("3. 선술집으로 이동");
                Console.WriteLine("0. 상점가 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int select;
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    if (select == 0) // 메뉴창으로 나가기
                    {
                        Program.EnterTown(ref _player);
                        break;
                    }
                    else if (select == 1) // 대장간으로 이동
                    {
                        Blacksmith(ref _player);
                        break;
                    }
                    else if (select == 2) // 포션 상점으로 이동
                    {
                        PotionStore(ref _player);
                        break;
                    }
                    else if (select == 3) // 선술집으로 이동
                    {
                        Tavern(ref _player);
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

        public void Blacksmith(ref Player _player) // 대장간
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 대장간 ]");
                Console.WriteLine("대장간에 온걸 환영하네. 여러 장비들 구경하고 가게나.\n");

                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                Console.WriteLine("[ 판매 목록 ]\n");
                Console.WriteLine("- 무기류");
                for (int i = 0; i < 10; i++) // 상점 목록 미완성
                {
                    Console.WriteLine($"무기 목록");
                }

                Console.WriteLine("\n- 방어구류");
                for (int i = 0; i < 10; i++) // 상점 목록 미완성
                {
                    Console.WriteLine($"방어구 목록");
                }

                Console.WriteLine("\n1. 무기 구매");
                Console.WriteLine("2. 방어구 구매");
                Console.WriteLine("3. 보유 장비 판매");
                Console.WriteLine("0. 대장간 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int select;
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    if (select == 0) // 상점가로 나가기
                    {
                        ShopMenu(ref _player);
                        break;
                    }
                    else if (select == 1) // 무기 구매화면으로 이동
                    {
                        BlacksmithWeapon(ref _player);
                        break;
                    }
                    else if (select == 2) // 방어구 구매화면으로 이동
                    {
                        BlacksmithArmor(ref _player);
                        break;
                    } 
                    else if (select == 3) // 보유 장비 판매창으로 이동
                    {
                        BlacksmithArmor(ref _player);
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
        public void BlacksmithWeapon(ref Player _player) // 무기 구매창
        {
            while (true)
            {
                Console.WriteLine("- 무기 구매");
                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                Console.WriteLine("[ 무기 목록 ]");
                for (int i = 0; i < 10 /*상점 무기목록.count 예정*/; i++)
                {
                    Console.WriteLine($"{i + 1}. ");
                }
                Console.WriteLine("\n구매하실 아이템을 선택해주세요.");
                Console.WriteLine("0. 대장간 목록으로");
                Console.Write(">> ");

                int select;
                if (int.TryParse(Console.ReadLine(),out select) && 
                    select >= 0 /*&& select < 상점 무기목록.count*/)
                {
                    if (select == 0)
                    {
                        Blacksmith(ref _player);
                    }
                    else if (select > 0 && select <= 10/*&& select < 상점 무기목록.count*/)
                    {
                        if (_player.Gold >= 0/*item.Price*/)
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            _player.Gold -= 0/*item.Price*/;
                            _player.inventory.haveItem.Add(Item[select - 1]);
                        }
                    }
                }
            }
        }
        public void BlacksmithArmor(ref Player _player) // 방어구 구매창
        {

        }

        public void PotionStore(ref Player _player) // 포션상점
        {

        }

        public void Tavern(ref Player _player) // 선술집
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 선술집 ]");
                Console.WriteLine("선술집에 오신 것을 환영합니다. 마음껏 쉬다 가세요!\n");

                Console.WriteLine("- 500G을 내면 체력을 회복할 수 있습니다.  (보유 골드 : " + _player.Gold + " G)");
                Console.WriteLine($"{_player.Name}의 현재 체력 = {_player.Hp}    |   최대 체력 = {_player.MaxHp}\n");

                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 선술집 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select = 0;
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    if (select == 1)
                    {
                        if (_player.Gold > 500)
                        {
                            if (_player.Hp == _player.MaxHp) // 캐릭터의 체력이 꽉차있을시
                            {
                                Console.WriteLine($"이미 {_player.Name}의 상태는 완벽합니다");
                            }
                            else // 캐릭터의 체력이 안 꽉차있을시
                            {
                                _player.Hp = _player.MaxHp;
                                Console.WriteLine("선술집에서 휴식을 완료했습니다.     ( 소지 골드 -500G ) ");
                                _player.Gold -= 500;
                            }
                        }
                        else // 골드 부족
                        {
                            Console.WriteLine("소유한 골드가 부족합니다.");
                        }
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">>");
                    }
                    else if (select == 0)
                    {
                        Program.EnterTown(ref _player); // 메인 화면으로 이동
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                    }
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
