using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] GameObject cineCamera;
    [SerializeField] EditorModeManager editorModeManager;
    [SerializeField] UIEditor uiEditor;

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
        editorModeManager.Init(uiEditor, editorInputs);
    }
}
