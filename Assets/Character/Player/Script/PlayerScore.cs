using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public long Score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score += 1;
    }

    public void ResetScore() => Score = 0;
}
