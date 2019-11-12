using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(0);

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
