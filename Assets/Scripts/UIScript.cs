using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button ResetLevel;
    public GameObject GObject;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        //ResetLevel.onClick.AddListener(ResetLevelMethod);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    public void ResetLevelMethod()
    {
        //GObject.SetActive(false);
        while(GameObject.FindGameObjectsWithTag("Maze").Length<1)
        Destroy(GameObject.FindGameObjectWithTag("Maze"));

        Debug.Log("Reset Level"+(++counter));
        Instantiate(GObject);
    }
}
