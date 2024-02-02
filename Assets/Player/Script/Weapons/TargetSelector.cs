using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSelector : MonoBehaviour
{
    private Text selector;
    private SecondaryWeapon _weapon;
    private Camera _camera;
    
    private void Start()
    {
        selector = GetComponent<Text>();
        _weapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SecondaryWeapon>();
        _camera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var enemy = hit.transform.GetComponent<Enemy>();
            if (enemy == null) return;

            _weapon.targetTransform = enemy.transform;
        }

        if (_weapon.targetTransform != null)
        {
            var destination = _camera.WorldToScreenPoint(_weapon.targetTransform.position);
            selector.rectTransform.position =
                Vector3.Lerp(selector.rectTransform.position, destination, Time.deltaTime * 5f);
        }
    }
}
