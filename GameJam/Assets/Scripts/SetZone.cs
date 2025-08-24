using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SetZone : MonoBehaviour, IDropHandler
{
    private Image target;
    private float distance = 0.1f;
    private Image image;
    public ImageCheck imagecheck;

    public ComboManager comboManager;
    int combo = 0;

    // 移動の処理
    private float waitTime = 2f;  // 待機時間
    private float moveDuration = 1f;   // 移動にかかる時間

    private bool Hit = false;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var dragged = eventData.pointerDrag.GetComponent<DragPiece>();
        if (dragged != null)
        {
            // Dropされたピースの画像でSetZoneを更新
            Image draggedImage = dragged.GetComponent<Image>();
            if (draggedImage != null)
            {
                image.sprite = draggedImage.sprite;
                //image.SetNativeSize(); // サイズもピースに合わせる場合
            }
        }

        imagecheck.RightImageNo(dragged.pieceID);
    }

    void Update()
    {
        combo = comboManager.comboCount;
        if (target != null && Hit == false)
        {
             // 相手の位置を取得
            Vector3 targetPosition = target.transform.position;
            // 自分と相手の距離を取得
            float dist = Vector3.Distance(transform.position, targetPosition);
            // 近づいたら関数を呼ぶ
            if (dist < distance)
            {
                Destroy(target);

                Debug.Log("近づきました");
                imagecheck.Continuous();

                Hit = true;

               
            }
        }
    }

    public void RightImageTransForm(Image  image)
    {
        Hit = false;
        Debug.Log("aaaa");
        target = image;
        StartCoroutine(MoveImageAfterDelay());
        StartCoroutine(MoveAfterDelay());
    }

    IEnumerator MoveImageAfterDelay()
    {
        int effectiveCombo = Mathf.Min(combo, 20);

        float adjustedWait = Mathf.Max(0.05f, waitTime - effectiveCombo * 0.08f);
        float adjustedDuration = Mathf.Max(0.1f, moveDuration - effectiveCombo * 0.05f);

        // 待機
        yield return new WaitForSeconds(adjustedWait);

        RectTransform rect = target.GetComponent<RectTransform>();
        if (rect == null) yield break;

        Vector3 startPos = rect.anchoredPosition;

        // 🎯 Yはそのまま、Xだけ0にする
        Vector3 endPos = new Vector3(0f, startPos.y, startPos.z);

        float elapsed = 0f;
        while (elapsed < adjustedDuration)
        {
            elapsed += Time.deltaTime;
            rect.anchoredPosition = Vector3.Lerp(startPos, endPos, elapsed / adjustedDuration);
            yield return null;
        }

        rect.anchoredPosition = endPos; // 最終位置補正
    }

    IEnumerator MoveAfterDelay()
    {
        int effectiveCombo = Mathf.Min(combo, 20);

        float adjustedWait = Mathf.Max(0.05f, waitTime - effectiveCombo * 0.08f);
        float adjustedDuration = Mathf.Max(0.1f, moveDuration - effectiveCombo * 0.05f);

        // 待機
        yield return new WaitForSeconds(adjustedWait);

        RectTransform rect = GetComponent<RectTransform>();
        if (rect == null) yield break;

        Vector3 startPos = rect.anchoredPosition;

        // 🎯 自分も Xだけ0 にする
        Vector3 endPos = new Vector3(0f, startPos.y, startPos.z);

        float elapsed = 0f;
        while (elapsed < adjustedDuration)
        {
            elapsed += Time.deltaTime;
            rect.anchoredPosition = Vector3.Lerp(startPos, endPos, elapsed / adjustedDuration);
            yield return null;
        }

        if (rect != null)
        {
            rect.anchoredPosition = new Vector2(500f, 100f); 
        }
    }

}
