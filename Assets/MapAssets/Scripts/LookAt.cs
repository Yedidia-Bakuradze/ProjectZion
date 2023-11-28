using System.Net.NetworkInformation;
using UnityEngine;

namespace MapAssets.Scripts
{
    public class LookAt : MonoBehaviour
    {
        private enum DirectionMode
        {
            LookAt,
            InvertedLookAt,
            CameraForward,
            InvertedCameraForward,
        }

        [SerializeField] private DirectionMode mode;

        private void LateUpdate()
        {
            switch (mode)
            {
                case DirectionMode.LookAt:
                    transform.LookAt(Camera.main.transform);
                    break;
                case DirectionMode.InvertedLookAt:
                    Vector3 directionVector = transform.position - Camera.main.transform.position;
                    transform.LookAt(transform.position + directionVector);
                    break;
                case DirectionMode.CameraForward:
                    transform.forward = Camera.main.transform.forward;
                    break;
                case DirectionMode.InvertedCameraForward:
                    transform.forward = -Camera.main.transform.forward;
                    break;
                default:
                    Debug.Log("Direction invalid!");
                    break;
            }
        }
    }
}
