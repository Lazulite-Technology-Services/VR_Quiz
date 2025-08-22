using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    [SerializeField] private int questionsCount = 6;

    public List<QuestionData> questionsList = new List<QuestionData>();

    private void OnEnable()
    {
        instance = this;
    }

    private void Awake()
    {
        
    }

    private void LoadNextQuestion()
    {

    }
}

[System.Serializable]
public class QuestionData
{
    public string Question;
    public string[] options = new string[4];
    public string answer;
}
