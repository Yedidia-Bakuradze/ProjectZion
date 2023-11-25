using System;
using _GeneralAssets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace ControlsUIAssets.Scripts
{
    public class OptionsAndControlsUIScript : MonoBehaviour
    {
        
        [SerializeField] private Button soundManager;
        [SerializeField] private Button keyBindingBtn;
        [SerializeField] private Button showStatsBtn;
        [SerializeField] private Button quitGameBtn;
        [SerializeField] private Button closeWindowBtn;

        [SerializeField] private Transform UI;
        
        private void Awake()
        {
            soundManager.onClick.AddListener(() =>
            {
                Debug.Log("Yet developed!");
            });
            keyBindingBtn.onClick.AddListener(() =>
            {
                Debug.Log("Key binding isn't optional yet - We're using specific referenced key codes!");
            });
            showStatsBtn.onClick.AddListener(() =>
            {
                Debug.Log(GameStats.JoinDate);
            });
            quitGameBtn.onClick.AddListener(Application.Quit);
            closeWindowBtn.onClick.AddListener(Hide);
        }
        private void Start()
        {
            Hide();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Show();
            }
        }

        /// <summary>
        /// Shows the UI.
        /// </summary>
        private void Show()
        {
            UI.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Closes the UI.
        /// </summary>
        private void Hide()
        {
            UI.gameObject.SetActive(false);
        }
    }
}
