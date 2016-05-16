using UnityEngine;
using System.Collections;

public class PlayerFunctions : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    //Move character left
    void MoveLeft()
    {

    }


    //Move character right
    void MoveRight()
    {

    }


    //HitByTrap
    void TrapCollision()
    {

    }

    //PowerUps
    void PowerUpCollision()
    {

    }


    //OnCollisionEnter2D() when colliding with trap
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.tag == "Trap")
        {
            TrapCollision();
        }
        else if (otherObject.gameObject.tag == "PowerUp")
        {
            PowerUpCollision();
        }
        else
        {
            Debug.LogError("Collided with: ", otherObject.gameObject);
        }
    }
}