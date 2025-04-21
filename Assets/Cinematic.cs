using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject video;
    void Start()
    {
        CinematicStart();
        //Invoke(nameof(CinematicEnd), 17f);
    }
    void Update()
    {
        Invoke(nameof(CinematicEnd), 17f);
    }

    public void CinematicStart()
    {
        player.gameObject.SetActive(false);
    }

    public void CinematicEnd()
    {
        player.gameObject.SetActive(true);
        video.gameObject.SetActive(false);
    }

}
