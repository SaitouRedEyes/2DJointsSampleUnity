using UnityEngine;
using System.Collections;

public class DragDrop : MonoBehaviour
{
    private Vector3 screenPoint, offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
    }

    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
}