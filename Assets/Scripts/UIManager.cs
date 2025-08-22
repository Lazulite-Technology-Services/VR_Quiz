using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] optionsText;

    [SerializeField] private Button NextButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();
    }

    private void Init()
    {
        QuestionLoader.QuestionsLoaded += LoadNextQuestion;
        NextButton.onClick.AddListener(LoadNextQuestion);
    }

    private void LoadNextQuestion()
    {
        QuestionData data = QuestionManager.instance.questionsList[GameManager.instance.CurrentQuestion];

        questionText.text = data.Question;
        optionsText[0].text = data.options[0];
        optionsText[1].text = data.options[1];
        optionsText[2].text = data.options[2];
        optionsText[3].text = data.options[3];

        GameManager.instance.CurrentQuestion++;
    }
}
