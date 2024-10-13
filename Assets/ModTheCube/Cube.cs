using System.Collections;
using System.Collections.Generic;
// using System.Drawing;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //renderer to manipulate colors and more
    public Renderer objectRenderer;

    //Get points to move from 
    public GameObject pointA;
    public GameObject pointB;
    private float elapsedTime = 0f;
    public float moveDuration = 60f;

    private float elapsedTimeC = 0f;
    public float moveDurationC = 10.0f;

    private Color colorA = Color.red;
    private Color colorB = Color.blue;
    
    void Start()
    {
        //Increase scale by 1 using shorthand
        transform.localScale = Vector3.one * 1.3f;
        

    }
    
    void Update()
    {

        //Call functions to move and change color using LERP functions below
        SmoothMove();
        ColorSwitch();

        //Rotate the cube in random direction on all axis
        transform.Rotate(10.0f * Time.deltaTime, 5.0f * Time.deltaTime, 15.0f * Time.deltaTime);

        //testing moving without LERP - MoveToward()
        // transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, 5 * Time.deltaTime);

    }

    void SmoothMove(){
        //If the time that has passed is less than the time allowed for move then...
        if(elapsedTime < moveDuration){
            //..First add to the elapsed time, the time that has passed since last frame 
            elapsedTime += Time.deltaTime;

            //normalise the time between 0 and 1, then store that for LERP 
            float t = elapsedTime / moveDuration;

            // Create smooth transition using LERP 
            transform.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, t);

        }
    }

    void ColorSwitch(){
        if(elapsedTimeC < moveDurationC){
            //..First add to the elapsed time, the time that has passed since last frame 
            elapsedTimeC += Time.deltaTime;

            //normalise the time between 0 and 1, then store that for LERP 
            float f = elapsedTimeC / moveDurationC;


            // ...change using smooth transition - LERP 
            objectRenderer.material.color = Color.Lerp(colorA, colorB, f);

        }
    }
}
