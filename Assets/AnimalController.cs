using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float speed = 5f;
    public int direction;
    public int score;
    public int hungerNeed = 200;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, 0f, 1f *direction).normalized;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void Hit(int hungerFill)
    {
        Debug.Log("Hit");
        hungerNeed -= hungerFill;
        if(hungerNeed <= 0)
        {
            Debug.Log("AddScore");
            GameManager.instance.AddScore(score);
            Destroy(gameObject);
        }
      
    }
}
