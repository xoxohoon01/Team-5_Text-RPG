namespace TextRPG
{
    class Unit
    {
        public string Name = "";

        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MP { get; set; }
        public int MaxMP { get; set; }

        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int CritChance { get; set; }
        public int CritDamage { get; set; }
    }
}