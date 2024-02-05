using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    private Transform _level;
    void Start()
    {
        _level = GameObject.FindGameObjectWithTag("Level").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _level.Translate(_level.right * scrollSpeed * Time.deltaTime);
    }
}
