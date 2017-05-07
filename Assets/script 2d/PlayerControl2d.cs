using UnityEngine;
using System.Collections;

/// <summary>
/// 简单都角色控制器
/// </summary>
public class PlayerControl2d : MonoBehaviour
{
	public GameObject body;
	public GameObject groundChecker;
	public Sprite playerImg;

	//受伤闪烁频率，越小越快，最小为1
	public int flashRate = 5;

	//摄像头的移动范围
	public float minX = 8;
	public float maxX = 724;
	public float minY = 7;
	public float maxY = 176;

    //摄像头环绕角色都距离
    public float distanceZ = 10;

    //各种速度
	public float maxSpeed = 20f;
    public float speed = 10f;
    public float jumpForce = 1f;

    private Transform m_camera;
    //目标点坐标
    private Vector3 m_targetPosition;
    //目标点角度
    private Quaternion m_targetRotation;
    //移动偏移距离
    private Vector3 step;
	//移动方向
    private float horizontal;
    private float vertical;
	//刚体
    private Rigidbody2D rb;
	//无敌帧数
	private int invincibleTime = 0;
	//贴图
	private SpriteRenderer sr;
	//各种flag
	private bool jumping; 
	private bool secondJump; 
	private bool ground;
	private bool moveable;


    void Awake()
    {
        m_camera = Camera.main.transform;
    }

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		sr = body.GetComponent<SpriteRenderer> ();
    }

    void FixedUpdate()
    {
		invincible ();
        CharMove();
        //CamFollow();
		moveable = true;
    }

	void OnCollisionEnter2D(Collision2D other){
		//print ("HIT!1");
		if (other.gameObject.tag == "enemy") {
			//print ("HIT!2");
			injure ();
		}
	}

	private void invincible(){
		if (invincibleTime > 40) {
			moveable = false;
		}
		if (invincibleTime > 0) {
			invincibleTime--;
			if (invincibleTime % flashRate < 1) {
				sr.sprite = playerImg;
			} else {
				sr.sprite = null;
			}
		}
	}

	private void injure(){
		if (invincibleTime <= 0) {
			CharacterInfo info = GetComponent<CharacterInfo> ();
			info.damaged (1);
			invincibleTime = 60;
			rb.AddForce (new Vector2 (-5000,5000));
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawLine (groundChecker.transform.position, body.transform.position);
	}

    private void CharMove()
    {
        //get info
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

		ground =  Physics2D.Linecast (groundChecker.transform.position, body.transform.position, LayerMask.GetMask ("Ground"));

		if (moveable) {
			//moving
			if (rb.velocity.x * horizontal < maxSpeed) {
				rb.AddForce (Vector2.right * speed * horizontal);
			}

			if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
				rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
			}

			//filp
			if (Input.GetKey (KeyCode.A)) {
				body.transform.rotation = new Quaternion (0, 180, 0, 0);
			}

			if (Input.GetKey (KeyCode.D)) {
				body.transform.rotation = new Quaternion (0, 0, 0, 0);
			}

			//jump
			print(ground);
			if (ground) {
				jumping = false;
				secondJump = false;
				if (Input.GetButton ("Jump")) {
					rb.AddForce (Vector2.up * jumpForce);
					secondJump = true;
				}
			} else {
				jumping = true;
				if (secondJump && Input.GetButtonDown ("Jump")) {
					rb.AddForce (Vector2.up * jumpForce);
					secondJump = false;
				}
			}
		}
    }
		
    /// <summary>
    /// 摄像头跟随方法
    /// </summary>
    private void CamFollow()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        Vector3 Pos = new Vector3(0, 0, distanceZ);

        Vector3 move = rotation * Pos;

		Vector3 newPos = body.transform.position + move;


		if (newPos.x > maxX) {
			newPos.x = maxX;
		}else if (newPos.x < minX) {
			newPos.x = minX;
		}

		if (newPos.y > maxY) {
			newPos.y = maxY;
		}else if (newPos.y < minY) {
			newPos.y = minY;
		}
		m_camera.position = newPos;

        m_camera.rotation = rotation;
    }
}