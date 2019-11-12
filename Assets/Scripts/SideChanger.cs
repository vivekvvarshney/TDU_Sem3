using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChanger : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<PlayerMovement>().timer = 3;
        Debug.Log("side changer collides");
        if (collision.collider.transform.Equals(player.transform))
        {
            Debug.Log("side changer collides with player");
            player.transform.Rotate(0, 0, 90f);
        }
    }
}
