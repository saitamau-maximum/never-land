using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        SnapToTarget();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 目標位置（Zは強制的に -10f）
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -10f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // 他のスクリプトがZを0にしても、ここで必ず -10f に上書きする
        smoothedPosition.z = -10f;
        transform.position = smoothedPosition;
    }

    public void SnapToTarget()
    {
        if (target == null) return;
        transform.position = new Vector3(target.position.x, target.position.y, -10f);
    }
}
