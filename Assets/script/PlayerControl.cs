using UnityEngine;
using System.Collections;

/// <summary>
/// 简单都角色控制器
/// </summary>
public class PlayerControl : MonoBehaviour
{
    //鼠标点击特效
    public Transform effect;

    //摄像头环绕角色的角度
    public float angleX = 0;
    public float angleY = 0;
    public float angleZ = 0;

    //摄像头环绕角色都距离
    public float distanceX = 0;
    public float distanceY = 0;
    public float distanceZ = 0;

    //速度
    public float rayBound = 0.5f;
    public float speed = 10f;
    public float jumpForce = 1f;

    private CharacterController character;
    private Transform m_camera;

    //目标点坐标
    private Vector3 m_targetPosition;

    //目标点角度
    private Quaternion m_targetRotation;

    //是否开始移动
    private bool startMove = false;

    //移动偏移距离
    private Vector3 step;

    private float horizontal;
    private float vertical;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;
	private int invincibleTime = 0;
	private SpriteRenderer sr;
	private bool right; 


	public Sprite playerImg;

    public float gravity = 10f;
	public int flashRate = 5;


    void Awake()
    {
        character = GetComponent<CharacterController>();
        m_camera = Camera.main.transform;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		sr = GetComponent<SpriteRenderer> ();
    }

    void FixedUpdate()
    {
        CharMove();
        CamFollow();
		if (invincibleTime > 0) {
			invincibleTime--;
			if (invincibleTime % flashRate < 1) {
				sr.sprite = playerImg;
			} else {
				sr.sprite = null;
			}
		}
    }

	void OnCollisionEnter(Collision other){
		//print ("HIT!1");
		if (other.collider.tag == "enemy") {
			//print ("HIT!2");
			injure ();
		}
	}

	private void injure(){
		if (invincibleTime <= 0) {
			CharacterInfo info = GetComponent<CharacterInfo> ();
			info.damaged (1);
			invincibleTime = 60;
		}
	}

    private void CharMove()
    {
        //move
        character.Move(moveDirection * Time.deltaTime);
        //get info
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

		if(Input.GetKey(KeyCode.A)){
			transform.rotation = new Quaternion(0,180,0,0);
		}

		if(Input.GetKey(KeyCode.D)){
			transform.rotation = new Quaternion(0,0,0,0);
		}

        if (horizontal > 0.01f)
        {
            moveDirection.x = horizontal * speed;
        }
        //控制角色左移（按a键和左键时）  
		if (!right && horizontal < 0.01f)
        {
            moveDirection.x = horizontal * speed;
        }

        if (character.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            //gravity ctrl
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }



    /// <summary>
    /// 摄像头跟随方法
    /// </summary>
    private void CamFollow()
    {
        Quaternion rotation = Quaternion.Euler(angleX, angleY, angleZ);

        Vector3 Pos = new Vector3(distanceX, distanceY, distanceZ);

        Vector3 move = rotation * Pos;

        m_camera.position = transform.position + move;

        m_camera.rotation = rotation;
    }
}