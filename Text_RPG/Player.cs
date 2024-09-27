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

    class Player
    {
        public string Name { get; set; }                
        public Job PlayerJob { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int MaxMp { get; set; }
        public int Mp { get; set; }
        public int Speed { get; set; }
        public int Gold { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalDamage { get; set; }
        public Item EquipmentWeapon { get; set; }
        public Item EquipmentArmor { get; set; }
        public Item EquipmentPants { get; set; }
        public Item EquipmentHead { get; set; }

        public Inventory inventory;

        public Player()
        {
            inventory = new Inventory();
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
                    Damage = 15;
                    Defense = 10;
                    Speed = 5;
                    MaxHp = 150;
                    MaxMp = 50;
                    CriticalChance = 0.05f;
                    CriticalDamage = 1.5f;
                    break;
                case Job.Archer:
                    Damage = 14;
                    Defense = 8;
                    Speed = 8;
                    MaxHp = 130;
                    MaxMp = 70;
                    CriticalChance = 0.2f;
                    CriticalDamage = 1.5f;
                    break;
                case Job.Thief:
                    Damage = 12;
                    Defense = 6;
                    Speed = 12;
                    MaxHp = 120;
                    MaxMp = 80;
                    CriticalChance = 0.35f;
                    CriticalDamage = 1.5f;
                    break;
                case Job.Mage:
                    Damage = 25;
                    Defense = 0;
                    Speed = 5;
                    MaxHp = 70;
                    MaxMp = 130;
                    CriticalChance = 0.15f;
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
                    Defense += 2;
                    Speed += 1;
                    MaxHp += 15;
                    MaxMp += 5;
                    break;
                case Job.Archer:
                    Damage += 2;
                    Defense += 1;
                    Speed += 2;
                    MaxHp += 10;
                    MaxMp += 10;
                    break;
                case Job.Thief:
                    Damage += 2;
                    Defense += 1;
                    Speed += 3;
                    MaxHp += 5;
                    MaxMp += 5;
                    break;
                case Job.Mage:
                    Damage += 3;
                    Defense += 1;
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
                    if (EquipmentWeapon != null) inventory.items.Add(EquipmentWeapon);
                    EquipmentWeapon = item;
                    break;
                case ItemType.Armor:
                    if (EquipmentArmor != null) inventory.items.Add(EquipmentArmor);
                    EquipmentArmor = item;
                    break;
                case ItemType.Head:
                    if (EquipmentHead != null) inventory.items.Add(EquipmentHead);
                    EquipmentHead = item;
                    break;
                case ItemType.Pants:
                    if (EquipmentPants != null) inventory.items.Add(EquipmentPants);
                    EquipmentPants = item;
                    break;
            }
            inventory.items.Remove(item);
        }

        public void UnequipItem(Item item)      //아이템 해제
        {
            switch (item.Type)
            {
                case ItemType.Weapon:
                    if (EquipmentWeapon != null)
                    {
                        inventory.items.Add(EquipmentWeapon);
                        EquipmentWeapon = null;
                    }
                    break;
                case ItemType.Armor:
                    if (EquipmentArmor != null)
                    {
                        inventory.items.Add(EquipmentArmor);
                        EquipmentHead = null;
                    }
                    break;
                case ItemType.Head:
                        if(EquipmentHead != null)
                    {
                        inventory.items.Add(EquipmentHead);
                        EquipmentHead = null;
                    }
                    break;
                case ItemType.Pants:
                    if(EquipmentPants != null)
                    {
                    inventory.items.Add(EquipmentPants);
                    EquipmentPants = null;
                    }
                    break;
            }
        }
        public int TotalDamageBonus()           //장착시 공격력 보너스
        {
            int totalBonus = 0;
            if (EquipmentWeapon != null) totalBonus += EquipmentWeapon.AttackPower;
            if (EquipmentArmor != null) totalBonus += EquipmentArmor.AttackPower;
            if (EquipmentHead != null) totalBonus += EquipmentHead.AttackPower;
            if (EquipmentPants != null) totalBonus += EquipmentPants.AttackPower;
            return totalBonus;
        }

        public int TotalDefenseBonus()          //장착시 방어력 보너스
        {
            int totalBonus = 0;
            if (EquipmentWeapon != null) totalBonus += EquipmentWeapon.DefensePower;
            if (EquipmentArmor != null) totalBonus += EquipmentArmor.DefensePower;
            if (EquipmentHead != null) totalBonus += EquipmentHead.DefensePower;
            if (EquipmentPants != null) totalBonus += EquipmentPants.DefensePower;
            return totalBonus;
        }

        public int TotalSpeedBonus()            //장착시 스피드 보너스
        {
            int totalBonus = 0;
            if (EquipmentWeapon != null) totalBonus += EquipmentWeapon.Speed;
            if (EquipmentArmor != null) totalBonus += EquipmentArmor.Speed;
            if (EquipmentHead != null) totalBonus += EquipmentHead.Speed;
            if (EquipmentPants != null) totalBonus += EquipmentPants.Speed;
            return totalBonus;
        }
        public double TotalCriticalCanceBonus()            //장착시 치명타 보너스
        {
            double totalBonus = 0;
            if (EquipmentWeapon != null) totalBonus += EquipmentWeapon.CritChance;
            if (EquipmentArmor != null) totalBonus += EquipmentArmor.CritChance;
            if (EquipmentHead != null) totalBonus += EquipmentHead.CritChance;
            if (EquipmentPants != null) totalBonus += EquipmentPants.CritChance;
            return totalBonus;
        }
        public double TotalCriticalDamageBonus()            //장착시 치명타 데미지 보너스
        {
            double totalBonus = 0;
            if (EquipmentWeapon != null) totalBonus += EquipmentWeapon.CritDamage;
            if (EquipmentArmor != null) totalBonus += EquipmentArmor.CritDamage;
            if (EquipmentHead != null) totalBonus += EquipmentHead.CritDamage;
            if (EquipmentPants != null) totalBonus += EquipmentPants.CritDamage;
            return totalBonus;
        }
    }
}