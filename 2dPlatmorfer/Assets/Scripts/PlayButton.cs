using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button PlayTheGame;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}

