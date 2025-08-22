using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class QuestionLoader : MonoBehaviour
{
    public static Action QuestionsLoaded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadCSV();
    }

    private void LoadCSV()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "data.csv");

        if(!File.Exists(path))
        {
            Debug.Log($"csv file not found {path}");
        }

        ///string[] lines = File.ReadAllLines(path);
        List<string> lines = new List<string>();

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

        using (StreamReader sr = new StreamReader(fs))
        {
            while (!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine());
            }
        }

        for (int i = 1; i < lines.Count; i++)
        {
            string[] values = lines[i].Split(',');

            if (values.Length >= 6)
            {
                QuestionData q = new QuestionData();
                q.Question = values[0];
                q.options[0] = values[1];
                q.options[1] = values[2];
                q.options[2] = values[3];
                q.options[3] = values[4];
                q.answer = values[5];

                QuestionManager.instance.questionsList.Add(q);
            }
        }

        QuestionsLoaded.Invoke();
    }

    //public List<QuestionData> GetQuestions()
    //{
    //    return questionsList;
    //}
}
