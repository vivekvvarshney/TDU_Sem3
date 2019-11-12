using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{
    public Button ResetDifficulty;
    public Button ResetLevel;
    public Button ExitButton;
    public GameObject MazePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetDifficulty.onClick.AddListener(ResetMaze);
        ResetLevel.onClick.AddListener(ResetLevelfunction);
        ExitButton.onClick.AddListener(ExitLevel);
    }
    
    void ResetMaze()
    {
        

    }
    void ResetLevelfunction()
    {
        Destroy(GameObject.FindGameObjectWithTag("Maze"));
        Instantiate(MazePrefab);

    }
    void ExitLevel()
    {
        Application.Quit(0);

    }
}
