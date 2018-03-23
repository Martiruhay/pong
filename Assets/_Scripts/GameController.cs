using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct levelStruct
{
    public Vector3[] positions;
    public float cameraSize;
}

public class GameController : MonoBehaviour
{
    public int level;
    public float levelUpTime;

    public GameObject framePrefab;
    
    [SerializeField]
    levelStruct[] levels;

    GameObject[] frames = new GameObject[4];

    public bool locked;
    public float levelTime = 0;

    void Start ()
    {
        init();
    }

    void init()
    {
        levelTime = 0;

        // Delete previous frames
        foreach (GameObject g in frames)
        {
            Destroy(g);
        }

        // Create new frames
        for (int i = 0; i < levels[level].positions.Length; i++)
        {
            GameObject g = Instantiate(framePrefab, levels[level].positions[i], Quaternion.identity, gameObject.transform);
            frames[i] = g;
        }

        // Set camera size
        Camera.main.orthographicSize = levels[level].cameraSize;

        StopCoroutine(levelUpTimer());
        StartCoroutine(levelUpTimer());
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            init();
        }
	}

    public void Die()
    {
        if (locked)
            return;
        else
            locked = true;
        Invoke("unlock", 1);

        AudioManager.instance.Play("ouch");

        if (--level < 0)
        {
            // Game Over
            print("Game Over!");
            SceneManager.LoadSceneAsync("gameOver");
            return;
        }
        init();
    }

    void levelUp()
    {
        if (level >= levels.Length - 1)
            return;
        AudioManager.instance.Play("wii");
        ++level;
        init();
    }

    void unlock()
    {
        locked = false;
    }

    IEnumerator levelUpTimer()
    {
        while (levelTime < levelUpTime)
        {
            levelTime += Time.deltaTime;
            yield return null;
        }
        levelUp();
    }
}