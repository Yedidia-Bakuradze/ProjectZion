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
        [SerializeField] private Transform p2;

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
            
            time = (time + Time.deltaTime*0.1f)%1;
            _splineContainer.Evaluate(_splineContainerIndex, time, out position, out tangent, out upVector);
            float3 right = Vector3.Cross(tangent, upVector).normalized;
            p1.position = position + (right * width);
            p2.position = position + (-right * width);
            
        }
    }
}
