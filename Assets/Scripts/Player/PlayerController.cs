using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //實例化
    public static PlayerController instance;
    void Awake() {
        if (instance != null){
            return;
        }
        instance = this;
    }

    public GameObject MB;
    private Rigidbody2D MBRb;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Animator animator;

    public float shootForce = 10f;
    public float pullForce = 20f;

    private Vector3 currentPlayerPos;

    public bool isHold;

    void Start()
    {
        MBRb = MB.GetComponent<Rigidbody2D>();
        spriteRenderer = MB.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // 發射方塊
        if (Input.GetMouseButtonDown(0) && isHold)
        {
            Vector3 targetPosition = GetMouseWorldPosition();
            Vector3 direction = (targetPosition - transform.position).normalized;
            ShootBlock(direction);
        }

        // 吸回方塊
        if (Input.GetMouseButton(0) && !isHold)
        {
            PullBlock();
        }

        //瞬移
        if (Input.GetMouseButtonDown(1)){
            animator.SetTrigger("Teleport");
        }
    }

    private void ShootBlock(Vector3 direction)
    {
        spriteRenderer.color = new Color(255, 255, 255, 1);
        MB.transform.SetParent(null); // 移除方塊的父物件
        MBRb.AddForce(direction * shootForce, ForceMode2D.Impulse);
        isHold = false;
    }

    private void PullBlock()
    {
        Vector2 playerPosition = transform.position;
        Vector2 blockPosition = MB.transform.position;
        Vector2 pullDirection = (playerPosition - blockPosition);
        MBRb.AddForce(pullDirection * pullForce);
    }

    public void Teleport(){
        currentPlayerPos = MB.transform.position;
        transform.position = currentPlayerPos;
    }

    //獲取滑鼠世界座標
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
