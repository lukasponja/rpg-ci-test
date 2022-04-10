using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] GameObject cineCamera;
    [SerializeField] EditorModeManager editorModeManager;
    [SerializeField] UIEditor uiEditor;

    public CinemachineVirtualCamera vCam1;
    public CinemachineVirtualCamera vCam2;

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetCamera()
    {
        Debug.Log(cineCamera);
        return cineCamera;
    }

    public void SetEditor(ThirdPersonController controller, EditorInputs editorInputs)
    {
        uiEditor.enabled = true;
        uiEditor.Init(controller);

        editorModeManager.gameObject.SetActive(true);
        editorModeManager.Init(uiEditor, editorInputs, controller);
    }
}
