using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public KeyCode basic;
    public float attackSpeed;
    public List<GameObject> attackType;
    private string buffer;
    private float timer;

    private void Start()
    {
        buffer = "";
    }

    private void Update()
    {
        char current = GetAction();
        if (current != ' ' && buffer.Length <= 2)
        {
            buffer += current;
            timer = 1 / attackSpeed;
        }
        Debug.Log(buffer, this);

        if (timer < 0)
        {
            if (buffer == "bbb")
            {
                PerformAttack(2);
            }
            else if (buffer == "bb")
            {
                PerformAttack(1);
            }
            else if (buffer == "b")
            {
                PerformAttack(0);
            }
            buffer = "";
        }
        else
        {
            Tick();
        }
    }

    private void PerformAttack(int attackNumber)
    {
        if (attackNumber < attackType.Count)
        {
            GameObject attack = Instantiate(attackType[attackNumber], transform.position, transform.rotation);
            attack.tag = transform.root.tag;
        }
    }

    private void Tick()
    {
        timer -= Time.deltaTime;
    }

    private char GetAction()
    {
        if (Input.GetKeyDown(basic)) return 'b';
        return ' ';
    }

    private enum Action
    {
        None, Basic
    }
}
