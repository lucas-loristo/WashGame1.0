using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Vector2 targetPos;
    public float Yincrement = 3;
    public float Xincrement = 3;

    public float speed;
    public float minHeight = -3;
    public float maxHeight = 3;
    public float maxLeft;
    public float maxRight;

    public int health = 3;
    public int maxhealth = 3;
    public Text healthDisplay;



    void Start()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }


        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > maxLeft)
        {
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxRight)
        {
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);

        }


    }
    public void jump()
    {
        if (transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
    }
    public void down()
    {
        if (transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }
}
