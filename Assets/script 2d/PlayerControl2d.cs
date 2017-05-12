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

    //摄像头环绕角色都距离
    public float distanceZ = 10;

    //各种速度
	public float maxSpeed = 80f;
    public float speed = 20f;
    public float jumpForce = 70f;

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
//				rb.AddForce (Vector2.right * speed * horizontal);
//				horizontal is a float from 0 to 1 -> so in the end char will reach to max speed
				if (horizontal < 0.1f && horizontal > -0.1f) {
					horizontal = 0;
				}
				rb.velocity = new Vector2 ( maxSpeed*horizontal, rb.velocity.y);
//				print (horizontal);
//				print (rb.velocity.x);
//				print (maxSpeed);
			}

//			if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
//				rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
////				print ("11");
//			}

			//filp
			if (Input.GetKey (KeyCode.A)) {
				body.transform.rotation = new Quaternion (0, 180, 0, 0);
			}

			if (Input.GetKey (KeyCode.D)) {
				body.transform.rotation = new Quaternion (0, 0, 0, 0);
			}

			//jump
//			print(ground);
			if (ground) {
				jumping = false;
				secondJump = false;

				if (Input.GetButton ("Jump")) {
					rb.velocity = new Vector2 ( maxSpeed*horizontal, 3f* jumpForce);

//					if (rb.velocity.x >=3 ) {
//						rb.velocity = new Vector2 ( maxSpeed*horizontal, 1.6f* jumpForce);
//					}

//					rb.AddForce (Vector2.up * jumpForce);

					secondJump = true;
				}
			} else {
				jumping = true;
				print (rb.velocity.y);
				//Limit Jump Heights 
				if (rb.velocity.y <= 300 && rb.velocity.y > 0) {
					rb.velocity = new Vector2 ( maxSpeed*horizontal, (-jumpForce*0.2f)+rb.velocity.y);
				}

				//Limits downward slow stable process
				if (rb.velocity.y <= 0 ) {
					rb.velocity = new Vector2 ( maxSpeed*horizontal, (-jumpForce*0.2f)+rb.velocity.y);
				}
				if (secondJump && Input.GetButtonDown ("Jump")) {
//					rb.AddForce (Vector2.up * jumpForce);
					rb.velocity = new Vector2 ( maxSpeed*horizontal, jumpForce*3f);
					secondJump = false;
				}
			}


//			print (rb.velocity.y);
		}
    }
}