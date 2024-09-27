﻿using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace TextRPG
{
    internal class Program
    {

        static void Main()
        {
            Player player = new Player();
            player.Name = "";   //Player.cs에서 생성자에서 이름 결정, 추후에 수정 필요

            player.inventory.items.Add(new Item("갈치", "신선하다", ItemType.Weapon, 10, 0, 0, 0, 0, 0, 0));

            EnterTutorial(ref player);
            EnterTown(ref player);
        }

        public static void EnterTutorial(ref Player _player)
        {
            while (true)
            {
                //이름이 없을 경우
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

                //이름이 있을 경우 직업 선택
                else if (_player.PlayerJob == Job.None)
                {
                    Console.Clear();
                    Console.WriteLine("1. 전사");
                    Console.WriteLine("2. 궁수");
                    Console.WriteLine("3. 도적");
                    Console.WriteLine("4. 마법사");
                    Console.WriteLine();
                    Console.WriteLine("직업을 선택해주세요.");
                    Console.Write("직업: ");

                    try
                    {
                        int classType = int.Parse(Console.ReadLine());
                        if (classType > 0 && classType <= 4)
                        {
                            _player.PlayerJob = (Job)classType;
                        }
                        else
                        {
                            Console.Clear();
                            ShowMsgWrongValue();
                        }
                    }
                    catch (FormatException)
                    {
                        _player.PlayerJob = Job.None;
                        Console.Clear();
                        ShowMsgWrongValue();
                    }

                }

                //이름과 직업이 있을 경우 튜토리얼 종료
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{_player.Name}, 당신의 직업은 {_player.PlayerJob}입니다.");
                    ShowMsgContinue();
                    break;
                }
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
                ShowMsgReadLine();

                try
                {
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
                    else if (nowAction == 5)
                    {
                        EnterRest(ref _player);
                    }
                    else if (nowAction == 6)
                    {
                        EnterDungeon(ref _player);
                    }
                    else
                    {
                        Console.Clear();
                        ShowMsgWrongValue();
                    }
                }

                catch (FormatException)
                {
                    Console.Clear();
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
                Console.WriteLine($"무기: {_player.inventory.weapon.Name}");
                Console.WriteLine($"머리: {_player.inventory.head.Name}");
                Console.WriteLine($"상의: {_player.inventory.top.Name}");
                Console.WriteLine($"하의: {_player.inventory.bottom.Name}");
                Console.WriteLine();
                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine("1. 장비 장착");
                Console.WriteLine("2. 장비 해제");
                Console.WriteLine();
                ShowMsgReadLine();

                //숫자를 입력했을 경우
                try
                {
                    int nowAction = int.Parse(Console.ReadLine());
                    //뒤로가기
                    if (nowAction == 0)
                    {
                        break;
                    }

                    //장비 장착
                    else if (nowAction == 1)
                    {
                        EnterChangeEquipment(ref _player);
                    }

                    //장비 해제
                    else if (nowAction == 2)
                    {
                        break;
                    }
                    
                    //없는 숫자를 입력했을 경우
                    else
                    {
                        Console.Clear();
                        ShowMsgWrongValue();
                    }
                }
                //숫자가 아닌 것을 입력했을 경우
                catch (FormatException)
                {
                    Console.Clear();
                    ShowMsgWrongValue();
                }
            }
        }

        public static void EnterChangeEquipment(ref Player _player)
        {
            int nowPage = 1;    //현재 페이지
            int maxPage = 1;    //최대 페이지
            while (true)
            {
                Console.Clear();
                
                //아이템이 없을 경우 돌아가기
                if (_player.inventory.items.Count < 1)
                {
                    Console.Clear();
                    Console.WriteLine("현재 아이템이 없습니다.");
                    ShowMsgContinue();
                    break;
                }
                
                //아이템이 5개보다 많을 경우 페이지 증가
                if (_player.inventory.items.Count > 5)
                {
                    maxPage = (int)MathF.Ceiling(_player.inventory.items.Count / 5.0f);
                }
                //아이템이 5개 이하일 경우 최대 페이지는 1개
                else maxPage = 1;


                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine();

                //현재 페이지가 마지막 페이지가 아닐 경우 아이템 5개 표시
                if (nowPage != maxPage)
                {
                    for (int i = 0; i < 5; i ++)
                    {
                        Console.WriteLine($"{i+1}. {_player.inventory.items[((nowPage - 1) * 5) + (i)].Name}");
                    }

                    Console.WriteLine();
                    if (nowPage > 1)
                    {
                        Console.WriteLine("6. 이전 페이지");
                    }
                    if (maxPage > nowPage)
                    {
                        Console.WriteLine("7. 다음 페이지");
                    }

                }

                //현재 페이지가 마지막 페이지일 경우 5개보다 적은 아이템을 표시할 수도 있음
                else
                {
                    if ((_player.inventory.items.Count / 5.0f) % 5 == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine($"{i+1}. {_player.inventory.items[((nowPage - 1) * 5) + (i)].Name}");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _player.inventory.items.Count - 5 * (int)(_player.inventory.items.Count / 5); i++)
                        {
                            Console.WriteLine($"{i+1}. {_player.inventory.items[((nowPage - 1) * 5) + (i)].Name}");
                        }
                    }

                    Console.WriteLine();
                    if (nowPage > 1)
                    {
                        Console.WriteLine("6. 이전 페이지");
                    }
                    if (maxPage > nowPage)
                    {
                        Console.WriteLine("7. 다음 페이지");
                    }
                }

                //번호 입력
                try
                {
                    ShowMsgReadLine();
                    int nowAction = int.Parse(Console.ReadLine());
                    if (nowAction == 0) break;

                    //아이템 선택 시
                    else if (nowAction > 0 && nowAction < 6)
                    {

                        if (nowAction == 1)
                        {
                            _player.EquipItem(_player.inventory.items[0]);
                            break;
                        }
                            
                        //번호 선택을 올바르게 했을 경우
                        if (_player.inventory.items.Count > (nowPage - 1) * 5 + (nowAction - 1))
                        {
                            
                        }
                        
                        //없는 번호를 선택했을 경우
                        else
                        {
                            Console.Clear();
                            ShowMsgWrongValue();
                        }
                    }

                    //이전 페이지
                    else if (nowAction == 6)
                    {
                        nowPage--;
                    }

                    //다음 페이지
                    else if (nowAction == 7)
                    {
                        nowPage++;
                    }

                    //없는 번호를 선택했을 경우
                    else
                    {
                        Console.Clear();
                        ShowMsgWrongValue();
                    }
                }

                //숫자가 아닌 다른 것을 입력했을 때
                catch (FormatException)
                {
                    Console.Clear();
                    ShowMsgWrongValue();
                }
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
                ShowMsgReadLine();
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
                break;
            }
        }

        public static void ShowMsgReadLine()
        {
            Console.WriteLine("다음 행동을 선택해주세요.");
            Console.Write("입력: ");
        }

        public static void ShowMsgWrongValue()
        {
            Console.WriteLine("올바른 값을 입력하세요.");
            Console.WriteLine("계속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }
        
        public static void ShowMsgContinue()
        {
            Console.WriteLine();
            Console.Write("계속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }

    }
}