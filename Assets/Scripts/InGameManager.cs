using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public InfoData infoData;

    public bool isGameFinished = false;
    public float maxOxygen = 100f;
    public float currentOxygen;
    public float oxygenDecreaseRate = 5f;
    public float oxygenIncreaseRate = 5f;
    
    public float maxVoteRate = 100f;
    public float currentVoteRate;
    public float voteRateDecreaseRate = 2f;
    public float voteRateIncreaseRate = 10f;

    public float voteRateThreshold = 50.1f;
    
    public Slider oxygenSlider;
    public Slider voteSlider;

    public GameObject PanelWin;
    public GameObject PanelLose;

    private void Start()
    {
        currentOxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = currentOxygen;

        currentVoteRate = maxVoteRate / 2;
        voteSlider.maxValue = maxVoteRate;
        voteSlider.value = currentVoteRate;
    }

    private void Update()
    {
        // 산소량 감소
        currentOxygen -= oxygenDecreaseRate * Time.deltaTime;
        currentVoteRate -= voteRateDecreaseRate * Time.deltaTime;

        // 산소량이 0 이하가 되면 게임 오버 처리
        if (currentOxygen <= 0f)
        {
            currentOxygen = 0f;
            if (isGameFinished == false)
            {
                GameOver();
                isGameFinished = true;
            }
        }
        oxygenSlider.value = currentOxygen;
        voteSlider.value = currentVoteRate;
    }

    public void IncreaseOxygen()
    {
        currentOxygen += oxygenIncreaseRate;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
    }
    
    public void IncreaseVoteRate()
    {
        currentVoteRate += voteRateIncreaseRate;
        currentVoteRate = Mathf.Clamp(currentVoteRate, 0, maxVoteRate);
    }
    
    private void GameOver()
    {
        // 게임 오버 처리 로직 작성
        if (currentVoteRate >= voteRateThreshold)
        {
            PanelWin.SetActive(true);
            infoData.gameLevel += 1;
            Debug.Log("You win");
            Time.timeScale = 0;
        }
        else
        {
            PanelLose.SetActive(true);
            Debug.Log("You lose");
            Time.timeScale = 0;
        }
    }

    public void OnLoadScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
