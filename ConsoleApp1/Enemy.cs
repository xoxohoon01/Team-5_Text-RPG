namespace TextRPG
{
    class Enemy : Unit
    {
        public Enemy(string _name = "")
        {
            name = _name;

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