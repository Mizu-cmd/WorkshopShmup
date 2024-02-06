using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
public class MainMenu : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera globeCam, paperCam;
    private TextMeshProUGUI text;
    private bool _activateText;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        globeCam.Priority = 1;
        yield return new WaitForSeconds(2.5f);
        _activateText = true;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            paperCam.Priority = 2;
            Destroy(text.gameObject);
            Destroy(this);
        }
        if (_activateText) text.alpha = Mathf.PingPong(Time.time, 1);
    }
}
