using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float moveDistance = 50f;   // 올라가는 거리
    public float moveDuration = 0.2f;  // 이동 속도

    private Vector3 originalPos;
    private Vector3 originalRotation;
    public Transform targetPos;
    public GameObject blackBG;
    public Text blackText;

    private bool isMoving = false;
    public  bool isUpMoving = false;

    void Start()
    {
        originalPos = transform.localPosition;
        originalRotation = transform.localEulerAngles;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isMoving && !isUpMoving)
            StartCoroutine(MoveCard(originalPos, originalPos + Vector3.up * moveDistance));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isMoving &&!isUpMoving)
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

    public void CheckPosition()
    {
        isMoving = true;

        if (isMoving && !isUpMoving)
        {
            isUpMoving = true;
     

            Sequence seq = DOTween.Sequence();

            seq.Append(transform.DOMove(targetPos.position, 0.5f).SetEase(Ease.InOutQuad));
            seq.Join(transform.DORotate(Vector3.zero, 0.5f).SetEase(Ease.InOutQuad));

        }
        else if (isUpMoving)
        {
            isMoving = false;

            //Sequence seq = DOTween.Sequence();

            //seq.Append(transform.DOMove(originalPos, 0.5f).SetEase(Ease.InOutQuad));
            //seq.Join(transform.DORotate(originalRotation, 0.5f).SetEase(Ease.InOutQuad));

            transform.localPosition = originalPos;
            transform.localEulerAngles = originalRotation;

            isUpMoving = false;

        }




    }
}