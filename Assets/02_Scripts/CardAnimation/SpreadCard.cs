using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class SpreadCard : MonoBehaviour
{
    [Header("Card Settings")]
     RectTransform startPos;
     int rows = 2;             // 행 개수
     int columns = 6;          // 열 개수
     float spacingX = 290f;    // 카드 간 가로 간격
     float spacingY = 470f;    // 카드 간 세로 간격
     float moveDuration = 0.3f; // 카드 등장 애니메이션 시간

    int _cardCount;
    RectTransform card;

    public List<Transform> cards = new List<Transform>();


    public void ReturnAllCards()
    {
        StartCoroutine(ReturnCards());
    }

    protected void SetCard(GameObject _PARENTPOS)
    {
        foreach (Transform child in _PARENTPOS.transform)
        {
            cards.Add(child);

            startPos = cards[0].GetComponent<RectTransform>();
        }

        if (startPos != null)
        {
            foreach (RectTransform cardsPos in cards)
            {
                cardsPos.anchoredPosition = startPos.anchoredPosition;
                cardsPos.localScale = Vector3.zero;
            }
        }

        StartCoroutine(SpreadCards());
    }

    IEnumerator SpreadCards()
    {
        Singleton.AudioManager.CardSpreadSFX();

        if (startPos == null)
        {
            Debug.LogWarning("StartPoint가 설정되지 않았습니다!");
            yield break;
        }

        //RectTransform _startPos = startPos.GetComponent<RectTransform>();

        int _cardIndex = 0;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                if(_cardIndex >= cards.Count)
                {
                    yield break;
                }

                card = cards[_cardIndex].GetComponent<RectTransform>();

                yield return new WaitForSeconds(0.2f);

                Vector2 _targetPos = new Vector2(
                    startPos.anchoredPosition.x + (x * spacingX),
                    startPos.anchoredPosition.y - (y * spacingY)        
                );

                StartCoroutine(AnimateCard(card, _targetPos, moveDuration));
                _cardIndex++;

            }
        }
    }

    IEnumerator AnimateCard(RectTransform _CARD, Vector3 _TARGETPOS, float _DURATION)
    {
        //Vector3 _startPos = Vector3.zero;
        Vector3 _startPos = new Vector3(_CARD.anchoredPosition.x, _CARD.anchoredPosition.y);
        Vector3 _startScale = Vector3.zero;
        Vector3 _endScale = Vector3.one;

        float t = 0f;
        while (t < _DURATION)
        {
            t += Time.deltaTime;
            float _progress = Mathf.SmoothStep(0, 1, t / _DURATION);
            _CARD.anchoredPosition = Vector3.Lerp(_startPos, _TARGETPOS, _progress);
            _CARD.localScale = Vector3.Lerp(_startScale, _endScale, _progress);
            yield return null;

        }

        //_CARD.localPosition = _TARGETPOS;
        _CARD.localScale = _endScale;
    }

    IEnumerator ReturnCards()
    {
        Singleton.AudioManager.CardLeaveSFX();

        for (int i = 0; i < cards.Count; i++)
        {
            RectTransform card = cards[i].GetComponent<RectTransform>();
            Vector2 originalPos = new Vector2(card.anchoredPosition.x, card.anchoredPosition.y);
            //((cards[0].GetComponent<RectTransform>();

            // 카드 되돌리는 애니메이션
            StartCoroutine(AnimateCardBack(card, originalPos, moveDuration));
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator AnimateCardBack(RectTransform _CARD, Vector3 _TARGETPOS, float _DURATION)
    {
        Vector3 _startPos = _CARD.anchoredPosition;
        Vector3 _startScale = _CARD.localScale;
        Vector3 _endScale = Vector3.zero;

        float t = 0f;
        while (t < _DURATION)
        {
            t += Time.deltaTime;
            float _progress = Mathf.SmoothStep(0, 1, t / _DURATION);
            _CARD.anchoredPosition = Vector3.Lerp(_startPos, _TARGETPOS, _progress);
            _CARD.localScale = Vector3.Lerp(_startScale, _endScale, _progress);
            yield return null;
        }

        _CARD.anchoredPosition = _TARGETPOS;
        _CARD.localScale = _endScale;
    }
}

    //public IEnumerator AssembleCards()
    //{
    //    if (startPos == null)
    //    {
    //        Debug.LogWarning("StartPoint가 설정되지 않았습니다!");
    //        yield break;
    //    }

    //   RectTransform _startPos = startPos.GetComponent<RectTransform>();


    //    int _cardIndex = cards.Count;

    //    for (int y = 0; y < rows; y--)
    //    {
    //        for (int x = 0; x < columns; x--)
    //        {
    //            if (_cardIndex <= cards.Count)
    //            {
    //                yield break;
    //            }

    //            card = cards[_cardIndex].GetComponent<RectTransform>();


    //            yield return new WaitForSeconds(0.2f);

    //            Vector2 _targetPos = new Vector2(
    //                startPos.anchoredPosition.x ,
    //                startPos.anchoredPosition.y
    //            );

    //            StartCoroutine(CardAssemble(_targetPos, moveDuration));
    //            _cardIndex--;
    //            Debug.Log(_cardIndex);
    //        }
    //    }
    //}

    //protected IEnumerator CardAssemble(Vector3 _TARGETPOS, float _DURATION)
    //{
    //    _cardCount = cards.Count;

    //    for (int i = _cardCount; i > 0; i--)
    //    {

    //        Vector3 _startPos = new Vector3(card.anchoredPosition.x, card.anchoredPosition.y);
    //        Vector3 _startScale = Vector3.one;
    //        Vector3 _endScale = Vector3.zero;

    //        float t = 0f;
    //        while (t < _DURATION)
    //        {
    //            t += Time.deltaTime;
    //            float _progress = Mathf.SmoothStep(0, 1, t / _DURATION);
    //            card.anchoredPosition = Vector3.Lerp(_startPos, _TARGETPOS, _progress);
    //            card.localScale = Vector3.Lerp(_startScale, _endScale, _progress);
    //            yield return null;

    //        }

    //        card.localPosition = _TARGETPOS;
    //        card.localScale = _endScale;
    //        cards.RemoveAt(i);
            

    //        yield return null;
    //    }

    //}

