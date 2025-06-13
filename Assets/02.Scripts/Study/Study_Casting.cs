using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Study_Casting : MonoBehaviour
{
    List<Orc> orcs = new List<Orc>();
    List<Goblin> goblins = new List<Goblin>();

    List<Monster> monsters = new List<Monster>();

    void Start()
    {

        Orc o = new Orc();


        if (o is Monster)
        {
            Debug.Log("오크는 몬스터가 맞습니다.");
        }

        Goblin g = new Goblin();

        Monster m1 = (Monster)o;
        Monster m2 = (Monster)g;

        this.monsters.Add(g);
        this.monsters.Add(o);



    }


}
