using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float moveDistance = 50f;   // 올라가는 거리
    public float moveDuration = 0.2f;  // 이동 속도

    private Vector3 originalPos;
    private bool isMoving = false;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isMoving)
            StartCoroutine(MoveCard(originalPos, originalPos + Vector3.up * moveDistance));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isMoving)
            StartCoroutine(MoveCard(transform.localPosition, originalPos));
    }

    System.Collections.IEnumerator MoveCard(Vector3 start, Vector3 end)
    {
        isMoving = true;
        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            transform.localPosition = Vector3.Lerp(start, end, t);
            yield return null;
        }
        transform.localPosition = end;
        isMoving = false;
    }
}