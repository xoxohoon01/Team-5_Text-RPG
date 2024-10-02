namespace TextRPG
{
    public class Monster : Unit
    {
        public string Name;
        public int HP, MaxHP;
        public int MP, MaxMP;
        public int Damage, Armor, Speed;
        public int CritChance, CritDamage;
        
        public int Gold;
        public Item dropItem;

        public bool IsAlive => HP > 0;
        public Monster(string type)
        { 
            switch (type.ToLower())
            {
                case "goblin":
                    //일반 몬스터 - 고블린
                    Name = "Goblin";
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
                    Name = "Orc";
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
                    Name = "Boss";
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
                    Name = "Unknown";
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

        public Monster(string _name, int _stage, int _type)
        {
            Name = _name;
            HP = _stage * (50 * _type);
            MaxHP = _stage * (50 * _type);
            MP = _stage * (10 * _type);
            MaxMP = _stage * (10 * _type);
            Damage = _stage * (15 * _type);
            Defense = _stage * (5 * _type);
            Speed = _stage * (8 * _type);
            CritChance = _stage * (10 * _type);
            CritDamage = _stage * (20 * _type);

            if (_stage == 1) Gold = Program.random.Next(180, 221);
            else if (_stage == 2) Gold = Program.random.Next(280, 321);
            else if (_stage == 3) Gold = Program.random.Next(480, 521);

            Database itemDatabase = new Database();
            Random random = new Random();

            switch (_stage)
            {
                //초급던전 - (1, 2)단계 아이템 드롭확률
                case 1:
                    //일반몬스터 - (1)단계 아이템 드롭확률
                    if (_type == 1)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    dropItem = itemDatabase.ITEM[9 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    dropItem = itemDatabase.ITEM[25 + (4 * random.Next(0, 4))];
                                    break;
                            }
                        }
                        else dropItem = new Item();
                    }
                    //보스몬스터 - (2)단계 아이템 드롭확률
                    else if (_type == 2)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[8 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[24 + (4 * random.Next(0, 4))];
                                    break;
                            }
                        }
                        else dropItem = new Item();
                    }
                    break;

                //중급던전 - (2, 3)단계 아이템 드롭확률
                case 2:
                    //일반몬스터 - (2)단계 아이템 드롭확률
                    if (_type == 1)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[9 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[25 + (4 * random.Next(0, 4))];
                                    break;
                            }
                        }
                        else dropItem = new Item();
                    }
                    //보스몬스터 - (3)단계 아이템 드롭확률
                    else if (_type == 2)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[10 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[26 + (4 * random.Next(0, 4))];
                                    break;
                            }
                        }
                        else dropItem = new Item();
                    }
                    break;

                //고급던전 - (3, 4)단계 아이템 드롭확률
                case 3:
                    //일반몬스터 - (3)단계 아이템 드롭확률
                    if (_type == 1)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[10 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[26 + (4 * random.Next(0, 4))];
                                    break;
                            }
                        }
                        else dropItem = new Item();
                    }
                    //보스몬스터 - (4)단계 아이템 드롭확률
                    else if (_type == 2)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[11 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[27 + (4 * random.Next(0, 4))];
                                    break;
                            }
                        }
                        else dropItem = new Item();
                    }
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
                    Console.WriteLine($"{player.Name} attacks {enemy.Name} for {actualDamage} damage!");

                    if (enemy.HP <= 0)
                    {
                        Console.WriteLine($"{enemy.Name} has been defeated!");
                        break;
                    }
                }
                else
        {
                    // 적이 먼저 공격
                    int actualDamage = enemy.Damage - player.Defense;
                    if (actualDamage < 0) actualDamage = 0;

                    player.HP -= actualDamage;
                    Console.WriteLine($"{enemy.Name} attacks {player.Name} for {actualDamage} damage!");

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
                Console.WriteLine($"{enemy.Name} HP: {enemy.HP} / {enemy.MaxHP}");
            }
      }
        public void OnAttack(ref Player _player)
        {
            int damageTaken = Damage - (_player.Defense + _player.TotalDefenseBonus());
            if (damageTaken < 0) damageTaken = 0; // 피해가 0보다 작으면 0으로 설정

            _player.HP -= damageTaken; // 플레이어의 HP에서 실제 피해를 빼기
            Console.WriteLine($"{Name} attacks {_player.Name} for {damageTaken} damage!");
        }

        public void OnDeath(ref Player _player, int _stage, int _type)
        {
            Database itemDatabase = new Database();
            Random random = new Random();
            switch(_stage)
            {
                //초급던전 - (1, 2)단계 아이템 드롭확률
                case 1:
                    //일반몬스터 - (1)단계 아이템 드롭확률
                    if (_type == 1)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[9 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[25 + (4 * random.Next(0, 4))];
                                    break;
                            }
                            
                            _player.inventory.GetItem(droppedItem);
                            Program.ShowMsgOnBattle($"{droppedItem.Name}을(를) 획득했습니다.");
                        }
                    }
                    //보스몬스터 - (2)단계 아이템 드롭확률
                    else if (_type == 2)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[8 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[24 + (4 * random.Next(0, 4))];
                                    break;
                            }

                            _player.inventory.GetItem(droppedItem);
                            Program.ShowMsgOnBattle($"{droppedItem.Name}을(를) 획득했습니다.");
                        }
                    }
                    break;

                //중급던전 - (2, 3)단계 아이템 드롭확률
                case 2:
                    //일반몬스터 - (2)단계 아이템 드롭확률
                    if (_type == 1)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[9 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[25 + (4 * random.Next(0, 4))];
                                    break;
                            }

                            _player.inventory.GetItem(droppedItem);
                            Program.ShowMsgOnBattle($"{droppedItem.Name}을(를) 획득했습니다.");
                        }
                    }
                    //보스몬스터 - (3)단계 아이템 드롭확률
                    else if (_type == 2)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[10 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[26 + (4 * random.Next(0, 4))];
                                    break;
                            }

                            _player.inventory.GetItem(droppedItem);
                            Program.ShowMsgOnBattle($"{droppedItem.Name}을(를) 획득했습니다.");
                        }
                    }
                    break;

                //고급던전 - (3, 4)단계 아이템 드롭확률
                case 3:
                    //일반몬스터 - (3)단계 아이템 드롭확률
                    if (_type == 1)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[10 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[26 + (4 * random.Next(0, 4))];
                                    break;
                            }

                            _player.inventory.GetItem(droppedItem);
                            Program.ShowMsgOnBattle($"{droppedItem.Name}을(를) 획득했습니다.");
                        }
                    }
                    //보스몬스터 - (4)단계 아이템 드롭확률
                    else if (_type == 2)
                    {
                        //드롭 확률
                        bool isDrop = (random.Next(1, 101) <= 10);
                        if (isDrop)
                        {
                            //무기인지 방어구인지 
                            int itemNumber = (random.Next(1, 3));
                            Item droppedItem = new Item();
                            switch (itemNumber)
                            {
                                //무기
                                case 1:
                                    droppedItem = itemDatabase.ITEM[11 + (4 * random.Next(0, 4))];
                                    break;
                                //방어구
                                case 2:
                                    droppedItem = itemDatabase.ITEM[27 + (4 * random.Next(0, 4))];
                                    break;
                            }

                            _player.inventory.GetItem(droppedItem);
                            Program.ShowMsgOnBattle($"{droppedItem.Name}을(를) 획득했습니다.");
                        }
                    }
                    break;
            }
            
        }
    }
}