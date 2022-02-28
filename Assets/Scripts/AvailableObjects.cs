using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableObjects : MonoBehaviour
{
    public List<GameObject> prefabs;

    public GameObject GetObject(int index)
    {
        return prefabs[index];
    }
}
