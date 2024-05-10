using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float currentOxygen;
    public float oxygenDecreaseRate = 3f;
    public float oxygenIncreaseRate = 5f;
    
    public float maxVoteRate = 100f;
    public float currentVoteRate;
    public float voteRateDecreaseRate = 3f;
    
    public Slider oxygenSlider;
    public Slider voteSlider;


    private void Start()
    {
        currentOxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = currentOxygen;
    }

    private void Update()
    {
        // 산소량 감소
        currentOxygen -= oxygenDecreaseRate * Time.deltaTime;

        // 산소량이 0 이하가 되면 게임 오버 처리
        if (currentOxygen <= 0f)
        {
            currentOxygen = 0f;
            GameOver();
        }
        oxygenSlider.value = currentOxygen;
    }

    public void IncreaseOxygen()
    {
        currentOxygen += oxygenIncreaseRate;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
    }

    private void GameOver()
    {
        // 게임 오버 처리 로직 작성
        Debug.Log("Game Over!");
    }
}
