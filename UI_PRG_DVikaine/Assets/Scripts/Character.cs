using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float health;
    [SerializeField] private string charName;

    public string CharName
    {
        get {return charName; }
    }

    public abstract void Attack(Character toHit);
    public void TakeDamage(float damage)
    {
        health = health - damage;
        Debug.Log(charName +"got hit for" + damage + " damage!" + "Current health: " + health);
    }

    public void TakeDamage(Weapon weapon)
    {
        float damage = weapon.GetDamage();
        TakeDamage(damage);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
