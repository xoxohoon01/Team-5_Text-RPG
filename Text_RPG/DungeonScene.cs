using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public static class DungeonScene
    {
        public static int gameSpeed = 2;
        public static bool isAlive = true;

        public static void EnterDungeon(ref Player _player)         //던장입장 추가
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0. 뒤로가기");
                Console.WriteLine();
                Console.WriteLine("1. 초급던전");
                Console.WriteLine("2. 중급던전");
                Console.WriteLine("3. 상급던전");
                Console.WriteLine();
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");

                try
                {
                    int nowAction = int.Parse(Console.ReadLine());
                    if (nowAction == 0) break;
                    else if (nowAction == 1)
                    {
                        Program.DrawBox();
                        Program.messageListOnBattle.Clear();
                        Thread.Sleep(1000 / gameSpeed);
                        Program.ShowMsgOnBattle("초급 던전에 입장하셨습니다.");
                        Thread.Sleep(1000 / gameSpeed);
                        EncountMonster(ref _player, 1);
                    }
                    else if (nowAction == 2)
                    {
                        Program.DrawBox();
                        Program.messageListOnBattle.Clear();
                        Thread.Sleep(1000 / gameSpeed);
                        Program.ShowMsgOnBattle("중급 던전에 입장하셨습니다.");
                        Thread.Sleep(1000 / gameSpeed);
                        EncountMonster(ref _player, 2);
                    }
                    else if (nowAction == 3)
                    {
                        Program.DrawBox();
                        Program.messageListOnBattle.Clear();
                        Thread.Sleep(1000 / gameSpeed);
                        Program.ShowMsgOnBattle("고급 던전에 입장하셨습니다.");
                        Thread.Sleep(1000 / gameSpeed);
                        EncountMonster(ref _player, 3);
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

                if (isAlive == false)
                {
                    isAlive = true;
                    break;
                }
            }
        }

        public static void EncountMonster(ref Player _player, int _difficulty)
        {
            int unitCount = 3;

            while (true)
            {
                //일반 몬스터
                if (unitCount > 1)
                {
                    int randomRace = Program.random.Next(5);
                    string monsterName = "";
                    switch (randomRace)
                    {
                        case 0:
                            monsterName = "고블린";
                            break;
                        case 1:
                            monsterName = "오크";
                            break;
                        case 2:
                            monsterName = "슬라임";
                            break;
                        case 3:
                            monsterName = "트롤";
                            break;
                        case 4:
                            monsterName = "새끼 용";
                            break;
                    }
                    Monster newMonster = new Monster(monsterName, _difficulty, 1); //임시 몬스터, 몬스터 설정 이후 지울 것
                    
                    //난이도별 몬스터 드랍 골드
                    if (_difficulty == 1) newMonster.Gold = Program.random.Next(180, 221);
                    else if (_difficulty == 2) newMonster.Gold = Program.random.Next(280, 321);
                    else if (_difficulty == 3) newMonster.Gold = Program.random.Next(480, 521);

                    Console.Clear();
                    Program.ShowMsgOnBattle($"{newMonster.Name}이(가) 나타났습니다!");
                    Thread.Sleep(1000 / gameSpeed);
                    Program.ShowMsgOnBattle("");
                    Thread.Sleep(1000 / gameSpeed);
                    bool isClear = StartBattle(ref _player, ref newMonster);
                    if (isClear)
                    {
                        unitCount--;
                    }
                    else
                    {
                        isAlive = false;
                        break;
                    }
                }

                //보스몬스터
                else if (unitCount == 1)
                {
                    int randomRace = Program.random.Next(5);
                    string monsterName = "";
                    switch (randomRace)
                    {
                        case 0:
                            monsterName = "고블린 왕";
                            break;
                        case 1:
                            monsterName = "오크 우두머리";
                            break;
                        case 2:
                            monsterName = "킹슬라임";
                            break;
                        case 3:
                            monsterName = "거대트롤";
                            break;
                        case 4:
                            monsterName = "드래곤";
                            break;
                    }
                    Monster newMonster = new Monster(monsterName, _difficulty, 2); //임시 몬스터, 몬스터 설정 이후 지울 것

                    //난이도별 몬스터 드랍 골드
                    if (_difficulty == 1) newMonster.Gold = Program.random.Next(180, 221);
                    else if (_difficulty == 2) newMonster.Gold = Program.random.Next(280, 321);
                    else if (_difficulty == 3) newMonster.Gold = Program.random.Next(480, 521);

                    Console.Clear();
                    Program.ShowMsgOnBattle($"{newMonster.Name}이(가) 나타났습니다!");
                    Thread.Sleep(1000 / gameSpeed);
                    Program.ShowMsgOnBattle("");
                    Thread.Sleep(1000 / gameSpeed);
                    bool isClear = StartBattle(ref _player, ref newMonster);
                    if (isClear)
                    {
                        unitCount--;
                    }
                    else
                    {
                        isAlive = false;
                        break;
                    }
                }
                else
                {
                    Program.ShowMsgOnBattle("던전을 클리어했습니다!");
                    Thread.Sleep(1000 / gameSpeed);
                    Program.ShowMsgOnBattle("마을로 돌아갑니다.");
                    Thread.Sleep(1000 / gameSpeed);
                    Console.WriteLine("계속하려면 아무 키나 입력하세요.");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public static bool StartBattle(ref Player _player, ref Monster _monster)
        {
            while (true)
            {
                if (_player.Speed > _monster.Speed)
                {
                    Program.ShowMsgOnBattle($"{_player.Name}의 턴!");
                    Thread.Sleep(1000 / gameSpeed);

                    PlayerTurn(ref _player, ref _monster);
                    Thread.Sleep(1000 / gameSpeed);

                    Program.ShowMsgOnBattle("");
                    Thread.Sleep(1000 / gameSpeed);

                    if (_monster.HP <= 0)
                    {
                        KillMonster(ref _player, ref _monster);
                        return true;
                    }

                    Program.ShowMsgOnBattle($"{_monster.Name}의 턴!");
                    Thread.Sleep(1000 / gameSpeed);

                    MonsterTurn(ref _player, ref _monster);
                    Thread.Sleep(1000 / gameSpeed);

                    Program.ShowMsgOnBattle("");
                    Thread.Sleep(1000 / gameSpeed);

                    if (_player.HP <= 0)
                    {
                        isAlive = false;
                        KillPlayer(ref _player, ref _monster);
                        Console.WriteLine("계속하려면 아무 키나 입력하세요.");
                        Console.ReadKey();
                        return false;
                    }
                }
                else
                {
                    Program.ShowMsgOnBattle($"{_monster.Name}의 턴!");
                    Thread.Sleep(1000 / gameSpeed);

                    MonsterTurn(ref _player, ref _monster);
                    Thread.Sleep(1000 / gameSpeed);

                    Program.ShowMsgOnBattle("");
                    Thread.Sleep(1000 / gameSpeed);

                    if (_player.HP <= 0)
                    {
                        isAlive = false;
                        KillPlayer(ref _player, ref _monster);
                        return false;
                    }

                    Program.ShowMsgOnBattle($"{_player.Name}의 턴!");
                    Thread.Sleep(1000 / gameSpeed);

                    PlayerTurn(ref _player, ref _monster);
                    Thread.Sleep(1000 / gameSpeed);

                    Program.ShowMsgOnBattle("");
                    Thread.Sleep(1000 / gameSpeed);

                    if (_monster.HP <= 0)
                    {
                        KillMonster(ref _player, ref _monster);
                        return true;
                    }
                }
            }
        }

        //플레이어 턴
        public static void PlayerTurn(ref Player _player, ref Monster _monster)
        {
            while (true)
            {
                Program.ShowMsgOnBattle();
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 아이템");
                Console.WriteLine("4. 도망");
                Console.WriteLine("");
                Console.Write("선택: ");

                bool isDoneActing = false;

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 0)
                    {
                        break;
                    }
                    else if (choice == 1)
                    {
                        isDoneActing = PlayerAttackToMonster(ref _player, _monster);
                    }
                    else if (choice == 2)
                    {
                        isDoneActing = SelectSkill(ref _player, ref _monster);
                    }
                    
                    //아이템 사용 미구현
                    else if (choice == 3)
                    {
                    }
                    else if (choice == 4)
                    {
                        if (SelectRun(ref _player, _monster))
                        {
                            _monster.HP = 0; // 도망 성공 시 전투 종료를 위해
                        }
                    }
                    else
                    {
                        Program.ShowMsgOnBattle();
                        Program.ShowMsgWrongValue();
                    }

                    if (isDoneActing) break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Program.ShowMsgWrongValue();
                }
            }
        }

        //몬스터 턴 (기본공격)
        public static void MonsterTurn(ref Player _player, ref Monster _monster)
        {
            Program.ShowMsgOnBattle($"{_monster.Name}의 공격!");
            Thread.Sleep(1000 / gameSpeed);

            int monsterDamage = Math.Max(1, _monster.Damage - _player.Defense - _player.TotalDefenseBonus()); //몬스터 데미지
            if (Program.random.NextDouble() > _player.DodgeChance(_monster.Speed)) //공격을 회피
            {
                _player.HP -= monsterDamage;
                Program.ShowMsgOnBattle($"{_monster.Name}이(가) {_player.Name}에게 {monsterDamage}의 데미지를 입혔습니다.");
            }
            else
            {
                Program.ShowMsgOnBattle($"{_monster.Name}의 공격을 회피했습니다!");
            }
        }

        public static bool PlayerAttackToMonster(ref Player _player, Monster _monster)     // 1. 공격 , Monster.cs 맞게 수정
        {
            Program.ShowMsgOnBattle($"{_player.Name}의 공격!");
            Thread.Sleep(1000 / gameSpeed);

            //기본 데미지 계산 (플레이어 최종 공격력 - 몬스터 최종 방어력)
            int finalDamage = _player.Damage + _player.TotalDamageBonus() - _monster.Defense;
            finalDamage = Math.Max(1, finalDamage); //최소 1의 데이지                                       

            //크리티컬 데미지 계산
            double criticalChance = _player.CriticalChance + _player.TotalCriticalCanceBonus(); //크리티컬 확률
            if (Program.random.NextDouble() < criticalChance)
            {
                double criticalMultiplier = _player.CriticalDamage + _player.TotalCriticalDamageBonus(); //크리티컬 데미지 계수
                finalDamage = (int)(finalDamage * criticalMultiplier); //크리티컬 데미지 계산 (최종 데미지 * 크리티컬 데미지 계수)
                Program.ShowMsgOnBattle("치명타!");
            }

            _monster.HP -= finalDamage;
            Program.ShowMsgOnBattle($"{_player.Name}이(가) {_monster.Name}에게 {finalDamage}의 데미지를 입혔습니다.");
            return true;
        }

        public static bool SelectSkill(ref Player _player, ref Monster _monster)
        {
            while (true)
            {
                Program.ShowMsgOnBattle();
                Console.WriteLine("0. 뒤로가기");
                for (int i = 0; i < _player.skillList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_player.skillList[i].Name} (Base Damage: {_player.skillList[i].BaseDamage})");
                }

                string answer = Console.ReadLine();
                try
                {
                    int nowAction = int.Parse(answer);
                    if (nowAction == 0) return false;
                    else if (nowAction > 0 && nowAction <= _player.skillList.Count)
                    {
                        Skill selectedSkill = _player.skillList[nowAction - 1];
                        int baseDamage = selectedSkill.BaseDamage;
                        int attackerDamage = _player.Damage;  // Player의 Damage 사용
                        bool isUsedSkill = selectedSkill.UseSkill(ref _player, ref _monster);
                        if (isUsedSkill)
                        {

                            return true;
                        }
                        else return false;
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


        public static void SelectItem(ref Player _player)      // 3. 아이템 : 미 구 현
        {
            Console.Clear();
            Console.WriteLine("아이템 사용은 아직 구현 되지 않았습니다.");
            Console.ReadKey();

        }

        public static bool SelectRun(ref Player _player, Monster _monster)      // 4. 도망 , Monster.cs에 맞게 수정
        {
            int escapeChance = 50 + (_player.Speed - _monster.Speed) * 5;       //기본 +(플레이어 스피드-몬스터 스피드) * 5
            escapeChance = Math.Clamp(escapeChance, 10, 90);                    //확률 : 최소 10퍼 ~ 최대 90퍼

            if (Program.random.Next(100) < escapeChance)
            {
                Console.WriteLine("도망에 성공했습니다!");
                return true;
            }
            else
            {
                Console.WriteLine("도망에 실패했습니다!");
                return false;
            }
        }


        public static void KillMonster(ref Player _player, ref Monster _monster)
        {
            Program.ShowMsgOnBattle($"{_monster.Name}을(를) 처치하였습니다!");
            Thread.Sleep(1000 / gameSpeed);
            Program.ShowMsgOnBattle("");
            Thread.Sleep(1000 / gameSpeed);
            ClearRewards(ref _player, ref _monster);
        }

        public static void KillPlayer(ref Player _player, ref Monster _monster)
        {
            Program.ShowMsgOnBattle($"{_player.Name}이(가) {_monster.Name}에게 당했습니다!");
            Program.ShowMsgOnBattle("");
            Thread.Sleep(1000 / gameSpeed);
            Program.ShowMsgOnBattle($"던전 공략에 실패했습니다.");
            Thread.Sleep(1000 / gameSpeed);
            Program.ShowMsgOnBattle($"병원에서 눈을 떴습니다.");
            Thread.Sleep(1000 / gameSpeed);

            _player.HP = _player.MaxHP/2; //부활 직후 체력 절반 깎이는 패널티
            _player.MP = _player.MaxMP;
            Program.ShowMsgOnBattle($"현재 체력: {_player.MaxHP / 2}");
            Console.WriteLine("계속하려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }

        private static void ClearRewards(ref Player _player, ref Monster _monster)        //클리어 보상 추가
        {

            _player.Gold += _monster.Gold;
            Program.ShowMsgOnBattle($"{_monster.Gold} 골드를 획득했습니다!");
            Thread.Sleep(1000 / gameSpeed);
            Program.ShowMsgOnBattle("");
            Thread.Sleep(1000 / gameSpeed);

            if (_monster.dropItem != new Item())
            {
                _player.inventory.itemList.Add(_monster.dropItem);
            }

            int dropChance = 20;    // 아이템 드롭률 25 + 15 * 난이도 
            // 아이템 보상
            if (Program.random.Next(100) < dropChance)  // 확률로 아이템 드롭
            {
                Item item = new Item();
                _player.inventory.GetItem(item); //획득 아이템 바꿀 것
                Program.ShowMsgOnBattle($"'{item.Name}'을(를) 획득했습니다!");
                Thread.Sleep(1000 / gameSpeed);
                Program.ShowMsgOnBattle("");
                Thread.Sleep(1000 / gameSpeed);
            }
        }

    }
}
