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
        InvokeRepeating("InstantiatePlatform", 3, repeatsecond);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePlatform()
    {
        var randint = Random.Range(0, platforms.Length);
        var platform = Instantiate(platforms[randint], instantiateTrans.transform.position, Quaternion.identity);
        platform.GetComponent<Platform>().platformSpeed = platformspeed;
    }

    IEnumerator platformMaker()
    {
        yield return null;
    }


}
