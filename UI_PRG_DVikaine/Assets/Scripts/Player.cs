using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon activeWeapon;

    public string ActiveWeaponName
    {
        get { return activeWeapon.weaponName; }
    }
    private int selectedWeaponID = 0;
    public override void Attack(Character toHit)
    {
      
       toHit.TakeDamage(activeWeapon);
    }

    public void SwitchWeapons()
    {
        selectedWeaponID = (++selectedWeaponID % weapons.Length);
        activeWeapon = weapons[selectedWeaponID];
    }
    void Start()
    {
        activeWeapon = weapons[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
