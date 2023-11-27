using UnityEngine;

namespace MapAssets.Scripts
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [SerializeField] private Transform pointAB;
        [SerializeField] private Transform pointC;
        [SerializeField] private Transform pointBC;
        [SerializeField] private Transform pointAB_BC;
        
        [SerializeField] private Transform pointD;
        [SerializeField] private Transform pointCD;
        [SerializeField] private Transform pointBC_CD;

        [SerializeField] private Transform pointAB_BC__BC_CD;

        

        private float interpolateAmount;
        private void Update()
        {
            interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;
            pointAB.position = Vector3.Lerp(pointA.position,pointB.position,interpolateAmount);
            pointBC.position = Vector3.Lerp(pointB.position,pointC.position,interpolateAmount);

            pointCD.position = Vector3.Lerp(pointC.position, pointD.position, interpolateAmount);
            
            pointAB_BC.position = Vector3.Lerp(pointAB.position,pointBC.position,interpolateAmount);
            pointBC_CD.position = Vector3.Lerp(pointBC.position, pointCD.position, interpolateAmount);

            pointAB_BC__BC_CD.position = Vector3.Lerp(pointAB_BC.position, pointBC_CD.position, interpolateAmount);
            // pointAB_BC__BC_CD.position = GetCubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount);
        }

        private Vector3 GetCubicLerp(Vector3 a,Vector3 b,Vector3 c,Vector3 d,float alpha)
        {
            Vector3 ab_bc = GetQuadratic(a, b, c, alpha);
            Vector3 bc_cd = GetQuadratic(b, c, d, alpha);
            return Vector3.Lerp(ab_bc, bc_cd, alpha);
        }

        private Vector3 GetQuadratic(Vector3 a,Vector3 b,Vector3 c,float alpha)
        {
            Vector3 ab = Vector3.Lerp(a, b, alpha);
            Vector3 bc = Vector3.Lerp(b,c, alpha);
            return Vector3.Lerp(ab, bc, alpha);
        }
        
    }
}
