using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (플레이어)
    public float smoothSpeed = 0.125f; // 카메라 이동 속도

    private void LateUpdate()
    {
        // 카메라의 목표 위치 계산 (플레이어의 위치와 동일)
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // 카메라를 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
