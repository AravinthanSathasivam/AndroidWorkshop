using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizControl : MonoBehaviour
{
    public List<QuestionsAnswers> QA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject PointsPanel;

    public Text QuestionText;
    public Text ScoreText;

    int totalQuestion = 0;
    public int score;

    private void Start()
    {
        totalQuestion = QA.Count;
        PointsPanel.SetActive(false);
        createQuestions();     
    }

    void gameOver() 
    {
        QuizPanel.SetActive(false);
        PointsPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestion; 
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void correct() 
    {
        score += 1;
        QA.RemoveAt(currentQuestion);
        createQuestions();
    }

    public void wrong()
    {
        QA.RemoveAt(currentQuestion);
        createQuestions();
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QA[currentQuestion].answers[i];

            if (QA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

    void createQuestions()
    {
        if (QA.Count > 0)
        {
            currentQuestion = Random.Range(0, QA.Count);

            QuestionText.text = QA[currentQuestion].question;
            setAnswers();
        }
        else 
        {
            Debug.Log("Out of Questions");
            gameOver();
        }

        
    }
}
