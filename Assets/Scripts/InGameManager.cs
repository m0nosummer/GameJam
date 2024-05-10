using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public InfoData _InfoData;
    
    public float maxOxygen = 100f;
    public float currentOxygen;
    public float oxygenDecreaseRate = 5f;
    public float oxygenIncreaseRate = 5f;
    
    public float maxVoteRate = 100f;
    public float currentVoteRate;
    public float voteRateDecreaseRate = 2f;
    public float voteRateIncreaseRate = 10f;

    public float voteRateThreshold;
    
    public Slider oxygenSlider;
    public Slider voteSlider;


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
            GameOver();
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
            
        }
        else
        {
            
        }
        Debug.Log("Game Over!");
    }
}
