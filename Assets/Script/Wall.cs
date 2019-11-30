using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] bool move;
    [SerializeField] float duration; // moveがtrueの時のアニメーションの時間
    [SerializeField] Vector3 start = Vector3.zero; // moveがtrueの時の移動開始地点
    [SerializeField] Vector3 end = Vector3.zero; // moveがtrueの時の移動終了地点
    [SerializeField] MoveDirection moveDirection; // moveがtrueの時の移動の仕方

    Vector3 pos;
    float time = 0.0f;
    bool dir = true;
    enum MoveDirection
    {
        Normal, // 常に順方向
        Alternate // 交互に方向が変わる(行ったり来たり)
    }

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {

        // 壁の動き
        if (move)
        {
            time += Time.deltaTime;

            // アニメーションが終了したら0に戻す。MoveDirectionがalternateの時のために方向を逆にする。
            if (time > duration)
            {
                time = 0;
                dir = !dir;
            }

            // 方向が逆の時はtimeを1-timeとすることで逆方向の位置を計算する
            if (moveDirection == MoveDirection.Alternate && !dir)
            {
                transform.position = Vector3.Lerp(pos + start, pos + end, 1.0f - time / duration);
            }
            // 順方向の場合はそのまま計算する
            else
            {
                transform.position = Vector3.Lerp(pos + start, pos + end, time / duration);
            }
        }

    }
}
