using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public int timer;
    //public 
    // Start is called before the first frame update
    void Start()
    {
        timer =3;
        
    }

    // Update is called once per frame
    void Update()
    {
        --timer;
        Debug.Log("angle "+ Mathf.Floor(transform.rotation.eulerAngles.z));
        Debug.Log("Mathf.Ceil( transform.rotation.eulerAngles.z)%180 == 0f : " + (Mathf.Floor(transform.rotation.eulerAngles.z) % 180));
        Debug.Log("Mathf.Ceil(transform.rotation.eulerAngles.z)% 90 == 0f : " + (Mathf.Floor(transform.rotation.eulerAngles.z) % 90));
        if (Mathf.Floor( transform.rotation.eulerAngles.z)%180 == 0f)//player facing up or down
        {
            Debug.Log("player facing up or down : "+ Mathf.Ceil(transform.rotation.eulerAngles.z) % 180);
            //Left
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }
            //Right
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }
        }
        else if((Mathf.Floor(transform.rotation.eulerAngles.z)% 90 == 0f)|| (Mathf.Floor(transform.rotation.eulerAngles.z+1) % 90 == 0f))//player facing left or right)
        {
            Debug.Log("player facing left or right : "+ Mathf.Ceil(transform.rotation.eulerAngles.z) % 90);
            //Left
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            //Right
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,speed);
            }
        }
    }
    
}
