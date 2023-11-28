using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

namespace MapAssets.Scripts
{
    public class SplinerSampler : MonoBehaviour
    {
        [SerializeField] private SplineContainer _splineContainer;
        [SerializeField] private int _splineContainerIndex;
        [SerializeField] private float time;
        [SerializeField] private Transform player;

        private float3 position;
        private float3 tangent;
        private float3 upVector;
        [SerializeField] private float width;

        private void Start()
        {
            time = 0;
        }

        private void Update()
        {
            if (time is >= 1f or <= 0)
                time = 0;
            if (Input.GetKey(KeyCode.A))
            {
                time += Time.deltaTime * 0.1f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                time -= Time.deltaTime * 0.1f;
            }
            _splineContainer.Evaluate(_splineContainerIndex, time, out position, out tangent, out upVector);
            player.position = position;
        }
    }
}
