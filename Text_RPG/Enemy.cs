namespace TextRPG
{
    class Monster : Unit
    {
<<<<<<< HEAD
        public Monster(string _name = "")
=======
        public string Name;
        public int Hp, MaxHp;
        public int Mp, MaxMp;
        public int Damage, Armor, Speed;
        public int CritChance, CritDamage;

        public bool IsAlive => hp > 0;
        public Monster(string type) { 
            switch (type.ToLower())
            {
                case "goblin":
                    //일반 몬스터 - 고블린
                    name = "Goblin";
                    hp = 50;
                    maxHp = 50;
                    mp = 10;
                    maxMp = 10;
                    damage = 15;
                    armor = 5;
                    speed = 8;
                    critChance = 10;
                    critDamage = 20;
                    break;

                case "orc":
                    // 일반 몬스터 - 오크
                    name = "Orc";
                    hp = 100;
                    maxHp = 100;
                    mp = 5;
                    maxMp = 5;
                    damage = 25;
                    armor = 15;
                    speed = 4;
                    critChance = 5;
                    critDamage = 30;
                    break;

                case "boss":
                    // 보스 몬스터 - 미정
                    name = "Boss";
                    hp = 300;
                    maxHp = 300;
                    mp = 20;
                    maxMp = 20;
                    damage = 50;
                    armor = 25;
                    speed = 3;
                    critChance = 15;
                    critDamage = 50;
                    break;
                    
                default:
                    // 알 수 없는 타입
                    name = "Unknown";
                    hp = 0;
                    maxHp = 0;
                    mp = 0;
                    maxMp = 0;
                    damage = 0;
                    armor = 0;
                    speed = 0;
                    critChance = 0;
                    critDamage = 0;
                    break;
            }
        }
                    public void Battle(Player player, Unit enemy)
>>>>>>> hynu_dev
        {
            // 속도가 높은 유닛이 먼저 공격
            bool playerTurn = player.Speed >= Monster.speed;

<<<<<<< HEAD
            hp = 0;
            maxHp = 0;
            mp = 0;
            maxMp = 0;

            damage = 0;
            armor = 0;
            speed = 0;
            critChance = 0;
            critDamage = 0;
=======
            while (player.Hp > 0 && enemy.hp > 0)
            {
                if (playerTurn)
                {
                    // 플레이어가 먼저 공격
                    int actualDamage = player.Damage - enemy.armor;
                    if (actualDamage < 0) actualDamage = 0;

                    enemy.hp -= actualDamage;
                    Console.WriteLine($"{player.Name} attacks {enemy.name} for {actualDamage} damage!");

                    if (enemy.hp <= 0)
                    {
                        Console.WriteLine($"{enemy.name} has been defeated!");
                        break;
                    }
                }
                else
        {
                    // 적이 먼저 공격
                    int actualDamage = enemy.damage - player.Defense;
                    if (actualDamage < 0) actualDamage = 0;

                    player.Hp -= actualDamage;
                    Console.WriteLine($"{enemy.name} attacks {player.Name} for {actualDamage} damage!");

                    if (player.Hp <= 0)
                    {
                        Console.WriteLine($"{player.Name} has been defeated!");
                        break;
                    }
        }
    
                // 턴 교체
                playerTurn = !playerTurn;

                // 상태 출력 (선택 사항)
                Console.WriteLine($"{player.Name} HP: {player.Hp} / {player.MaxHp}");
                Console.WriteLine($"{enemy.name} HP: {enemy.hp} / {enemy.maxHp}");
            }
      }
        public void OnAttack(ref Player _player)
        {
            int damageTaken = damage - (_player.Defense + _player.TotalDefenseBonus());
            if (damageTaken < 0) damageTaken = 0; // 피해가 0보다 작으면 0으로 설정

            _player.Hp -= damageTaken; // 플레이어의 HP에서 실제 피해를 빼기
            Console.WriteLine($"{name} attacks {_player.Name} for {damageTaken} damage!");
        }
    }
}