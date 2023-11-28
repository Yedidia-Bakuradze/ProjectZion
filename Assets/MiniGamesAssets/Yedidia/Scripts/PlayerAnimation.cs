using MapAssets.Scripts;
using UnityEngine;

namespace MiniGamesAssets.Yedidia.Scripts
{
    public class PlayerAnimation : MonoBehaviour
    {
        private const string Is_Walking = "IsWalking";
        private const string Is_Running = "IsRunning";
        
        
        [SerializeField] private Player player;
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(Is_Walking,player.GetIsPlayerWalking());
            _animator.SetBool(Is_Running, player.GetIsPlayerRunning());
        }
    }
}
