using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class UIEditor : MonoBehaviour
{
    public event Action<int> OnObjectSelected;

    [SerializeField] Button cubeButton;
    [SerializeField] Button sphereButton;
    [SerializeField] GameObject editorOptionsPanel;

    void Start()
    {
        cubeButton.onClick.AddListener(OnCubeButtonClick);
        sphereButton.onClick.AddListener(OnSphereButtonClick);

        FindObjectOfType<ThirdPersonController>().OnEditorMod += isEditor => {
            editorOptionsPanel.SetActive(isEditor);
        };
    }

    private void OnCubeButtonClick()
    {
        OnObjectSelected?.Invoke(0);
    }

    private void OnSphereButtonClick()
    {
        OnObjectSelected?.Invoke(1);
    }

}
