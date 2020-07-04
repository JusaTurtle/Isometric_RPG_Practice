using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float attackSpeed;
    public float delay;
    public List<BulletPattern> attackType;
    private int attackNumber;
    private float attackTimer;
    private float delayTimer;
    private Player owner;

    private void Update() {
        Tick();
    }

    public void Attack(char current)
    {
        if (current == 'b')
        {
            delayTimer = delay;
            if (attackTimer <= 0)
            {
                attackNumber %= attackType.Count;
                PerformAttack(attackNumber++);
                attackTimer = 1 / attackSpeed;
            }
        }
        else if (delayTimer <= 0)
        {
            attackNumber = 0;
        }
    }

    private void PerformAttack(int attackNumber)
    {
        if (attackNumber < attackType.Count)
        {
            BulletPattern attack = Instantiate(attackType[attackNumber], transform.position, transform.rotation);
            attack.tag = transform.root.tag;
            attack.SetOwner(owner);
        }
    }

    private void Tick()
    {
        attackTimer -= Time.deltaTime;
        delayTimer -= Time.deltaTime;
    }

    public void SetOwner(Player owner)
    {
        this.owner = owner;
    }
}
