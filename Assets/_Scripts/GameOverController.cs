﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{	
	void Update ()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadSceneAsync("title");
	}
}