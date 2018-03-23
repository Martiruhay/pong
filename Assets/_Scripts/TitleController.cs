using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("music");
    }

    void Update ()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadSceneAsync("game");
	}
}