using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorInputs : MonoBehaviour
{
    public bool enterEditMode;
    public bool click;
    public bool cancel;

    public void OnEnterEditMode(InputValue value)
    {
        enterEditMode = value.isPressed;
    }

    public void OnClick(InputValue value)
    {
        click = value.isPressed;
    }

    public void OnCancel(InputValue value)
    {
        cancel = value.isPressed;
        Debug.Log("Cancel event");
    }
}
