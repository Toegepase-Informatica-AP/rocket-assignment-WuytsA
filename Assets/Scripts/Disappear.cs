using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Disappear : MonoBehaviour
{
    private int points;
    public Text text;
    public GameObject playingCanvas;
    public GameObject winningCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        winningCanvas.SetActive(false);
        points = int.Parse(text.text);
    }

    // Update is called once per frame
    void Update()
    {
        points = int.Parse(text.text);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            print("points:" + points.ToString());
            points++;
            text.text = points.ToString();
            print(points.ToString());
            if(points == 4)
            {
                playingCanvas.SetActive(false);
                winningCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }
}
