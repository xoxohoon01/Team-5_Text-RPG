using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public static class Tutorial
    {
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

                    try
                    {
                        int classType = int.Parse(Console.ReadLine());
                        if (classType > 0 && classType <= 4)
                        {
                            _player.PlayerJob = (Job)classType;
                            _player.InitializeStats();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Program.ShowMsgWrongValue();
                    }

                }
                else break;
            }
        }
    }
}
