using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 startPos;
    private bool _hovered = false;
    [SerializeField] private string levelName;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Animator fadeAnimator;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (_hovered)
        {
            transform.position = Vector3.Lerp(transform.position, startPos + Vector3.left/2, Time.deltaTime * 3f);
            if (Input.GetMouseButtonDown(0))
            {
                cam.Priority = 10;
                StartCoroutine(loadLevel());
            }
        }
        else  transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * 3f);
        
        
    }

    private IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(1.3f);
        fadeAnimator.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
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
