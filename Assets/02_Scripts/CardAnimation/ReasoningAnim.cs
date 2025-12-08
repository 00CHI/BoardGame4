using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ReasoningAnim : MonoBehaviour
{

    private void Awake()
    {
        Singleton.ReasoningAinm = this;
    }

    public void AppearCards()
    {
        foreach (Transform child in transform)
        {
            GameObject _card = child.gameObject;

            // 스케일 0으로 설정 (제자리에서 나타나기)
            _card.transform.localScale = Vector3.zero;

            // 0 → 1로 스케일 커지기
            _card.transform.DOScale(1f, 0.4f)
                .SetEase(Ease.OutBack);   // 팝업 느낌
        }
    }
}
