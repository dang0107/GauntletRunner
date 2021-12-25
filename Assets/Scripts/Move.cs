using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private GameController control;
    
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!control.IsGameOver)
        {
            transform.Translate(0,0,control.startSpeed);
        }
    }
}
