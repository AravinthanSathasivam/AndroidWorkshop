using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{

    public bool isCorrect = false;

    public QuizControl quiz;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quiz.correct();
        }
        else 
        {
            Debug.Log("Wrong Answer");
            quiz.wrong();
        }
    }
}
