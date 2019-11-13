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
    public GameObject BallPrefab;
    public Text DebugData;
    public int baseDifficultyLevel;
    public int newDifficultyLevel;
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
        baseDifficultyLevel = 0;
        newDifficultyLevel = 0;
        ResetLevel.onClick.AddListener(ResetLevelfunction);
    }

    // Update is called once per frame
    void Update()
    {
        levelEndTime = Time.time;
        gameEndTime = Time.time;
        coinCounter = GameObject.FindGameObjectsWithTag("Coin").Length;
        DebugData.text = "Base Difficulty Level: " + baseDifficultyLevel + "\nNew Difficulty Level: " + newDifficultyLevel + "\nLevelTime: " + (levelEndTime - levelStartTime) + "seconds\nGameTime: " +(gameEndTime-gameStartTime)+"seconds\nLevel Counter: "+levelCounter+"\nTry Counter: "+tryCounter+"\nCoins Left: "+coinCounter+ "\nInteractionTime: "+interactionTime + "seconds\nRecognitionTime: " + (levelEndTime - levelStartTime- interactionTime) + "seconds\nNumber of Mazes: " + GameObject.FindGameObjectsWithTag("Maze").Length;
        
        ResetDifficulty.onClick.AddListener(ResetMaze);
       
        ExitButton.onClick.AddListener(ExitLevel);
        
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            interactionTime = interactionTime + 0.01f;
        }
        islevelCompleted();
    }
    
    void ResetMaze()
    {
        //SceneManager.LoadScene(0);
        baseDifficultyLevel = 0;
        newDifficultyLevel = 0;
        gameStartTime = Time.time;
        levelStartTime = Time.time;
        levelCounter = 0;        
        interactionTime = 0;
        ResetLevelfunction();
        tryCounter = 1;

    }
    void ResetLevelfunction()
    {
        ++tryCounter;
        Destroy(GameObject.FindGameObjectWithTag("Maze"));
        Destroy(GameObject.FindGameObjectWithTag("Ball"));
        if (GameObject.FindGameObjectsWithTag("Maze").Length>1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Maze"));
            
        }
        else
        {
            Instantiate(MazePrefab);
            Instantiate(BallPrefab);
            Debug.Log("after instance,Number of mazes: " + GameObject.FindGameObjectsWithTag("Maze").Length);
            
        }
        
        
    }
    void ExitLevel()
    {
        Application.Quit(0);

    }

    void measureChangeInDifficulty()
    {
        newDifficultyLevel++;
        if (tryCounter > 2)
        {
            newDifficultyLevel--;
            if (newDifficultyLevel == 0)
                newDifficultyLevel = 0;
        }
        if(levelEndTime-levelStartTime-interactionTime<10)
        {
            newDifficultyLevel++;
        }

    }

    void islevelCompleted()
    {
        if(GameObject.FindGameObjectsWithTag("Coin").Length==0)
        {
            ResetLevelfunction();
            tryCounter = 1;
            measureChangeInDifficulty();

        }

    }
    
}
