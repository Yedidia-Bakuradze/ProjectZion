using UnityEngine;
using UnityEngine.UI;

namespace ControlsUIAssets.Scripts
{
    public class OptionsAndControlsUIScript : MonoBehaviour
    {
        [SerializeField] private Button quitGameBtn;
        [SerializeField] private Button closeWindowBtn;
        [SerializeField] private GameObject mainUI;


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

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                mainUI.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Closes the UI.
        /// </summary>
        private void Hide()
        {
            this.gameObject.SetActive(false);
            Debug.Log("Close button was clicked");
        }
    }
}
