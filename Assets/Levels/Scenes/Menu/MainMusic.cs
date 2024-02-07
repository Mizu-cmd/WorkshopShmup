using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public AudioClip MainMenu;
    void Start()
    {
        AudioSource.PlayClipAtPoint(MainMenu, transform.position, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
