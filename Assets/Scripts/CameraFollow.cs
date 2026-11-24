using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 追従する対象（プレイヤーの駒）
    public Transform target;
    
    // 追従の滑らかさ（値が小さいほど遅れてついてくる）
    public float smoothSpeed = 0.125f;
    
    // プレイヤーとカメラの距離（自動計算されます）
    private Vector3 offset;

    void Start()
    {
        if (target != null)
        {
            // ゲーム開始時のカメラとプレイヤーの位置関係（距離）を記憶する
            offset = transform.position - target.position;
        }
    }

    // プレイヤーの移動（Update）が終わった後にカメラを動かすため LateUpdate を使う
    void FixedUpdate()
    {
        if (target == null) return;

        // 目標となるカメラの位置を計算
        Vector3 desiredPosition = target.position + offset;
        
        // 現在の位置から目標位置へ滑らかに移動させる
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
