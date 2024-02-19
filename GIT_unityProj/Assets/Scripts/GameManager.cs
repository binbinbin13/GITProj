using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject GameWinPanel;
    public GameObject GameLosePanel;
    public Text timerText;
    public Text pointText;
    public Text healthText;
    public Text instuctionText;
    public int pointCount;
    public int pointToWin;
    public float healthCount;

    private float elapsedGameTime;
    private float elapsedInstructionTime;
    private float instructionDisplayTime;
    private bool isGameOver;
    private bool isGameWin;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        pointCount = 0;

        DisplayInstuction("Collect " + pointToWin + ", activated the blue trigger and get to the end goal!", 5);
        SetHealthText();
        SetPointText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        elapsedGameTime += Time.deltaTime;
        SetTimeText(elapsedGameTime);

        if (instuctionText.text.Length > 0) 
        {
            elapsedInstructionTime += Time.deltaTime;

            if (elapsedInstructionTime > instructionDisplayTime)
            {
                HideInstuction();
            }
        }
    }

    public void SetGameOver(bool isGameWin)
    {
        isGameOver = true;

        if (!GameWinPanel.activeSelf && !GameLosePanel.activeSelf)
        {
            if (isGameWin)
            {
                GameWinPanel.SetActive(true);
                AudioManager.instance.StopBGM();
                AudioManager.instance.PlayGameWinSfx();
            }
            else
            {
                GameLosePanel.SetActive(true);
                AudioManager.instance.StopBGM();
                AudioManager.instance.PlayGameLoseSfx();
            }
        }
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    public int GetPointCount()
    {
        return pointCount;
    }
    public int GetPointToWin()
    {
        return pointToWin;
    }

    public void AddPoint()
    {
        pointCount++;
        SetPointText();
    }

    public void AddHealth(float addHealthValue)
    {
        healthCount += addHealthValue;

        if (healthCount > 100)
            healthCount = 100;

        SetHealthText();
    }

    public void MinusHealth(float minusHealthValue)
    {
        healthCount -= minusHealthValue;
        AudioManager.instance.PlayDamageSfx();

        if (healthCount < 0)
        {
            healthCount = 0;
            SetGameOver(false);
        }

        SetHealthText();
    }

    public void DisplayInstuction(string text, float displayDuration) 
    {
        instructionDisplayTime = displayDuration;
        SetInstructionText(text);
    }

    private void HideInstuction()
    {
        elapsedInstructionTime = 0;
        instuctionText.gameObject.transform.parent.gameObject.SetActive(false);
        instuctionText.text = "";
    }

    private void SetInstructionText(string text) 
    {
        instuctionText.transform.parent.gameObject.SetActive(true);
        instuctionText.text = text;
    }

    private void SetPointText()
    {
        pointText.text = "Point: " + pointCount;
    }

    private void SetHealthText()
    {
        healthText.text = "Health: " + System.String.Format("{0:00}", healthCount);
    }

    private void SetTimeText(float time)
    {
        timerText.text = "Time: " + FormatTime(time);
    }

    public void MenuBtn() 
    {
        SceneManager.LoadScene("MenuScene");  
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = System.String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }
}
