using UnityEngine;

public class ShotgunWeapon : Weapon
{
    public int pelletCount = 3;

    public override float GetDamage()
    {
        float totalDamage = 0;

        for (int i = 0; i < pelletCount; i++)
        {
            totalDamage += base.GetDamage();
        }

        Debug.Log("Shotgun fired " + pelletCount + " pellets for " + totalDamage + " total damage!");
        return totalDamage;
    }
}