using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int moveSceneIdx;
    private void OnStart()
    {
        SceneManager.LoadScene(moveSceneIdx);
    }

    private void OnSetInfo()
    {
        
    }
}
