using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : NetworkBehaviour
{
    public static Spawner instance;

    private void Awake()
    {
        instance = this;
    }
    
}
