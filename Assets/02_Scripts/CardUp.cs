using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardUp : MonoBehaviour
{
    public Button myButton;        // 버튼
    public GameObject blackPanel;        // 버튼
    public RectTransform myButtonPos;        // 버튼
    public RectTransform infoImage1;   // 첫 번째 이미지
    public RectTransform infoImage2;   // 두 번째 이미지
    public float moveDistance = 1500f; // 이동 거리
    public float moveDuration = 1f;   // 이동 시간

    private bool isUp = false; // 현재 올라간 상태인지 여부

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (!isUp)
        {
            // 올라가기
            StartCoroutine(Move(infoImage1, Vector3.up * moveDistance));
            StartCoroutine(Move(infoImage2, Vector3.up * moveDistance));
            StartCoroutine(Move(myButtonPos, Vector3.up * moveDistance));
            blackPanel.SetActive(true);
        }
        else
        {
            // 내려가기
            StartCoroutine(Move(infoImage1, Vector3.down * moveDistance));
            StartCoroutine(Move(infoImage2, Vector3.down * moveDistance));
            StartCoroutine(Move(myButtonPos, Vector3.down * moveDistance));
            blackPanel.SetActive(false);

        }

        // 상태 반전
        isUp = !isUp;
    }

    IEnumerator Move(RectTransform target, Vector3 direction)
    {
        Vector3 startPos = target.anchoredPosition;
        Vector3 endPos = startPos + direction;

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            target.anchoredPosition = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        target.anchoredPosition = endPos;
    }
}