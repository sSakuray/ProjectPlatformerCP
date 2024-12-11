using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InMenuButton : MonoBehaviour
{
    [SerializeField] private Button InMenuGame;
    public void InMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}


