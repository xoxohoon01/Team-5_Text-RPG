namespace TextRPG

{
    public enum Job
    {
        None,
        Warrior,
        Archer,
        Thief,
        Mage
    }

    public class Player
    {
        public string Name { get; set; }                
        public Job PlayerJob { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int MaxMp { get; set; }
        public int Mp { get; set; }
        public int Speed { get; set; }
        public int Gold { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalDamage { get; set; }

        public Item weapon;
        public Item top;
        public Item head;
        public Item bottom;
        public Inventory inventory;
        public Player()
        {
            inventory = new Inventory();
            weapon = new Item();
            top = new Item();
            head = new Item();
            bottom = new Item();

        }

        public Player(string name, Job job)
        {
            Name = name;
            PlayerJob = job;
            Level = 1;
            CriticalChance = 0.05f;
            CriticalDamage = 1.5f;
            Gold = 1500;
            inventory = new Inventory();
            InitializeStats();
        }

        public void InitializeStats()
        {
            switch (PlayerJob)
            {
                case Job.Warrior:
                    Damage = 14;
                    Defence = 14;
                    Speed = 4;
                    MaxHp = 150;
                    MaxMp = 50;
                    CriticalChance = 0.1f;
                    CriticalDamage = 1.5f;
                    break;
                case Job.Archer:
                    Damage = 15;
                    Defence = 5;
                    Speed = 10;
                    MaxHp = 125;
                    MaxMp = 70;
                    CriticalChance = 0.25f;
                    CriticalDamage = 1.5f;
                    break;
                case Job.Thief:
                    Damage = 12;
                    Defence = 3;
                    Speed = 15;
                    MaxHp = 100;
                    MaxMp = 95;
                    CriticalChance = 0.35f;
                    CriticalDamage = 1.5f;
                    break;
                case Job.Mage:
                    Damage = 25;
                    Defence = 0;
                    Speed = 5;
                    MaxHp = 90;
                    MaxMp = 120;
                    CriticalChance = 0.2f;
                    CriticalDamage = 1.8f;
                    break;
            }
            Hp = MaxHp;
            Mp = MaxMp;
        }

        public void LevelUp()
        {
            Level++;
            switch (PlayerJob)
            {
                case Job.Warrior:
                    Damage += 2;
                    Defence += 2;
                    Speed += 1;
                    MaxHp += 15;
                    MaxMp += 5;
                    break;
                case Job.Archer:
                    Damage += 2;
                    Defence += 1;
                    Speed += 2;
                    MaxHp += 10;
                    MaxMp += 10;
                    break;
                case Job.Thief:
                    Damage += 2;
                    Defence += 1;
                    Speed += 3;
                    MaxHp += 5;
                    MaxMp += 5;
                    break;
                case Job.Mage:
                    Damage += 3;
                    Defence += 1;
                    Speed += 1;
                    MaxHp += 5;
                    MaxMp += 15;
                    break;
            }
            Hp = MaxHp; // 레벨업 시 체력 완전 회복
            Console.WriteLine($"레벨 업! 현재 레벨: {Level}");
        }
        
        public void EquipItem(Item item)        //아이템 장착
        {
            switch (item.Type)
            {
                case ItemType.Weapon:
                    inventory.item_weapon = item;
                    break;
                case ItemType.Armor:
                    inventory.item_top = item;
                    break;
                case ItemType.Head:
                    inventory.item_head = item;
                    break;
                case ItemType.Pants:
                    inventory.item_bottom = item;
                    break;
            }
        }

        public void UnequipItem(Item item)      //아이템 해제
        {
            switch (item.Type)
            {
                case ItemType.Weapon:
                    if (inventory.item_weapon != null)
                    {
                        inventory.playeritem_weapon.Add(inventory.item_weapon);
                       
                    }
                    break;
                case ItemType.Armor:
                    if (inventory.item_top != null)
                    {
                        inventory.playeritem_defence.Add(inventory.item_top);
                        
                    }
                    break;
                case ItemType.Head:
                    if(inventory.item_head != null)
                    {
                        inventory.playeritem_defence.Add(inventory.item_head);
                    }
                    break;
                case ItemType.Pants:
                    if(inventory.item_bottom != null)
                    {
                        inventory.playeritem_defence.Add(inventory.item_bottom);
                    }
                    break;
            }
        }

        public float DodgeChance()//Monster.Attacker          //몬스터 공격 회피
        {
            float baseChance = 0.1f;

            float speedDifference = this.Speed - _monster.Speed;

            float dodgeChance = baseChance + (speedDifference * 0.02f);

            return Math.Clamp(dodgeChance, 0.1f, 0.5f);
        }


        public int TotalDamageBonus()           //장착시 공격력 보너스
        {
            int totalBonus = 0;
            if (inventory.item_weapon != null) totalBonus += inventory.item_weapon.AttackPower;
            if (inventory.item_head != null) totalBonus += inventory.item_head.AttackPower;
            if (inventory.item_top != null) totalBonus += inventory.item_top.AttackPower;
            if (inventory.item_bottom != null) totalBonus += inventory.item_bottom.AttackPower;
            return totalBonus;
        }

        public int TotalDefenseBonus()          //장착시 방어력 보너스
        {
            int totalBonus = 0;
            if (inventory.item_weapon != null) totalBonus += inventory.item_weapon.DefensePower;
            if (inventory.item_head != null) totalBonus += inventory.item_head.DefensePower;
            if (inventory.item_top != null) totalBonus += inventory.item_top.DefensePower;
            if (inventory.item_bottom != null) totalBonus += inventory.item_bottom.DefensePower;
            return totalBonus;
        }

        public int TotalSpeedBonus()            //장착시 스피드 보너스
        {
            int totalBonus = 0;
            if (inventory.item_weapon != null) totalBonus += inventory.item_weapon.Speed;
            if (inventory.item_head != null) totalBonus += inventory.item_head.Speed;
            if (inventory.item_top != null) totalBonus += inventory.item_top.Speed;
            if (inventory.item_bottom != null) totalBonus += inventory.item_bottom.Speed;
            return totalBonus;
        }
        public double TotalCriticalCanceBonus()            //장착시 치명타 보너스
        {
            double totalBonus = 0;
            if (inventory.item_weapon != null) totalBonus += inventory.item_weapon.CritChance;
            if (inventory.item_head != null) totalBonus += inventory.item_head.CritChance;
            if (inventory.item_top != null) totalBonus += inventory.item_top.CritChance;
            if (inventory.item_bottom != null) totalBonus += inventory.item_bottom.CritChance;
            return totalBonus;
        }
        public double TotalCriticalDamageBonus()            //장착시 치명타 데미지 보너스
        {
            double totalBonus = 0;
            if (inventory.item_weapon != null) totalBonus += inventory.item_weapon.CritDamage;
            if (inventory.item_head != null) totalBonus += inventory.item_head.CritDamage;
            if (inventory.item_top != null) totalBonus += inventory.item_top.CritDamage;
            if (inventory.item_bottom != null) totalBonus += inventory.item_bottom.CritDamage;
            return totalBonus;
        }
    }
}