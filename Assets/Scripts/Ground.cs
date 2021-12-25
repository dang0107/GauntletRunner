using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
public float speed = 0.5f;
//private Renderer groundRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //groundRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * speed % 1; // The % 1 keeps offset between 0 and 1
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);
    }

    public void SlowDown()
    {
        speed /= 2; 
    }

    public void SpeedUp()
    {
        speed *= 2;
    }
}
