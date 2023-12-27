using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public Canvas canvasQuizPanel;
    public Canvas quizMessage;

    void Start()
    {
        QuizActivator.counter = 0;
        CanvasInvisible();
    }

    private void CanvasInvisible()
    {
        quizMessage.enabled = false;
        canvasQuizPanel.enabled = false;
    }
}
