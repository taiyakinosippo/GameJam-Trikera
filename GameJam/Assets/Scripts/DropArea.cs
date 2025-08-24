using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    public SetZone setZone;   // 親のSetZoneを参照する

    public void OnDrop(PointerEventData eventData)
    {
        // そのままSetZoneのOnDropを呼ぶ
        setZone.OnDrop(eventData);
    }
}