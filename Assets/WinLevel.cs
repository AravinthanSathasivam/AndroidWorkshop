using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject RobotParts;

    void Start()
    {
        pointsToWin = RobotParts.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= pointsToWin) 
        {
            //Next Level
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoint() 
    {
        currentPoints++;
    }
}
