using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Item
{
    paper,
    oxygen
}

public class item : MonoBehaviour
{

    public Item items;
    

    
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
                    Debug.Log(collision + " collided");
                    break;

                default:
                    break;
            }
        
        }
    }
}
