using UnityEngine;

public class RifleWeapon : Weapon
{
    public float critChance = 0.3f;
    public float critMultiplier = 2f;

    public override float GetDamage()
    {
        float damage = base.GetDamage();

        float roll = Random.Range(0f, 1f);

        if (roll < critChance)
        {
            damage = damage * critMultiplier;
            Debug.Log("Headshot! Critical hit for " + damage + " damage!");
        }

        return damage;
    }
}