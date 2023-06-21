using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ISaveableComponent
{

    private PlayerInputs _inputs;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _inputs = GetComponent<PlayerInputs>();
        _inputs.onMove += HandleTranslation;
        _inputs.onRotate += HandleRotation;
        SaveManager.instance.movement = this;
    }

    private void HandleTranslation(float value)
    {
        transform.Translate(_movementSpeed * transform.forward * value * Time.deltaTime, Space.World);
    }

    private void HandleRotation(float value)
    {
        transform.Rotate(_rotationSpeed * value * transform.up * Time.deltaTime);
    }

    public void Save(GameData data)
    {
        SaveManager.instance.GameData.name = gameObject.name;
        SaveManager.instance.GameData.position = transform.position;
        SaveManager.instance.GameData.rotation = transform.rotation;
    }

    public void Load()
    {
        transform.position = SaveManager.instance.GameData.position;
        transform.rotation = SaveManager.instance.GameData.rotation;
    }
}
