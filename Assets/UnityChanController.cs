using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションをするためのコンポーネントを入れる
    Animator animator;

    //unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigit2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプの速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度
    float jumpVelocity = 20;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //アニメータのコンポーネントを取得
        this.animator = GetComponent<Animator>();
        //Rigitbody2Dのコンポーネントを取得する
        this.rigit2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //着地状態でクリックされた場合
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力をかける
            this.rigit2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減衰する
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigit2D.velocity.y > 0)
            {
                this.rigit2D.velocity *= this.dump;
            }
        }
    }
}
