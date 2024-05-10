using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float platformSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = new Vector2(transform.position.x, transform.position.y - platformSpeed*Time.deltaTime);
        transform.position = moveVec;
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }
}
