using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _startPos;
    private bool _hovered = false;
    [SerializeField] private CinemachineVirtualCamera cam;
    
    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        if (_hovered)
        {
            transform.position = Vector3.Lerp(transform.position, _startPos + Vector3.left / 2, Time.deltaTime * 3f);
            if (Input.GetMouseButtonDown(0))
            {
                Clicked();
            }
        }
        else transform.position = Vector3.Lerp(transform.position, _startPos, Time.deltaTime * 3f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _hovered = false;
    }


    public void Clicked()
    {
        cam.Priority += 2;
    }
}
