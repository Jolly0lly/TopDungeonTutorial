using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : Attackable
{
    protected override void Death()
    {
        Destroy(gameObject);
    }
}
