using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProjectile : MonoBehaviour
{
    public float speed = 5f;
    public int hungerDamage = 25;
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, 0f, 1f).normalized;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        StartCoroutine(DestroySelf());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Debug.Log("Hit");
            other.GetComponent<AnimalController>().Hit(hungerDamage);
        }
    }

 

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
