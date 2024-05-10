using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject mainPanel;

    public InfoData infoData;
    public GameObject planetSprite;

    public TextMeshProUGUI[] textInfos;
    public int moveSceneIdx;

    private void Awake()
    {
        switch (infoData.gameLevel)
        {
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    textInfos[i].text = infoData.earthInfos[i];
                }
                planetSprite.GetComponent<Image>().sprite = infoData.earthSprite;
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    textInfos[i].text = infoData.mercuryInfos[i];
                }
                planetSprite.GetComponent<Image>().sprite = infoData.mercurySprite;
                break;
        }

        moveSceneIdx = infoData.gameLevel + 1;
    }

    public void OnStart()
    {
        SceneManager.LoadScene(moveSceneIdx);
    }

    public void OnOpenMain()
    {
        mainPanel.SetActive(true);
    }

    public void OnCloseMain()
    {
        mainPanel.SetActive(false);
    }
    
    public void OnOpenInfo()
    {
        infoPanel.SetActive(true);
    }

    public void OnCloseInfo()
    {
        infoPanel.SetActive(false);
    }
}
