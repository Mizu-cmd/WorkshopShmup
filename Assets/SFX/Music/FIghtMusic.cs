using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIghtMusic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public AudioClip FightingMusic;
    void Start()
    {
        AudioSource.PlayClipAtPoint(FightingMusic,transform.position, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
