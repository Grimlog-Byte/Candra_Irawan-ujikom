using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Debug.Log("Hit");
            Destroy(other.gameObject);
        }
    }
}
