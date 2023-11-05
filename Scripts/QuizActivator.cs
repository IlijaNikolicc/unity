using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuizActivator : MonoBehaviour
{

    public Canvas quizCanvas;
    public Canvas quizMessage;
    public GameObject obj;
    public TextMeshProUGUI question;
    public TextMeshProUGUI answerOne;
    public TextMeshProUGUI answerTwo;
    public TextMeshProUGUI answerThree;
    public TextMeshProUGUI answerFour;
    int randomLine;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Igrac"))
        {
            StartCoroutine(ShowTextForDuration(2f));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (obj.CompareTag("Rock_key") && other.CompareTag("Igrac") && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R is pressed");
            QuizCanvasEnable();
        }
        if (obj.CompareTag("House_1_key") && other.CompareTag("Igrac") && Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("6 is pressed");
            QuizCanvasEnable();
        }
        if (obj.CompareTag("House_2_key") && other.CompareTag("Igrac") && Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 is pressed");
            QuizCanvasEnable();
        }
        if (obj.CompareTag("House_3_key") && other.CompareTag("Igrac") && Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("7 is pressed");
            QuizCanvasEnable();
        }
        if (obj.CompareTag("House_4_key") && other.CompareTag("Igrac") && Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("8 is pressed");
            QuizCanvasEnable();
        }
        if (obj.CompareTag("House_5_key") && other.CompareTag("Igrac") && Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("5 is pressed");
            QuizCanvasEnable();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        quizCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private IEnumerator ShowTextForDuration(float duration)
    {
        quizMessage.enabled = true;
        yield return new WaitForSeconds(duration);
        quizMessage.enabled = false;
    }
    private void CursorEnable()
    { 
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }
    public void QuizCanvasEnable()
    {
        quizCanvas.enabled = true;
        CursorEnable();
        GetQuestionFromDB();
    }
    public void GetQuestionFromDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/quiz.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Id ,Question, AnswerOne, AnswerTwo, AnswerThree, AnswerFour " + "FROM Pitanja";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        randomLine = Random.Range(1, 5);
        Debug.Log("Random line"+randomLine.ToString());
        while (reader.Read())
        {
            if (randomLine == reader.GetInt32(0))
            {
                int id = reader.GetInt32(0);
                string questionStr = reader.GetString(1);
                string answerOneStr = reader.GetString(2);
                string answerTwoStr = reader.GetString(3);
                string answerThreeStr = reader.GetString(4);
                string answerFourStr = reader.GetString(5);
                question.text = questionStr;
                answerOne.text = answerOneStr;
                answerTwo.text = answerTwoStr;
                answerThree.text = answerThreeStr;
                answerFour.text = answerFourStr;
                Debug.Log("id= " + id + " question =" + question + " answer one =" + answerOne + " answer two = " + answerTwo + " answer three =" + answerThree + " answer four =" + answerFour);
            }
        
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
