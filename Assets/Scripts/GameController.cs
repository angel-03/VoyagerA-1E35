using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameCompleteUi;
    public GameObject choiceUi;
    public GameObject intro;
    public TextMeshProUGUI levelText;

    [Header("Answers")]
    public string correctAns = " ";
    public string selectedAns;
    public Animation flash;
    
    [Header("Game Components")]
    public int level = 1;
    int randomAnomaly = 0;
    public GameObject[] anomalies;
    public GameObject normal;

    void Awake()
    {
        intro.SetActive(true);
        StartCoroutine(StartJourney());
    }

    IEnumerator StartJourney()
    {   
        yield return new WaitForSeconds(7f);
        intro.SetActive(false); 
        StartCoroutine(NextLevel());
    }

    void CheckAnswer(string selectedAns)
    {
        this.selectedAns = selectedAns;
        if(correctAns == selectedAns)
        {
           CorrectAnswer();
        }
        else
        {
           IncorrectAnswer();
        }
    }

    public void AnomalySelected()
    {
        selectedAns = "Anomaly";
        CheckAnswer(selectedAns);
    }

    public void NormalSelected()
    {
        selectedAns = "Normal";
        CheckAnswer(selectedAns);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.LogWarning("Complete");
    }

    void CorrectAnswer()
    {
        if(level < 7)
        {
            level++;
            StartCoroutine(NextLevel());
        }
        else
        {
            StartCoroutine(GameComplete());
        }
    }

    void IncorrectAnswer()
    {
        level = 1;
        levelText.text = "Trip: " + level.ToString();
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        levelText.text = "Trip: " + level.ToString();
        flash.Play("Flash");
        choiceUi.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("NewLevel");
        Cursor.lockState = CursorLockMode.None;

        anomalies[randomAnomaly].SetActive(false);
        normal.SetActive(false);

        int chance = Random.Range(0,9);
    
        if(chance > 6)
        {
            normal.SetActive(true);
            correctAns = "Normal";
        }
        else
        {
            randomAnomaly = Random.Range(10,anomalies.Length);
            anomalies[randomAnomaly].SetActive(true);
            if(anomalies[10])
                GameObject.Find("LadyTyping").GetComponent<LadyAnomaly>().StartLaughing(true);
            correctAns = "Anomaly";
        }
        Debug.Log(correctAns);
    }

    IEnumerator GameComplete()
    {
        flash.Play("Flash");
        choiceUi.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        yield return new WaitForSeconds(1.95f);
        gameCompleteUi.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0; 
    }
}
