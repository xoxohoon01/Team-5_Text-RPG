namespace TextRPG
{
    class Enemy : Unit
    {
        public string Name;
        public int Hp, MaxHp;
        public int Mp, MaxMp;
        public int Damage, Armor, Speed;
        public int CritChance, CritDamage;

        public bool IsAlive => hp > 0;
        public Enemy(string type) { 
            switch (type.ToLower())
            {
                case "goblin":
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

                default:
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
        void Battle(Player player, Unit enemy)
        {
            // 속도가 높은 유닛이 먼저 공격
            bool playerTurn = player.Speed >= enemy.speed;

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
            _player.Hp = damage - (_player.Defense + _player.TotalDefenseBonus());
        }
    }
}