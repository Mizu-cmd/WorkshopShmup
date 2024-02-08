using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SettingsSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 startPos;
    private bool _hovered = false;
    [SerializeField] private CinemachineVirtualCamera cam;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (_hovered)
        {
            transform.position = Vector3.Lerp(transform.position, startPos + Vector3.left / 2, Time.deltaTime * 3f);
            if (Input.GetMouseButtonDown(0))
            {
                cam.Priority = 10;
                SceneManager.LoadScene("Zoo");
            }
        }
        else transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * 3f);


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
