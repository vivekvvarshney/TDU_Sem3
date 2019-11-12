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
    public Text DebugData;
    public int difficultyLevel=0;
    public float gameStartTime;
    public float gameEndTime;
    public float levelStartTime;
    public float levelEndTime;
    public int levelCounter;
    public int tryCounter;
    public int coinCounter;
    public float interactionTime;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(MazePrefab);
        gameStartTime = Time.time;
        levelStartTime = Time.time;
        levelCounter = 0;
        tryCounter = 1;
        interactionTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        levelEndTime = Time.time;
        gameEndTime = Time.time;
        coinCounter = GameObject.FindGameObjectsWithTag("Coin").Length;
        DebugData.text = "Difficulty Level: " + difficultyLevel + "\nLevelTime: " + (levelEndTime - levelStartTime) + "seconds\nGameTime: " +(gameEndTime-gameStartTime)+"seconds\nLevel Counter: "+levelCounter+"\nTry Counter: "+tryCounter+"\nCoins Left: "+coinCounter+ "\nInteractionTime: "+interactionTime + "\nLNumber of Mazes: " + GameObject.FindGameObjectsWithTag("Maze").Length;
        
        ResetDifficulty.onClick.AddListener(ResetMaze);
        ResetLevel.onClick.AddListener(ResetLevelfunction);
        ExitButton.onClick.AddListener(ExitLevel);
        
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            interactionTime = interactionTime + 0.01f;
        }
    }
    
    void ResetMaze()
    {
        SceneManager.LoadScene(0);

    }
    void ResetLevelfunction()
    {
        ++tryCounter;
        Destroy(GameObject.FindGameObjectWithTag("Maze"));
        //Destroy(GameObject.FindGameObjectWithTag("Maze"));
        //Debug.Log("after destroy,Number of mazes: " + GameObject.FindGameObjectsWithTag("Maze").Length);
        if (GameObject.FindGameObjectsWithTag("Maze").Length<=1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Maze"));
            
        }
        else
        {
            Instantiate(MazePrefab);
            Debug.Log("after instance,Number of mazes: " + GameObject.FindGameObjectsWithTag("Maze").Length);
            
        }
        
        
    }
    void ExitLevel()
    {
        Application.Quit(0);

    }
}
