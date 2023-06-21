using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{

    private Actions _actions;

    public delegate void OnMove(float value);
    public OnMove onMove;

    public delegate void OnRotate(float value);
    public OnRotate onRotate;

    private void Awake()
    {
        _actions = new Actions();
        _actions.Enable();
        _actions.FileHandle.Save.performed += Save;
        _actions.FileHandle.Load.performed += Load;
    }

    // Update is called once per frame
    void Update()
    {
        onMove(_actions.Player.Move.ReadValue<float>());
        onRotate(_actions.Player.Rotate.ReadValue<float>());
    }

    private void Load(InputAction.CallbackContext obj)
    {
        SaveManager.instance.Load();
    }

    private void Save(InputAction.CallbackContext obj)
    {
        SaveManager.instance.Save();
    }
}
