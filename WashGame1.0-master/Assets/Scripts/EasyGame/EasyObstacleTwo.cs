using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyObstacleTwo : MonoBehaviour
{

    public int damage = 1;
    public float speed;

    public GameObject effect;




    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            Instantiate(effect, transform.position, Quaternion.identity);
            // players take damage
            other.GetComponent<PlayerEasy>().health -= damage;
            Destroy(gameObject);
            Debug.Log(other.GetComponent<PlayerEasy>().health);

            
        }
        
    }
}
