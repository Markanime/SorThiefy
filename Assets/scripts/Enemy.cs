using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Touchable {

    public float strength = 25; 

    protected override void ReplyNun(NunController nun)
    {
        nun.GetComponent<NunHealth>().Damage(strength);
    }
}
