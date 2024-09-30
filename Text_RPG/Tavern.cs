using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Tavern
    {
        public void Rest(ref Player _player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 선술집에서 휴식 ]\n");
                Console.WriteLine("- 500G을 내면 체력을 회복할 수 있습니다.  (보유 골드 : " + _player.Gold + " G)\n");

                Console.WriteLine($"{_player.Name}의 현재 체력 = {_player.Hp}    |   최대 체력 = {_player.MaxHp}\n");

                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기\n");
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
                        else
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
