using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorModeManager : MonoBehaviour
{
    [SerializeField] GameObject hitPositionMarkerPrefab;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Material ghostMat;
    GameObject hitMarker;
    UIEditor ui;
    AvailableObjects availableObjects;
    enum EditorState { idle, placement }
    EditorState state = EditorState.idle;

    EditorInputs input;

    struct CurrentObject
    {
        public GameObject obj;
        public Material mat;
    }

    CurrentObject currentObject;

    //void Start()
    //{
    //    // hitMarker = Instantiate(hitPositionMarkerPrefab);
    //    ui = FindObjectOfType<UIEditor>();
    //    ui.OnObjectSelected += OnObjectSelected;
    //    availableObjects = FindObjectOfType<AvailableObjects>();
    //}

    public void Init(UIEditor ui, EditorInputs input)
    {
        ui.OnObjectSelected += OnObjectSelected;
        availableObjects = FindObjectOfType<AvailableObjects>();

        this.input = input;
    }

    private void OnObjectSelected(int index)
    {
        if(state == EditorState.placement) { return; }

        state = EditorState.placement;
        GameObject prefab = availableObjects.GetObject(index);
        currentObject.obj = Instantiate(prefab);
        currentObject.mat = currentObject.obj.GetComponentInChildren<MeshRenderer>().material;

        currentObject.obj.GetComponentInChildren<MeshRenderer>().material = ghostMat;
    }

    void Update()
    {
        switch (state)
        {
            case EditorState.idle:
                {
                    if (input.click)
                    {
                        input.click = false;
                        Debug.Log("click false");
                    }
                    if (input.cancel)
                    {
                        input.cancel = false;
                        Debug.Log("Cancel false");
                    }
                        break;
                }
            case EditorState.placement:
                {
                    Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

                    if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, layerMask))
                    {
                        currentObject.obj.transform.position = hitInfo.point;
                    }

                    if (input.click)
                    {
                        input.click = false;
                        Debug.Log("click false");

                        if (state == EditorState.placement)
                        {
                            state = EditorState.idle;
                            currentObject.obj.GetComponentInChildren<MeshRenderer>().material = currentObject.mat;
                            currentObject = new CurrentObject();
                        }
                    }

                    if (input.cancel)
                    {
                        input.cancel = false;
                        Debug.Log("Cancel false");

                        if (state == EditorState.placement)
                        {
                            state = EditorState.idle;

                            Destroy(currentObject.obj);
                            currentObject = new CurrentObject();
                        }
                    }

                    break;
                }
        }
    }

    //public void OnMouseClick(InputAction.CallbackContext context)
    //{
    //    if (state == EditorState.placement)
    //    {
    //        state = EditorState.idle;
    //        currentObject.obj.GetComponentInChildren<MeshRenderer>().material = currentObject.mat;
    //        currentObject = new CurrentObject();
    //    }
    //}

    //public void OnCancelInput(InputAction.CallbackContext context)
    //{
    //    if (state == EditorState.placement)
    //    {
    //        state = EditorState.idle;

    //        Destroy(currentObject.obj);
    //        currentObject = new CurrentObject();
    //    }
    //}
}
