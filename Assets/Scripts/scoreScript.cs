using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text scoreText;

    public int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        scoreText.text = "Score: " + scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
