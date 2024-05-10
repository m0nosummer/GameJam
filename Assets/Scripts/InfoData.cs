using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info Data")]
public class InfoData : ScriptableObject
{
    [Header("Mercury")]
    [TextArea(5, 10)]
    public string[] mercuryInfos;

    [Header("Earth")]
    [TextArea(5, 10)]
    public string[] earthInfos;
}
