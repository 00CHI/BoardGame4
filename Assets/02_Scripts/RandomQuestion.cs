using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomQuestion : MonoBehaviour
{
    Button questionButton;

    string randomQuestion;

    [SerializeField]
    TextMeshProUGUI questionText;
    TextMeshProUGUI allQuestionText;


    List<string> questions = new List<string>()
    {
        "이름에 ㄱ이 들어갑니까?",//1
        "이름에 ㄱ이 들어갑니까?",//2
        "이름에 ㅇ이 들어갑니까?",//3
        "이름에 ㅇ이 들어갑니까?",//4
        "이름에 ㅂ이 들어갑니까?",//5
        "이름에 ㅂ이 들어갑니까?",//6
        "당신은 여성입니까?",//7
        "당신은 여성입니까?",//8
        "당신은 남성입니까?",///9
        "당신은 남성입니까?",///10
        "당신은 장발입니까?",//11
        "당신은 장발입니까?",//12
        "당신은 단발입니까?",//13
        "당신은 단발입니까?",//14
        "당신은 숏컷입니까?",//15
        "당신은 숏컷입니까?",//16
        "당신은 1학년입니까?",//17
        "당신은 1학년입니까?",//18
        "당신은 2학년입니까?",//19
        "당신은 2학년입니까?",//20
        "당신은 3학년입니까?",//21
        "당신은 3학년입니까?",//22
        "당신은 15시 이전에 범행을 저질렀습니까?",//23
        "당신은 15시 이전에 범행을 저질렀습니까?",//24
        "당신은 15시 이전에 범행을 저질렀습니까?",//25
        "당신은 15시 이후에 범행을 저질렀습니까?",//26
        "당신은 15시 이후에 범행을 저질렀습니까?",//27
        "당신은 15시 이후에 범행을 저질렀습니까?",//28
        "당신은 13시 이전에 범행을 저질렀습니까?",//29
        "당신은 13시 이전에 범행을 저질렀습니까?",//30
        "당신은 13시 이전에 범행을 저질렀습니까?",//31
        "당신은 16시 이후에 범행을 저질렀습니까?",//32
        "당신은 16시 이후에 범행을 저질렀습니까?",//33
        "당신은 16시 이후에 범행을 저질렀습니까?",//34
        "당신의 죄는 가볍습니까?",//35
        "당신의 죄는 가볍습니까?",//36
        "당신의 죄는 가볍습니까?",//37
        "당신은 타인에게 피해 끼쳤습니까?",//38
        "당신은 타인에게 피해 끼쳤습니까?",//39
        "당신은 타인에게 피해 끼쳤습니까?",//40
        "당신은 물건을 훔쳤습니까?",//41
        "당신은 물건을 훔쳤습니까?",//42
        "당신은 학업에 관한 죄를 지었습니까?",//43
        "당신은 학업에 관한 죄를 지었습니까?",//44
        "당신의 죄는 청결과 관련이 있습니까?",//45
        "당신의 죄는 청결과 관련이 있습니까?",//46
        "당신은 선생님과 관련된 죄를 지었습니까?",//47
        "당신은 선생님과 관련된 죄를 지었습니까?",//48
        "당신은 화장실에 교장 선생님 낙서를 했습니까?",//49
        "당신은 교생 선생님께 고백했습니까?",//50
        "당신은 선생님께 반말했습니까?",//51
        "당신은 술을 훔쳐 마셨습니까?",//52
        "당신은 담배를 훔쳐 폈습니까?",//53
        "당신은 학생 회비를 훔쳤습니까?",//54
        "당신은 숙제를 안 했습니까?",//55
        "당신은 시험을 안 쳤습니까?",//56
        "당신은 땡땡이를 쳤습니까?",//57
        "당신은 청소를 안 하고 도망쳤습니까?",//58
        "당신은 씻지 않고 지속적으로 등교했습니까?",//59
        "당신은 화장실 물을 일부러 안 내렸습니까?"//60
    };



    // Start is called before the first frame update
    void Start()
    {
        questionButton = GetComponent<Button>();
        allQuestionText = GetComponentInChildren<TextMeshProUGUI>();
        questionButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        randomQuestion = GetRandomQuestion();
        questionText.text = randomQuestion;

        int questionsCount = questions.Count;
        allQuestionText.text = questionsCount.ToString();

        //if(questions.Count)

        //string question = questions[index];
    }

    string GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        questions.RemoveAt(index);

        return questions[index];
    }
}
