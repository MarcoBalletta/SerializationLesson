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
        data.name = gameObject.name;
        data.position = transform.position;
        data.rotation = transform.rotation;
    }

    public void Load(GameData data)
    {
        transform.position = data.position;
        transform.rotation = data.rotation;
    }
}
