using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    public Player player;   

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void playerJump()
    {
        player.jump();
    }

    public void playerDown()
    {
        player.down();
    }
}
