using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.TestTools;
using UnityEngine.Video;

namespace MiniGamesAssets.Yedidia.Scripts
{
    public class MissionPlate : MonoBehaviour
    {

        public static MissionPlate Instance;
        public event EventHandler OnShowPressBtnMsg;
        public event EventHandler OnHidePressBtnMsg;
        private List<int> missionRewardList = new List<int>()
        {
            30,
            23,
            54,
        };

        
        [SerializeField] private Vector3 boxSize;
        [SerializeField] private TextMeshProUGUI pointsTextIndicator;
        [SerializeField] private int missionId;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            boxSize = this.gameObject.transform.localScale;
        }

        private void Update()
        {
            // Layer mask to filter which objects the ray should hit (replace "Player" with your actual layer name)
            // var playerLayerMask = LayerMask.GetMask(PLAYER_LAYER_MASK_NAME);

            // Perform the box cast
            var isPlayerOnTop = Physics.BoxCast(transform.position, boxSize/2 ,Vector3.up);

            if (isPlayerOnTop)
            {
                OnShowPressBtnMsg?.Invoke(this, EventArgs.Empty);
                if (Input.GetKey(KeyCode.E) && missionRewardList[missionId] != 0 )
                {
                    PlayerMovement.Instance.points += missionRewardList[missionId];
                    missionRewardList[missionId] = 0;
                    pointsTextIndicator.text = "";
                    pointsTextIndicator.text = $"{PlayerMovement.Instance.points} points.";
                }
            }
            else
            {
                OnHidePressBtnMsg?.Invoke(this, EventArgs.Empty);
            }

            if (PlayerMovement.Instance.points == 107)
            {
                SceneManager.LoadScene("MapLobbyScene");
            } 
        }

    }
}