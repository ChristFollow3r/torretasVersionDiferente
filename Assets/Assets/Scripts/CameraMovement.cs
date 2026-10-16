using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    //[SerializeField] private float collisionDistance;
    [SerializeField] private GameObject target;
    
    private InputSystem_Actions input;
    private Vector2 mInput; 
    private Vector3 cachedPosition;
    private bool moveB = false;
    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    private void Start()
    {
        cachedPosition = transform.position;
    }

    void Update()
    {
        //Debug.Log(cachedPosition);
        if (moveB) transform.position = Vector3.Lerp(transform.position, cachedPosition, Time.deltaTime);
        CameraRotation();
    }

    void CameraRotation()
    {
        mInput = input.Player.Move.ReadValue<Vector2>();

        // Y PORQUE ESTA ESTO INVERTIDO ME CAGO EWQRQPIÑYGQWERP8IÑI YFREWQPÑ9YFREQWPOL
        transform.RotateAround(target.transform.position, Vector3.up, -mInput.x * xSpeed * Time.deltaTime);
        transform.RotateAround(target.transform.position, transform.right, mInput.y * ySpeed * Time.deltaTime);
        transform.LookAt(target.transform);
        
    }

    void OnTriggerEnter(Collider other) // B UA CHAVAL ESTO GG SUPER TOP FUCK RAYCASTS Y SUS HUEVOS
    {
        Debug.Log("Hello");
        if (other.CompareTag("ground")) moveB = true;
    }
}

// PIOUGDQWEPÑIGYRP9EW8Q8YFG R PÑEQWG REQWP7G7 REPWQ87TG RP98YGF'`PUTAS M,¡EIRDA DDE EJERCICOEWU Q  R0OÙGHQWE `RÙG EQWP9YRTG WEQ`097RTGWQEÑ`9´7TGERWQÑ´`90EQRWFGÑ`90
// LA CAMARA DE LOS HUEVOS ESTA CHOCANDO CON EL AIRFE MWEQPIYTRFWEQWER