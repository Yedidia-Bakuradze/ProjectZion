using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Buutons : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button exitBtn;

    private void Awake()
    {
        playBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
            
        });

        exitBtn.onClick.AddListener(() => { 
            Application.Quit();
        });
    }
}
