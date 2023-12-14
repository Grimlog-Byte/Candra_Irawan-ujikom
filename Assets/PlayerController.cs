using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField] float isWalking;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Animator anim;
    [SerializeField] Transform shooter;
    [SerializeField] GameObject foodProjectile;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f).normalized;
        Debug.Log(movement);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(foodProjectile, shooter.position, Quaternion.identity);
        }
    }



}
