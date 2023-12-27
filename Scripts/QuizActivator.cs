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
using System.Linq;
using System.Data.Common;

public class QuizActivator : MonoBehaviour
{
    public List<UnityEngine.UI.Button> buttons = new List<UnityEngine.UI.Button>();
    public Canvas quizCanvas;
    public Canvas quizMessage;
    public Canvas correctAnswerCanvas;
    public Canvas wrongAnswerCanvas;
    public Canvas cantUseAgainCanvas;
    public GameObject obj;
    public TextMeshProUGUI question;
    public TextMeshProUGUI answerOne;
    public TextMeshProUGUI answerTwo;
    public TextMeshProUGUI answerThree;
    public TextMeshProUGUI answerFour;
    public FirstPersonController cont;
    public static string correctAnswer = "abc";
    int randomLine;
    public static int counter = 0;
    private int[] keys = new int[6];
    string DATABASE_NAME = "/quiz.db";
    
    void Start()
    {
        counter = 0;
        
        correctAnswerCanvas.enabled = false;
        wrongAnswerCanvas.enabled = false;
        cantUseAgainCanvas.enabled = false;
        GetKeyArray(keys);
        // Dodavanje funkcije za svako dugme u listi
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => ButoonPressed(button));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Igrac"))
        {
            StartCoroutine(ShowTextForDuration(2f));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (obj.CompareTag("Rock_key") && other.CompareTag("Igrac") && Input.GetKey(KeyCode.R))
        {
            if (keys[0] == 0)
            {
                Debug.Log("R is pressed");
                QuizCanvasEnable();
                keys[0] = 1;
            }
            else
                StartCoroutine(ShowAnswerCheckForDuration(cantUseAgainCanvas));
        }
        if (obj.CompareTag("House_1_key") && other.CompareTag("Igrac") && Input.GetKey(KeyCode.Alpha6))
        {
            if (keys[1] == 0)
            {
                Debug.Log("6 is pressed");
                QuizCanvasEnable();
                keys[1] = 1;
            }
           else
                StartCoroutine(ShowAnswerCheckForDuration(cantUseAgainCanvas));
           
        }
        if (obj.CompareTag("House_2_key") && other.CompareTag("Igrac") && Input.GetKey(KeyCode.Alpha3))
        {
            if (keys[2] == 0)
            {
                Debug.Log("3 is pressed");
                QuizCanvasEnable();
                keys[2] = 1;
            }
            else
                StartCoroutine(ShowAnswerCheckForDuration(cantUseAgainCanvas));
        }
        if (obj.CompareTag("House_3_key") && other.CompareTag("Igrac") && Input.GetKey(KeyCode.Alpha7))
        {
            if (keys[3] == 0)
            {
                Debug.Log("7 is pressed");
                QuizCanvasEnable();
                keys[3] = 1;
            }
            else
                StartCoroutine(ShowAnswerCheckForDuration(cantUseAgainCanvas));
        }
        if (obj.CompareTag("House_4_key") && other.CompareTag("Igrac") && Input.GetKey(KeyCode.Alpha8))
        {
            if (keys[4] == 0)
            {
                Debug.Log("8 is pressed");
                QuizCanvasEnable();
                keys[4] = 1;
            }
            else
                StartCoroutine(ShowAnswerCheckForDuration(cantUseAgainCanvas));
        }
        if (obj.CompareTag("House_5_key") && other.CompareTag("Igrac") && Input.GetKey(KeyCode.Alpha5))
        {
            if (keys[5] == 0)
            {
                Debug.Log("5 is pressed");
                QuizCanvasEnable();
                keys[5] = 1;
            }
            else
                StartCoroutine(ShowAnswerCheckForDuration(cantUseAgainCanvas));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        quizCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cont.cameraCanMove = true;
    }
    private IEnumerator ShowTextForDuration(float duration)
    {
        quizMessage.enabled = true;
        yield return new WaitForSeconds(duration);
        quizMessage.enabled = false;
    }
    private IEnumerator ShowAnswerCheckForDuration(Canvas canvas)
    {
        canvas.enabled = true;
        yield return new WaitForSeconds(1f);
        canvas.enabled = false; 
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
        cont.cameraCanMove = false;
    }
    public void GetQuestionFromDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/quiz.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        randomLine = UnityEngine.Random.Range(1, 4);
        string sqlQuery = "SELECT * FROM Pitanja where Id LIKE "+ randomLine;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
                int id = reader.GetInt32(0);
                string questionStr = reader.GetString(1);
                correctAnswer = reader.GetString(2);
                Debug.Log("OVO JE TACAN ODGOVOR " + correctAnswer);
                List<string> answers = new List<string>();
                for (int i = 2; i < 6; i++)
                    answers.Add(reader.GetString(i));

                question.text = questionStr;
                RotateList(answers);
                answerOne.text = answers[0];
                answerTwo.text = answers[1];
                answerThree.text = answers[2];
                answerFour.text = answers[3];
                Debug.Log("LISTA id= " + id + " question =" + questionStr + " answer one =" + answers[0] + " answer two = " + answers[1] + " answer three =" + answers[2] + " answer four =" + answers[3] +"\n CORRECT ANSWER: "+ correctAnswer);

            

        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        Debug.Log("OVO JE TACAN ODGOVOR  dasdasd" + correctAnswer);
    }
/*
    private void CreateTable()
    {   
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = "CREATE TABLE IF NOT EXISTS [table_name] (" +
                "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "[name] VARCHAR(255)  NOT NULL," +
                "[age] INTEGER DEFAULT '18' NOT NULL)";

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
*/
    public void GetKeyArray(int[] keys)
    {
        for (int i = 0; i < keys.Length; i++)
            keys[i] = 0;
    }
    static void RotateList<T>(List<T> list)
    {
        int places = Random.Range(0, 4);
        int n = list.Count;

        // Korišćenje LINQ za dobijanje ciklički pomerene liste
        List<T> rotatedList = list.Skip(places % n).Concat(list.Take(places % n)).ToList();

        // Kopiranje elemenata nazad u originalnu listu
        for (int i = 0; i < n; i++)
        {
            list[i] = rotatedList[i];
        }
    }
    public void ButoonPressed(UnityEngine.UI.Button button)
    {
        Debug.Log("Tacan odgovor " + correctAnswer);
        Debug.Log("Dugme odgovor " + button.GetComponentInChildren<TextMeshProUGUI>().text);
        if (button.GetComponentInChildren<TextMeshProUGUI>().text.Equals(correctAnswer))
        {
            Debug.Log("correct");
            quizCanvas.enabled = false;
            counter++;
            StartCoroutine(ShowAnswerCheckForDuration(correctAnswerCanvas));
        }
        else
        {
            Debug.Log("wrong");
            quizCanvas.enabled = false;
            counter++;
            StartCoroutine(ShowAnswerCheckForDuration(wrongAnswerCanvas));
        }
        Debug.Log("OVO JE COUNTER : " + counter);
    }

}
