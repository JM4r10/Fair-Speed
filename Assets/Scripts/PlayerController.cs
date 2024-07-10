using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float powerupSpeed, jumpForce, timeForLoad, gravityForce;
    [SerializeField] private bool isOnGround = true;
    private Animator playerAnim;
    private Rigidbody playerRb;
    [SerializeField] private static bool isGravityModified;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        if (!isGravityModified)
        {
            Physics.gravity *= gravityForce;
            isGravityModified = true;
        }
    }

    void Update()
    {
        Jump();
        RunFasterAnimation();
    }

    private void Jump()
    {
        if (GameManager.Instance.gameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerAnim.SetBool("isJump", true);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void RunFasterAnimation() => playerAnim.SetFloat("MovX", GameManager.Instance.GameSpeed);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("isJump", false);
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StopSpawnManager();
            StopObjects();
            StartCoroutine(DeathSequence());
        }
    }

    private void StopSpawnManager()
    {
        SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.enabled = false;
    }

    private void StopObjects()
    {
        MoveFoward[] moveFowards = FindObjectsOfType<MoveFoward>();
        foreach (MoveFoward moveFowardScript in moveFowards)
        {
            moveFowardScript.enabled = false;
        }
    }

    private IEnumerator DeathSequence()
    {
        playerAnim.SetBool("isDie", true);
        GameManager.Instance.GameSpeed = 0;
        GameManager.Instance.gameOver = true;
        yield return new WaitForSeconds(timeForLoad);
        GameManager.Instance.Defeat();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power-up"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.GameSpeed += powerupSpeed;
        }

    }

}
