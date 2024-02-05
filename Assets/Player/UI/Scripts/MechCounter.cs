using System;
using TMPro;
using UnityEngine;

public class MechCounter : MonoBehaviour
{
    private TextMeshProUGUI _mechCount;

    private void Start()
    {

    }

    private void OnEnable()
    {
        _mechCount = GetComponent<TextMeshProUGUI>();
        _mechCount.text = $"Mech number : {PlayerPrefs.GetInt("MechCount")}";
    }
}
