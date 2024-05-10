using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info Data")]
public class InfoData : ScriptableObject
{
    [Header("GameState")] 
    public int gameLevel = 0;
    
    [Header("Mercury")]
    [TextArea(5, 10)]
    public string[] mercuryInfos;
    
    public Sprite mercurySprite;

    [Header("Earth")]
    [TextArea(5, 10)]
    public string[] earthInfos;
    
    public Sprite earthSprite;
}
