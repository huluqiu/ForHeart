using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    private Vector2 originalVector2 = new Vector2(0.0f, 200.0f);
    private Vector2 targetVector2 = new Vector2(0.0f, 270.0f);
    private float originalScale = 0.8f;

    [SerializeField]
    private Text contentText;
    [SerializeField]
    private CanvasGroup contentCanvasGroup;
    [SerializeField]
    private Text subContentText;
    [SerializeField]
    private CanvasGroup subContentCanvasGroup;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        contentText.text = "";
        subContentText.text = "";

        contentText.gameObject.GetComponent<RectTransform>().anchoredPosition = originalVector2;
        contentText.gameObject.GetComponent<RectTransform>().localScale = Vector3.one * originalScale;
        contentCanvasGroup.alpha = 0.01f;

        subContentCanvasGroup.alpha = 0.01f;
    }

    private float deltaTime = 1.0f;
    public void Show(string s1, string s2)
    {
        contentText.text = s1;
        subContentText.text = s2;

        contentText.gameObject.GetComponent<RectTransform>().anchoredPosition = originalVector2;
        contentText.gameObject.GetComponent<RectTransform>().localScale = Vector3.one * originalScale;
        contentCanvasGroup.alpha = 0.01f;

        subContentCanvasGroup.alpha = 0.01f;

        UIEffectShow();
    }

    private void UIEffectShow()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(contentText.gameObject.GetComponent<RectTransform>().DOLocalMove(targetVector2, deltaTime));
        sequence.Insert(0.0f, contentText.gameObject.GetComponent<RectTransform>().DOScale(Vector3.one, deltaTime));
        sequence.Insert(0.0f, contentCanvasGroup.DOFade(1.0f, deltaTime));

        sequence.Insert(1.5f, subContentCanvasGroup.DOFade(1.0f, deltaTime));
    }

}
