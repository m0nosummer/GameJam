using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Item { paper, oxygen }

public class item : MonoBehaviour
{
    public Item items;
    [SerializeField] private InGameManager _inGameManager;

    private void Awake()
    {
        _inGameManager = FindObjectOfType<InGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            switch (items)
            {
                case Item.paper:
                    Debug.Log(collision + " collided");
                    break;

                case Item.oxygen:
                    _inGameManager.IncreaseOxygen();
                    break;

                default:
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
