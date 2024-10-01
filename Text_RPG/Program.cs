using Microsoft.VisualBasic;
using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace TextRPG
{
    
    internal class Program
    {
        public static Random random = new Random();         //Random 객체 생성
        static void Main()
        {
            Player player = new Player();
            Item newItem = new Item();
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
                else if (nowAction == 5)
                {
                    ShowMsgWrongValue();
                }
                else if (nowAction ==6)     //던전입장 추가
                {
                    EnterDungeon(ref _player);
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

        public static void EnterDungeon(ref Player _player)         //던장입장 추가
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.WriteLine("\n1. 초급던전");
                Console.WriteLine("2. 중급던전");
                Console.WriteLine("3. 상급던전");
                Console.WriteLine("\n0. 뒤로가기");
                int nowAction = int.Parse(Console.ReadLine()) - 1;
                if (nowAction == 0) break;
                else if (nowAction == 1)
                {
                    EnterDungeonBeginner(ref _player);
                }
                else if (nowAction == 2)
                {
                    EnterDungeonIntermediate(ref _player);
                }
                else if(nowAction == 3)
                {
                    EnterDungeonAdvanced(ref _player);
                }
                else
                {
                    ShowMsgWrongValue();
                }
            }
        }
        public static void EnterDungeonBeginner(ref Player _player)        //초급던전 추가
        {
            Console.Clear();
            Console.WriteLine("초급던전에 입장하셨습니다.");
            int stage = 1;                                                  
            int unitCount = 2 + stage * 2;
            if (ClearDungeon(ref _player, stage, unitCount))
            {
                ClearRewards(ref _player, stage);
            }
            else
            {
                ReducePlayerHpAfterFailure(ref _player);
            }
        }
        public static void EnterDungeonIntermediate(ref Player _player)       //중급던전 추가
        {
            Console.Clear();
            Console.WriteLine("중급던전에 입장하셨습니다.");
            int stage = 2;                                                    // 스테이지 구분
            int unitCount = 2 + stage * 2;                                    // 유닛 카운트 2+ 스테이지레벨 * 2
            if (ClearDungeon(ref _player, stage, unitCount))
            {
                ClearRewards(ref _player, stage);
            }
            else
            {
                ReducePlayerHpAfterFailure(ref _player);
            }
        }
        public static void EnterDungeonAdvanced(ref Player _player)       //상급던전 추가
        {
            Console.Clear();
            Console.WriteLine("상급던전에 입장하셨습니다.");
            int stage = 3;
            int unitCount = 2 + stage * 2;
            if (ClearDungeon(ref _player, stage, unitCount))
            {
                ClearRewards(ref _player, stage);
            }
            else
            {
                ReducePlayerHpAfterFailure(ref _player);
            }

        }
        public static bool ClearDungeon(ref Player _player, int _stage, int _unitCount)     //던전 클리어 추가
        {
            for (int i = 1; i <= _unitCount; i++)                                           //몬스터 카운트다운
            {
                Console.WriteLine($"\n{i}번째 유닛과 조우했습니다!");
                if (!PkmStyleBattle(ref _player, _stage))                                   //포켓몬 스타일 배틀
                {
                    Console.WriteLine("던전 탐험에 실패했습니다.");
                    return false;
                }
            }
            Console.WriteLine("던전을 클리어했습니다!");
            return true;
        }
        public static bool PkmStyleBattle(ref Player _player, int _stage)      //포켓몬 스타일 배틀 추가
        {
            //Monster _monster = GenerateMonster(_stage);                      //몬스터.cs 에 맞춰서 수정
            Console.WriteLine($"{_monster.Name}가 나타났다.");
            bool playerFirst = DetermineFirstAttack(ref _player, _monster);

            while (_monster.HP > 0 && _player.HP > 0)
            {
                Console.WriteLine($"체력: {_player.HP}, 마나: {_player.MP}, \n{_monster.Name} 체력: {_monster.HP}");

                if (playerFirst)
                {
                    Console.WriteLine($"{_player.Name}의 선제공격!");
                    PlayerTurn(ref _player, _monster);
                    if (_monster.HP <= 0) break;
                    MonsterAttack(ref _player, _monster);
                }
                else
                {
                    MonsterAttack(ref _player, _monster);
                    if (_player.HP <= 0) break;
                    PlayerTurn(ref _player, _monster);
                }

                playerFirst = true; // 첫 턴 이후에는 항상 플레이어가 먼저 행동
            }

            if (_player.HP <= 0)
            {
                Console.WriteLine("전투에서 패배했습니다...");
                return false;
            }
            else
            {
                Console.WriteLine($"{_monster.Name}을(를) 물리쳤습니다!");
                return true;
            }
        }

        static void PlayerTurn(ref Player _player, Monster _monster)        //Monster.cs 맞게 수정
        {
            Console.WriteLine("\n1. 공격");
            Console.WriteLine("2. 스킬");
            Console.WriteLine("3. 아이템");
            Console.WriteLine("4. 도망");
            Console.Write("\n선택: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AttackMonster(ref _player, _monster);
                    break;
                case 2:
                    // SelectSkill(player, monster); // 스킬 사용 기능 구현 필요
                    Console.WriteLine("스킬 사용 기능은 아직 구현되지 않았습니다.");
                    break;
                case 3:
                    // SelectItem(player); // 아이템 사용 기능 구현 필요
                    Console.WriteLine("아이템 사용 기능은 아직 구현되지 않았습니다.");
                    break;
                case 4:
                    if (SelectRun(ref _player, _monster))
                    {
                        _monster.HP = 0; // 도망 성공 시 전투 종료를 위해
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 공격으로 대체합니다.");
                    AttackMonster(ref _player, _monster);
                    break;
            }
        }

        public static void AttackMonster(ref Player _player, Monster _monster)     // 1. 공  격 , Monster.cs 맞게 수정
        {
            int attack = _player.Damage + _player.TotalDamageBonus() - _monster.Defense;        // 데미지(총합 - 몬스터 방어력)
            attack = Math.Max(1, attack);       //최소 1의 데이지                                       
            double criticalChance = _player.CriticalChance + _player.TotalCriticalCanceBonus();     //크리티컬 확률
            
            if (random.NextDouble() < criticalChance)
            {
                double criticalMultiplier = _player.CriticalDamage + _player.TotalCriticalDamageBonus();        // 크리티컬데미지
                attack = (int)(attack * criticalMultiplier);
                Console.WriteLine("치명타!");
            }

            _monster.HP -= attack;
            Console.WriteLine($"당신이 {_monster.Name}에게 {attack}의 데미지를 입혔습니다.");
        }

        public static void MonsterAttack(ref Player _player, Monster _monster)      //몬스터가 유저를 공격 , Monster.cs에 맞게 수정
        {
            int mdamage = Math.Max(1, _monster.Damage - _player.Defense - _player.TotalDefenseBonus());     //몬스터 데미지
            if (random.NextDouble() > _player.DodgeChance())        //공격을 회피
            {
                _player.HP -= mdamage;
                Console.WriteLine($"{_monster.Name}이(가) 당신에게 {mdamage}의 데미지를 입혔습니다.");
            }
            else
            {
                Console.WriteLine($"{_monster.Name}의 공격을 회피했습니다!");
            }
        }
        static bool DetermineFirstAttack(ref Player _player, Monster _monster)      //스피드 선제공격권 , Monster.cs 맞게 수정
        {
            int _playerSpeed = _player.Speed + _player.TotalSpeedBonus();           //유저스피드 : 스탯 + 장비최종 + 스피드
            int speedDifference = _playerSpeed - _monster.Speed;                    //스피드차이 : 유저스피드 - 몬스터스피드

            if (speedDifference > 0)                                                //스피드 차이 > 0   트루값
            {
                return true;
            }
            else if (speedDifference < 0)                                           //스피드 차이 < 0   실패값
            {
                return false;
            }
            else                                                                    //스피드가 동률일때, 랜덤으로 결정
            {
                return random.Next(2) == 0;
            }
        }
        public static void SelectSkill(ref Player _player)     // 2. 스  킬 : 미 구 현
        {
            Console.Clear();
            Console.WriteLine("스킬 사용은 아직 구현 되지 않았습니다.");
            Console.ReadKey();

        }
        public static void SelectItem(ref Player _player)      // 3. 아이템 : 미 구 현
        {
            Console.Clear();
            Console.WriteLine("아이템 사용은 아직 구현 되지 않았습니다.");
            Console.ReadKey();

        }
        public static bool SelectRun(ref Player _player, Monster _monster)      // 4. 도  망 , Monster.cs에 맞게 수정
        {
            int escapeChance = 50 + (_player.Speed - _monster.Speed) * 5;       //기본 +(플레이어 스피드-몬스터 스피드) * 5
            escapeChance = Math.Clamp(escapeChance, 10, 90);                    //확률 : 최소 10퍼 ~ 최대 90퍼

            if (random.Next(100) < escapeChance)
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


        private static void ClearRewards(ref Player _player, int _stage)        //클리어 보상 추가
        {
        
            // 골드 보상
            int goldEarned = _stage * 100 + random.Next(1, 101);  // 기본 골드 + 랜덤 보너스
            _player.Gold += goldEarned;
            Console.WriteLine($"{goldEarned} 골드를 획득했습니다!");

            int dropChance = 25 + (_stage * 15);    // 아이템 드롭률 25 + 15 * 난이도 
            // 아이템 보상
            if (random.Next(100) < dropChance)  // 확률로 아이템 드롭
            {
                Item item = GetItem(_stage);
                _player.inventory.GetItem(item);
                Console.WriteLine($"'{item.Name}'을(를) 획득했습니다! - {item.Description}");
            }

            Console.ReadKey();
        }
        public static void ReducePlayerHpAfterFailure(ref Player _player)       //던전 실패시 체력 50%감소
        {
            int reducedHp = _player.HP / 2;
            _player.HP = Math.Max(1, reducedHp); // 최소 1의 체력은 유지
            Console.WriteLine($"던전 탐험 실패로 체력이 50% 감소했습니다. 현재 체력: {_player.HP}/{_player.MaxHP}");
            Console.WriteLine("아무 키나 눌러 계속하세요...");
            Console.ReadKey();
        }
       
        public static void ShowMsgWrongValue()
        {
            Console.WriteLine("올바른 값을 입력하세요.");
            Console.WriteLine("계속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }
        
    }
}