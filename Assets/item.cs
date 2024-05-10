using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Item { paper, oxygen, fire }

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
                    _inGameManager.IncreaseVoteRate();
                    break;

                case Item.oxygen:
                    _inGameManager.IncreaseOxygen();
                    break;
                
                case Item.fire:
                    _inGameManager.IncreaseVoteRate();
                    break;

                default:
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
