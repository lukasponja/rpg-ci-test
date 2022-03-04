using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class CharacterSwitcher : MonoBehaviour
{
    public static CharacterSwitcher instance;

    [SerializeField] GameObject p1Prefab;
    [SerializeField] GameObject p2Prefab;
    [SerializeField] CinemachineVirtualCamera playerCam;

    GameObject currentPlayer;

    int id = 2;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentPlayer = FindObjectOfType<ThirdPersonController>().gameObject;
    }

    public void SwitchChar()
    {
        if(id == 1)
        {
            id = 2;
            Destroy(currentPlayer);
            currentPlayer = Instantiate(p1Prefab, currentPlayer.transform.position, currentPlayer.transform.rotation);
            playerCam.Follow = currentPlayer.transform.Find("PlayerCameraRoot");
        }
        else if (id == 2)
        {
            id = 1;
            Destroy(currentPlayer);
            currentPlayer = Instantiate(p2Prefab, currentPlayer.transform.position, currentPlayer.transform.rotation);
            playerCam.Follow = currentPlayer.transform.Find("PlayerCameraRoot");
        }
        else
        {
            Debug.Log("id?");
        }
    }
}
