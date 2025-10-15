//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class SelectCard : MonoBehaviour
{
    [SerializeField]
    GameObject studentCanvas;
    [SerializeField]
    GameObject timeCanvas;
    [SerializeField]
    GameObject crimeCanvas;


    public Button studentButton;
    Button timeButton;
    Button crimeButton;

    Button[] studentButtons;
    Button[] timeButtons;
    Button[] crimeButtons;


    [Header("Card Settings")]
    public GameObject cardPrefab;   // 카드 프리팹
    public int rows = 2;            // 행 개수
    public int columns = 4;         // 열 개수
    public float spacingX = 150f;   // 카드 간 가로 간격
    public float spacingY = 200f;   // 카드 간 세로 간격
    public float appearDuration = 0.3f; // 카드가 등장하는 시간 (애니메이션)

    private List<GameObject> cards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SelectAllButtons();

        studentButton.onClick.AddListener(SelectStudentCard);
        timeButton.onClick.AddListener(SelectTimeCard);
        crimeButton.onClick.AddListener(SelectCrimeCard);

        CreateCards();
        StartCoroutine(SpreadCards());
    }

    //Student => Time => Crime
    void SelectStudentCard()
    {
        SetFalseCard(timeCanvas, studentCanvas, crimeCanvas);
    }
    void SelectTimeCard()
    {
        SetFalseCard(crimeCanvas, studentCanvas, timeCanvas);
    }
    void SelectCrimeCard()
    {
        crimeCanvas.SetActive(false);
    }

    void SelectAllButtons()
    {
        studentButton = SelectButton(studentCanvas, studentButtons);
        timeButton = SelectButton(timeCanvas, timeButtons);
        crimeButton = SelectButton(crimeCanvas, crimeButtons);

    }

    Button SelectButton(GameObject _PARENTCANVAS, Button[] _ALLBUTTONS)
    {
        _ALLBUTTONS = _PARENTCANVAS.GetComponentsInChildren<Button>();

        if (_ALLBUTTONS == null || _ALLBUTTONS.Length == 0)
        {
            Debug.LogWarning($"{_PARENTCANVAS.name} 안에 Button이 없습니다!");
            return null;
        }

        int _buttonIndex = Random.Range(0, _ALLBUTTONS.Length);
        Button _selectedButton = _ALLBUTTONS[_buttonIndex];
        
        for(int i = 0; i< _ALLBUTTONS.Length; i++)
        {
            if (i == _buttonIndex)
            {
                _ALLBUTTONS[i].interactable = true; // 클릭 가능
            }
            else
            {

            }
        }

        return _selectedButton;


    }


    void SetFalseCard(GameObject _CANVAS1, GameObject _CANVAS2, GameObject _CANVAS3)
    {
        _CANVAS1.SetActive(true);
        _CANVAS2.SetActive(false);
        _CANVAS3.SetActive(false);
    }

    void CreateCards()
    {
        int _total = rows * columns;

        for (int i = 0; i < _total; i++)
        {
            GameObject _card = Instantiate(cardPrefab, transform);
            _card.transform.localScale = Vector3.zero; // 처음에는 0으로 숨김
            cards.Add(_card);
        }
    }

    IEnumerator SpreadCards()
    {
        // 중심 기준으로 카드 정렬
        float _startX = -(columns - 1) * spacingX / 2f;
        float _startY = (rows - 1) * spacingY / 2f;

        int _index = 0;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                if (_index >= cards.Count)
                    yield break;

                GameObject card = cards[_index];
                Vector3 targetPos = new Vector3(_startX + (x * spacingX), _startY - (y * spacingY), 0);
                StartCoroutine(AnimateCard(card.transform, targetPos, appearDuration));

                _index++;
                yield return new WaitForSeconds(0.05f); // 한 장씩 순차적으로 나오는 효과
            }
        }
    }

    IEnumerator AnimateCard(Transform _CARD, Vector3 _TARGETPOS, float _DURATION)
    {
        Vector3 _startPos = Vector3.zero;
        Vector3 _startScale = Vector3.zero;
        Vector3 _endScale = Vector3.one;

        float _t = 0f;
        while (_t < _DURATION)
        {
            _t += Time.deltaTime;
            float _progress = Mathf.SmoothStep(0, 1, _t / _DURATION);
            _CARD.localPosition = Vector3.Lerp(_startPos, _TARGETPOS, _progress);
            _CARD.localScale = Vector3.Lerp(_startScale, _endScale, _progress);
            yield return null;
        }

        _CARD.localPosition = _TARGETPOS;
        _CARD.localScale = _endScale;
    }
}
