using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isGameEnded = false;

    public GameObject completeLevelUI;
    public TMPro.TextMeshProUGUI completeLevelGemTMP;
    public TMPro.TextMeshProUGUI completeLevelTMP;
    public GameObject failLevelUI;

    public GameObject mainScreenUI;

    public TMPro.TextMeshProUGUI gemCounterTMP;

    public GameObject player;

    public TMPro.TextMeshProUGUI[] levelTxt;

    int currentGemCounter = 0;

    int totalGemCounter = 0;

    bool isLevelFinished = false;
    bool isLevelCompleted = false;

    int currentLevel;

    private void Awake()
    {
        totalGemCounter = GameInfo.totalGems;
        gemCounterTMP.SetText(totalGemCounter + "");
        currentLevel = GameInfo.level+1;
        if (currentLevel % 3 == 1)
        {
            levelTxt[0].SetText(currentLevel+"");
            levelTxt[1].SetText((currentLevel+1) + "");
            levelTxt[2].SetText((currentLevel+2) + "");
        }
        else if (currentLevel % 3 == 2)
        {
            levelTxt[0].SetText((currentLevel-1) + "");
            levelTxt[1].SetText(currentLevel + "");
            levelTxt[2].SetText((currentLevel + 1) + "");
        }
        else
        {
            levelTxt[0].SetText((currentLevel - 2) + "");
            levelTxt[1].SetText((currentLevel - 1) + "");
            levelTxt[2].SetText(currentLevel + "");
        }
    }

    public void PlayerFailed()
    {
        if (!isGameEnded && !isLevelFinished)
        {
            isGameEnded = true;
            DisablePlayerInput();
            failLevelUI.SetActive(true);
            Debug.Log("GAME OVER!");

        }
    }

    public void CompleteLevel(int multiplier)
    {
        if (!isLevelCompleted)
        {
            isLevelCompleted = true;
            Debug.Log("Complete Level!");
            DisablePlayerInput();

            completeLevelTMP.SetText("GREAT!\n" + multiplier + "X");
            completeLevelGemTMP.SetText(currentGemCounter * multiplier + "");
            completeLevelUI.SetActive(true);

            totalGemCounter += currentGemCounter * multiplier;
            GameInfo.totalGems = totalGemCounter;
        }
    }

    public void StartLevel()
    {
        Debug.Log("Level Started!");
        mainScreenUI.SetActive(false);
        EnablePlayerInput();
        //camera.GetComponent<CameraFollow>()
        currentGemCounter = 0;
    }

    public void RestartButton()
    {
        Invoke("Restart",1f);
    }

    public void NextButton()
    {
        Invoke("LoadNextLevel", 1f);
    }

    public void SwipeToPlayButton()
    {
        StartLevel();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    public void LoadNextLevel()
    {
        GameInfo.level++;
        if (currentLevel%3!=0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//loads next scene on the build order
        else
            SceneManager.LoadScene(0);//loads next scene on the build order
    }

    public void TakeGem()
    {
        currentGemCounter++;
        gemCounterTMP.SetText(totalGemCounter + currentGemCounter + "");
    }

    public void LevelFinished()
    {
        isLevelFinished = true;
    }
    void DisablePlayerInput()
    {
        player.GetComponent<SwerveInputSystem>().DisableSwerveInput();
        player.GetComponent<SwerveMovement>().DisableSwerveMove();
    }

    void EnablePlayerInput()
    {
        player.GetComponent<SwerveInputSystem>().EnableSwerveInput();
        player.GetComponent<SwerveMovement>().EnableSwerveMove();
    }


}
