using System;
using Unity.VisualScripting;
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

        
        
        private void Awake()
        {
            // soundManager.onClick.AddListener();
            // keyBindingBtn.onClick.AddListener();
            // showStatsBtn.onClick.AddListener();
            quitGameBtn.onClick.AddListener(Application.Quit);
            closeWindowBtn.onClick.AddListener(Hide);
        }
        private void Start()
        {
            Hide();
        }

        
        /// <summary>
        /// Shows the UI.
        /// </summary>
        private void Show()
        {
            gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Closes the UI.
        /// </summary>
        private void Hide()
        {
            gameObject.SetActive(false);
            Debug.Log("Close button was clicked");
        }
    }
}
