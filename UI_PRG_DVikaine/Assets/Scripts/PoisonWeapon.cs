using UnityEngine;

public class PoisonWeapon : Weapon
{
    public float  poisonDamage;
    public float poisonCount;
    public override float GetDamage()
    {
       float damage = base.GetDamage();
       if (poisonCount > 0)
       {
           poisonCount--;
           poisonCount += poisonDamage;
       }
       return damage;
    }
}
