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

    }
}