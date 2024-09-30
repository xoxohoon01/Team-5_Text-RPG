namespace TextRPG
{
    class Enemy : Unit
    {
        public Enemy(string _name = "", int _hp = 0, int _mp = 0, int _damage = 0, int _armor = 0, int _speed = 0, int _critChance = 0, int _critDamage = 0)
        {
            name = _name;

            hp = _hp;
            maxHp = _hp;
            mp = _mp;
            maxMp = _mp;

            damage = _damage;
            armor = _armor;
            speed = _speed;
            critChance = _critChance;
            critDamage = _critDamage;
        }
    
        public void OnAttack(ref Player _player)
        {
            _player.Hp = damage - (_player.Defense + _player.TotalDefenseBonus());
        }
    }
}