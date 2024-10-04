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
        public int Experience { get; set; }
        public int NextLevelExperience { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int MaxMP { get; set; }
        public int MP { get; set; }
        public int Speed { get; set; }
        public int Gold { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalDamage { get; set; }

        public Item weapon;
        public Item top;
        public Item head;
        public Item bottom;
        public Inventory inventory;
        public List<Skill> skillList;

        public Player()
        {
            Name = "";
            Level = 1;
            Experience = 0;
            NextLevelExperience = 100;
            inventory = new Inventory();
            skillList = new List<Skill>();
            weapon = new Item();
            top = new Item();
            head = new Item();
            bottom = new Item();
            Gold = 500;
        }

        public Player(string name, Job job)
        {
            Name = name;
            PlayerJob = job;
            skillList = new List<Skill>();
            Level = 1;
            Experience= 0;
            NextLevelExperience = 100;
            CriticalChance = 0.05f;
            CriticalDamage = 1.5f;
            Gold = 500;
            inventory = new Inventory();
            InitializeStats();
        }

        public void InitializeStats()
        {
            switch (PlayerJob)
            {
                case Job.Warrior:
                    Damage = 14;
                    Defense = 14;
                    Speed = 4;
                    MaxHP = 150;
                    MaxMP = 50;
                    CriticalChance = 0.1f;
                    CriticalDamage = 1.5f;
                    skillList.Add(Skill.CreateBasicSkill(PlayerJob.ToString())); // 기본 스킬만 추가
                    break;
                case Job.Archer:
                    Damage = 15;
                    Defense = 5;
                    Speed = 10;
                    MaxHP = 125;
                    MaxMP = 70;
                    CriticalChance = 0.25f;
                    CriticalDamage = 1.5f;
                    skillList.Add(Skill.CreateBasicSkill(PlayerJob.ToString()));
                    break;
                case Job.Thief:
                    Damage = 12;
                    Defense = 3;
                    Speed = 15;
                    MaxHP = 100;
                    MaxMP = 95;
                    CriticalChance = 0.35f;
                    CriticalDamage = 1.5f;
                    skillList.Add(Skill.CreateBasicSkill(PlayerJob.ToString()));
                    break;
                case Job.Mage:
                    Damage = 25;
                    Defense = 0;
                    Speed = 5;
                    MaxHP = 90;
                    MaxMP = 120;
                    CriticalChance = 0.2f;
                    CriticalDamage = 1.8f;
                    skillList.Add(Skill.CreateBasicSkill(PlayerJob.ToString()));
                    break;
            }
            HP = MaxHP;
            MP = MaxMP;
        }

        public void LevelUp()
        {
            Experience -= NextLevelExperience;
            Level++;
            NextLevelExperience += (int)(NextLevelExperience * 0.2f); // 다음 레벨업에 필요한 경험치 20% 증가

            switch (PlayerJob)
            {
                case Job.Warrior:
                    Damage += 2;
                    Defense += 2;
                    Speed += 1;
                    MaxHP += 15;
                    MaxMP += 5;
                    break;
                case Job.Archer:
                    Damage += 2;
                    Defense += 1;
                    Speed += 2;
                    MaxHP += 10;
                    MaxMP += 10;
                    break;
                case Job.Thief:
                    Damage += 2;
                    Defense += 1;
                    Speed += 3;
                    MaxHP += 5;
                    MaxMP += 5;
                    break;
                case Job.Mage:
                    Damage += 3;
                    Defense += 1;
                    Speed += 1;
                    MaxHP += 5;
                    MaxMP += 15;
                    break;
            }
            HP = MaxHP; // 레벨업 시 체력 완전 회복

            // 레벨에 따라 새로운 스킬 추가
            var newSkills = Skill.CreateAdditionalSkills(PlayerJob.ToString(), Level);
            foreach (var skill in newSkills)
            {
                if (!skillList.Contains(skill)) // 중복 방지를 위해 스킬이 없는 경우에만 추가
                {
                    skillList.Add(skill);
                    Console.WriteLine($"{skill.Name} 스킬을 배웠습니다!");
                }
            }

            Console.WriteLine($"레벨 업! 현재 레벨: {Level}, 다음 레벨업까지: {NextLevelExperience} 경험치 필요");
        }

        public void EquipItem(Item item)        //아이템 장착
        {
            switch (item.Type)
            {
                case ItemType.Weapon:
                    inventory.item_weapon = item;
                    break;
                case ItemType.Head:
                    inventory.item_head = item;
                    break;
                case ItemType.Top:
                    inventory.item_top = item;
                    break;
                case ItemType.Bottom:
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
                        inventory.weaponList.Add(inventory.item_weapon);
                       
                    }
                    break;
                case ItemType.Top:
                    if (inventory.item_top != null)
                    {
                        inventory.armorList.Add(inventory.item_top);
                        
                    }
                    break;
                case ItemType.Head:
                    if(inventory.item_head != null)
                    {
                        inventory.armorList.Add(inventory.item_head);
                    }
                    break;
                case ItemType.Bottom:
                    if(inventory.item_bottom != null)
                    {
                        inventory.armorList.Add(inventory.item_bottom);
                    }
                    break;
            }
        }

        public float DodgeChance(int _monsterSpeed)//Monster.Attacker          //몬스터 공격 회피
        {
            float baseChance = 0.1f;

            float speedDifference = this.Speed - _monsterSpeed;

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
        public double TotalCriticalChanceBonus()            //장착시 치명타 보너스
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
            if (inventory.item_weapon != null) totalBonus += inventory.item_weapon.CritDamage / 100;
            if (inventory.item_head != null) totalBonus += inventory.item_head.CritDamage / 100;
            if (inventory.item_top != null) totalBonus += inventory.item_top.CritDamage / 100;
            if (inventory.item_bottom != null) totalBonus += inventory.item_bottom.CritDamage / 100;
            return totalBonus;
        }
    }
}