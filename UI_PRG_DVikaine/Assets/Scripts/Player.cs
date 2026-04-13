using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon activeWeapon;

    public int level = 1;
    private float startHealth;

 
    public float healAmount = 10f;
    private bool canHeal = true;

    public string ActiveWeaponName
    {
        get { return activeWeapon.weaponName; }
    }

    public bool CanHeal
    {
        get { return canHeal; }
    }

    private int selectedWeaponID = 0;

    public override void Attack(Character toHit)
    {
        toHit.TakeDamage(activeWeapon);
        activeWeapon.PlaySound();
    }

    public void Heal()
    {
        if (canHeal)
        {
            health += healAmount;
            canHeal = false;
            Debug.Log("Healed for " + healAmount + "! Current health: " + health);
        }
        else
        {
            Debug.Log("Already used heal!");
        }
    }

    public void ResetHeal()
    {
        canHeal = true;
    }

    public void ResetPlayer()
    {
        health = startHealth;
        level = 1;
        canHeal = true;
        selectedWeaponID = 0;
        activeWeapon = weapons[0];
    }

    public void SwitchWeapons()
    {
        selectedWeaponID = (++selectedWeaponID % weapons.Length);
        activeWeapon = weapons[selectedWeaponID];
    }

    void Start()
    {
        activeWeapon = weapons[0];
        startHealth = health;
    }

    
}