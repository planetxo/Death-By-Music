using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerFunctions : MonoBehaviour
{
    public float m_Speed = 10;

    public int m_MaxHealth = 3;
    public int m_CurrentHealth = 3;

    public int m_MaxNukes = 3;
    public int m_CurrentNukes = 3;

    public GameObject m_TrapSpawner;

    private float m_Direction = 0;

    private float m_MinX = 0, m_MaxX = 0;

    private Vector3 m_Velocity = new Vector3(0, 0, 0);
    private float m_MoveSpeed = 0;


	public Sprite health1;
	public Sprite health2;
	public Sprite health3;
	public Image healthbar;

	public 


	// Use this for initialization
	void Start ()
    {
        float CamHeight = 2f * Camera.main.orthographicSize;
        float CamWidth = CamHeight * Camera.main.aspect / 2;

		m_MoveSpeed = m_Speed;

        m_MinX = -CamWidth + GetComponent<Collider2D>().bounds.size.x / 2;

        m_MaxX = CamWidth - GetComponent<Collider2D>().bounds.size.x / 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }


    //Constrain sides
    void ConstrainSides()
    {
        if (gameObject.transform.position.x > m_MaxX)
        {
            gameObject.transform.position = new Vector3(m_MaxX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x < m_MinX)
        {
            gameObject.transform.position = new Vector3(m_MinX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }


    //Move character
    void Movement()
    {


        m_Velocity.x = m_MoveSpeed * m_Direction * Time.deltaTime;

        transform.position += m_Velocity;

        m_Velocity.x = 0;

        ConstrainSides();
    }


    //Determine direction
    public void Direction(GameObject button)
    {
        if (button.name == "ControlLeftButton")
        {
            m_Direction = -1;
        }
        else if (button.name == "ControlRightButton")
        {
            m_Direction = 1;
        }
        else
        {
            Debug.LogError("Function call from incorrect object: ", button);
        }
    }


    //ResetDirection
    public void ResetDirection()
    {
        m_Direction = 0;
    }


    //Use Nuke
    public void UseNuke()
    {
        if (m_CurrentNukes > 0)
        {
            //might have to grab script
         //  m_TrapSpawner.NukeScreen();
        }
    }


    //HitByTrap
    void TrapCollision()
    {
        --m_CurrentHealth;

		if (m_CurrentHealth == 2)
		{
			healthbar.sprite = health2;
		}
		else if (m_CurrentHealth == 1)
		{
			healthbar.sprite = health1;
		}
		else if (m_CurrentHealth == 0)
		{
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponentInChildren<ParticleSystem>().Emit(GetComponentInChildren<ParticleSystem>().maxParticles);
			Application.LoadLevel("menu");
		}
    }

    //PowerUps
    void PowerUpCollision()
    {

    }


    //OnCollisionEnter2D() when colliding with trap
    void OnTriggerEnter2D(Collider2D otherObject)
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