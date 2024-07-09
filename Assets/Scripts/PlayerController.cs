using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float powerupSpeed = 10f;
    public float powerupDuration = 5f;
    public float jumpForce = 5f;
    private float currentSpeed;
    private bool isOnGround = true;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Movimiento constante hacia la derecha
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
     private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerupRoutine());
        }
    }

    private IEnumerator PowerupRoutine()
    {
        currentSpeed = powerupSpeed;
        yield return new WaitForSeconds(powerupDuration);
        currentSpeed = normalSpeed;
    }
}
