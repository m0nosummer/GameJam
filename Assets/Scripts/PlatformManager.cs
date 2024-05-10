using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platforms;
    public float repeatsecond;
    public float platformspeed;
    public Transform instantiateTrans;
    public Transform deleteTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("player");
            var randint = Random.Range(0, platforms.Length);
            Vector2 newpos = new Vector2(transform.position.x-100, transform.position.y + 10);
            var platform = Instantiate(platforms[randint], newpos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void InstantiatePlatform()
    {
        var randint = Random.Range(0, platforms.Length);
        var platform = Instantiate(platforms[randint], instantiateTrans.transform.position, Quaternion.identity);
        
    }

    IEnumerator platformMaker()
    {
        yield return null;
    }


}
