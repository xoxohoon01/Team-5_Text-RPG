namespace TextRPG
{
    public enum ClassType { None, Warrior, Rogue, Mage };

    class Player : Unit
    {
        public ClassType classType;
        public Inventory inventory;

        public Player()
        {
            inventory = new Inventory();

            level = 1;

            exp = 0;
            maxExp = 100;

            hp = 0;
            maxHp = 0;
            mp = 0;
            maxMp = 0;

            damage = 0;
            armor = 0;
            speed = 0;
            critChance = 0;
            critDamage = 0;
        }
    }
}