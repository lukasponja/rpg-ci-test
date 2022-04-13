using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    Material[] materials;

    private void Awake()
    {
        materials = transform.Find("Geometry").Find("Armature_Mesh").GetComponent<SkinnedMeshRenderer>().materials;

        Debug.Log("Player mat " + materials.Length);
    }

    public void ChangeColor(Color32 newColor)
    {
        Debug.Log("ChangeColor");
        foreach(Material mat in materials)
        {
            mat.color = newColor;
        }
    }

    private void OnDestroy()
    {
        foreach (Material mat in materials)
        {
            Destroy(mat);
        }
    }
}
