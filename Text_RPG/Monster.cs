namespace TextRPG
{
    class Monster : Unit
    {
        public string Name;
        public int HP, MaxHP;
        public int MP, MaxMP;
        public int Damage, Armor, Speed;
        public int CritChance, CritDamage;

        public bool IsAlive => HP > 0;
        public Monster(string type)
        { 
            switch (type.ToLower())
            {
                case "goblin":
                    //일반 몬스터 - 고블린
                    name = "Goblin";
                    HP = 50;
                    MaxHP = 50;
                    MP = 10;
                    MaxMP = 10;
                    Damage = 15;
                    Defense = 5;
                    Speed = 8;
                    CritChance = 10;
                    CritDamage = 20;
                    break;

                case "orc":
                    // 일반 몬스터 - 오크
                    name = "Orc";
                    HP = 100;
                    MaxHP = 100;
                    MP = 5;
                    MaxMP = 5;
                    Damage = 25;
                    Defense = 15;
                    Speed = 4;
                    CritChance = 5;
                    CritDamage = 30;
                    break;

                case "boss":
                    // 보스 몬스터 - 미정
                    name = "Boss";
                    HP = 300;
                    MaxHP = 300;
                    MP = 20;
                    MaxMP = 20;
                    Damage = 50;
                    Defense = 25;
                    Speed = 3;
                    CritChance = 15;
                    CritDamage = 50;
                    break;

                default:

                    // 알 수 없는 타입
                    name = "Unknown";
                    HP = 0;
                    MaxHP = 0;
                    MP = 0;
                    MaxMP = 0;
                    Damage = 0;
                    Defense = 0;
                    Speed = 0;
                    CritChance = 0;
                    CritDamage = 0;
                    break;
            
            }
        }
        public void Battle(Player player, Unit enemy)
        {
            // 속도가 높은 유닛이 먼저 공격
            bool playerTurn = player.Speed >= this.Speed;

            while (player.HP > 0 && enemy.HP > 0)
            {
                if (playerTurn)
                {
                    // 플레이어가 먼저 공격
                    int actualDamage = player.Damage - enemy.Defense;
                    if (actualDamage < 0) actualDamage = 0;

                    enemy.HP -= actualDamage;
                    Console.WriteLine($"{player.Name} attacks {enemy.name} for {actualDamage} damage!");

                    if (enemy.HP <= 0)
                    {
                        Console.WriteLine($"{enemy.name} has been defeated!");
                        break;
                    }
                }
                else
        {
                    // 적이 먼저 공격
                    int actualDamage = enemy.Damage - player.Defense;
                    if (actualDamage < 0) actualDamage = 0;

                    player.HP -= actualDamage;
                    Console.WriteLine($"{enemy.name} attacks {player.Name} for {actualDamage} damage!");

                    if (player.HP <= 0)
                    {
                        Console.WriteLine($"{player.Name} has been defeated!");
                        break;
                    }
        }
    
                // 턴 교체
                playerTurn = !playerTurn;

                // 상태 출력 (선택 사항)
                Console.WriteLine($"{player.Name} HP: {player.HP} / {player.MaxHP}");
                Console.WriteLine($"{enemy.name} HP: {enemy.HP} / {enemy.MaxHP}");
            }
      }
        public void OnAttack(ref Player _player)
        {
            int damageTaken = Damage - (_player.Defense + _player.TotalDefenseBonus());
            if (damageTaken < 0) damageTaken = 0; // 피해가 0보다 작으면 0으로 설정

            _player.HP -= damageTaken; // 플레이어의 HP에서 실제 피해를 빼기
            Console.WriteLine($"{name} attacks {_player.Name} for {damageTaken} damage!");
        }
    }
}