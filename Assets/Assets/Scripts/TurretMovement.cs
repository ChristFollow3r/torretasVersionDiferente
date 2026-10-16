using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TurretMovement : MonoBehaviour
{
    [SerializeField] private GameObject support;
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject un;
    [SerializeField] private float supportSens;
    [SerializeField] private float barrelSense;
    
    private Vector3 mouseInput;
    
    void Update()
    {
        mouseInput = Mouse.current.delta.value;
        SupportMovement(mouseInput);
        BarrelMovement(mouseInput);
    }
    
    void SupportMovement(Vector3 mouseInput)
    {
        support.transform.eulerAngles += new Vector3(0, mouseInput.x * supportSens, 0);
    }

    void BarrelMovement(Vector3 mouseInput)
    {
        barrel.transform.eulerAngles += new Vector3(mouseInput.y * barrelSense, 0, 0);
    }
}
