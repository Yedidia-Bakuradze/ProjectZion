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
        [SerializeField] private Transform p1;

        private float3 position;
        private float3 tangent;
        private float3 upVector;

        private void Start()
        {
            time = 0;
        }

        private void Update()
        {
            time = (time + Time.deltaTime*0.1f)%1;
            _splineContainer.Evaluate(_splineContainerIndex, time, out position, out tangent, out upVector);
            OnDrawGizmos();
        }

        private void OnDrawGizmos()
        {
            p1.position = position;
        }
    }
}
