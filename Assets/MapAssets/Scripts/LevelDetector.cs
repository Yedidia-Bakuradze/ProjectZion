using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

namespace MapAssets.Scripts
{
    public class LevelDetector : MonoBehaviour
    {
        private const string PLAYER_LAYER_MASK_NAME = "Player";
        private readonly Vector3 boxSize = new Vector3(2f, 0.1f, 2f);

        [SerializeField] private string SceneName;
        [SerializeField] private int SceneId;

        private void Update()
        {
            // Layer mask to filter which objects the ray should hit (replace "Player" with your actual layer name)
            int playerLayerMask = LayerMask.GetMask(PLAYER_LAYER_MASK_NAME);

            // Perform the box cast
            bool isPlayerOnTop = Physics.BoxCast(transform.position, boxSize/2 ,Vector3.up);

            if (isPlayerOnTop)
            {
                Debug.Log("Player on top");
            }
        }
    }
}
