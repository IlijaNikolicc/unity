using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Configuration;
using Unity.VisualScripting;
using System.IO;
using TMPro;
using System.Data;
using UnityEngine.XR;
using Mono.Data.Sqlite;
using System;
public class GetQuestion : MonoBehaviour
{
    /*
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
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string question = reader.GetString(1);
            string answerOne = reader.GetString(2);
            string answerTwo = reader.GetString(3);
            string answerThree = reader.GetString(4);
            string answerFour = reader.GetString(5);

            Debug.Log("id= " + id + " question =" + question + " answer one =" + answerOne + " answer two = " + answerTwo +" answer three ="+answerThree+" answer four =" +answerFour);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    */
    
}
