using System;
using _GeneralAssets.Scripts;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace MapAssets.Scripts
{
    public class LevelDetector : MonoBehaviour
    {
        private const string PLAYER_LAYER_MASK_NAME = "Player";
        [SerializeField] private Vector3 boxSize;

        [SerializeField] private string SceneName;
        [SerializeField] private int SceneId;



        [SerializeField] private TextMeshProUGUI levelTitle;
        [SerializeField] private GameObject levelUiComponent;

        private void Start()
        {
            boxSize = this.gameObject.transform.localScale;
            Hide();
        }

        private void Update()
        {
            // Layer mask to filter which objects the ray should hit (replace "Player" with your actual layer name)
            // var playerLayerMask = LayerMask.GetMask(PLAYER_LAYER_MASK_NAME);

            // Perform the box cast
            var isPlayerOnTop = Physics.BoxCast(transform.position, boxSize/2 ,Vector3.up);

            if (isPlayerOnTop)
            {
                Show();
                levelTitle.text = $"Level {SceneId} - {SceneName}";
                if (Input.GetKey(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneName);
                }
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            levelUiComponent.SetActive(true);
        }
        private void Hide()
        {
            levelUiComponent.SetActive(false);
        } 
    }
}
