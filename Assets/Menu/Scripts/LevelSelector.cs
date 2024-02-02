using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 startPos;
    private bool _hovered = false;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if(_hovered)
            transform.position = Vector3.Lerp(transform.position, startPos + Vector3.left * 5, Time.deltaTime * 3f);
        else  transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * 3f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _hovered = false;
    }
}
