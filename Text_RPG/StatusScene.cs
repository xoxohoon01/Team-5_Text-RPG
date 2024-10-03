using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class StatusScene
    {
        public static void EnterStatus(ref Player _player)
        {
            while (true)
            {
                if (Program.hasPlayer == false) break; //캐릭터 삭제 시 게임 재시작

                Console.Clear();
                Console.WriteLine($"이름: {_player.Name}");
                Console.WriteLine($"직업: {_player.PlayerJob}");
                Console.WriteLine($"레벨: {_player.Level}");
                Console.WriteLine();
                Console.WriteLine($"HP: {_player.HP}/{_player.MaxHP}");
                Console.WriteLine($"MP: {_player.MP}/{_player.MaxMP}");
                Console.WriteLine();
                Console.WriteLine($"공격력: {_player.Damage} {(_player.TotalDamageBonus() != 0 ? $"(+{_player.TotalDamageBonus()})" : "")}");
                Console.WriteLine($"방어력: {_player.Defense} {(_player.TotalDefenseBonus() != 0 ? $"(+{_player.TotalDefenseBonus()})" : "")}");
                Console.WriteLine($"속도: {_player.Speed} {(_player.TotalSpeedBonus() != 0 ? $"(+{_player.TotalSpeedBonus()})" : "")}");
                Console.WriteLine($"치명타확률: {_player.CriticalChance*100} {(_player.TotalCriticalChanceBonus() != 0 ? $"(+{_player.TotalCriticalChanceBonus()*100})" : "")}");
                Console.WriteLine($"치명타데미지: {_player.CriticalDamage} {(_player.TotalCriticalDamageBonus() != 0 ? $"(+{_player.TotalCriticalDamageBonus()})" : "")}");
                Console.WriteLine();
                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine();
                Console.WriteLine("1. 캐릭터 삭제");
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");

                string answer = Console.ReadLine();
                try
                {
                    int nowAction = int.Parse(answer);

                    if (nowAction == 0) break;
                    else if (nowAction == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("정말 캐릭터를 삭제하시겠습니까? (Y/N)");
                        string answerOfDeleteAccount = Console.ReadLine();
                        if (answerOfDeleteAccount == "Y" ||  answerOfDeleteAccount == "y")
                        {
                            File.Delete("./PlayerData.json");
                            Program.hasPlayer = false;
                            Console.WriteLine("캐릭터가 삭제되었습니다.");
                            Console.WriteLine("계속하시려면 아무 키나 입력하세요.");
                            Console.ReadKey();
                        }
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
