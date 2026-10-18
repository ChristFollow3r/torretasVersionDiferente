using System.Globalization;
using UnityEngine;

public class ShootingMechanics : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    
    
    private InputSystem_Actions input;
    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }
    
    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if (input.Player.Jump.WasPressedThisFrame())
        {
            var newBullet = Instantiate(bullet, indicator.transform); 
            var bulletRb = newBullet.GetComponent<Rigidbody>();
            
            newBullet.transform.SetParent(null);
            bulletRb.linearVelocity = -indicator.transform.forward * bulletSpeed;
            
            Destroy(newBullet, 3);
        }
    }
}
