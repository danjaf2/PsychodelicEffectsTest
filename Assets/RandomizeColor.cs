using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RandomizeColor : MonoBehaviour
{
    float red;
    float green;
    float blue;
    float timeLeft;
    Color targetColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
             this.GetComponent<Tilemap>().color = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.0f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            this.GetComponent<Tilemap>().color = Color.Lerp(this.GetComponent<Tilemap>().color, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }

   
}
