using UnityEngine;

namespace MapAssets.Scripts
{
    public class PlayerMapAnimation : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        private Animator _animator;
        private const string IsWalking = "IsWalking";
        private const string IsRunning = "IsRunning";
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(IsWalking,_player.GetIsPlayerWalking());
            _animator.SetBool(IsRunning,_player.GetIsPlayerRunning());
        }
    }
}
