using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾� �ӵ�
    public float Speed = 4.0f;
    
    float width;        // ������
    float length;       // ������
    bool rDown;         // �޸��� Ű ���� ���
    float rotationSpeed = 10f;

    // ����Ű �Է�
    bool fDown;
    float fireDelay;
    bool isFireReady = true;
    bool isAttacking = false;
    bool isWalingOrRunning = false;

    Vector3 moveVec;

    Animator animator;

    Weapon equipWeapon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        equipWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        width = Input.GetAxisRaw("Horizontal");
        length = Input.GetAxisRaw("Vertical");
        rDown = Input.GetButton("Run");
        fDown = Input.GetMouseButtonDown(0);

        // ī�޶� �ٶ󺸴� ������ �������� �̵�
        Vector3 camerForward = Camera.main.transform.forward;
        camerForward.y = 0;
        moveVec = camerForward.normalized * length + Camera.main.transform.right.normalized * width;

        moveVec.Normalize();


        if (!isAttacking)
        {
            if (rDown)
                transform.position += moveVec * Speed * 2 * Time.deltaTime;
            else
                transform.position += moveVec * Speed * Time.deltaTime;

            animator.SetBool("isWalk", moveVec != Vector3.zero);
            animator.SetBool("isRun", rDown);

            if (moveVec != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveVec, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
            }
        }

        isWalingOrRunning = moveVec != Vector3.zero;

        // ����
        Attack();

        if (isFireReady && !isWalingOrRunning)
            moveVec = Vector3.zero;
    }


    void Attack()
    {
        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

        if (fDown && isFireReady)
            StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        if (!isAttacking && !isWalingOrRunning)
        {
            isAttacking = true;
            equipWeapon.Use();
            animator.SetBool("doSwing", true);
            fireDelay = 0;
            yield return new WaitForSeconds(0.7f);
            animator.SetBool("doSwing", false);
            isAttacking = false;
        }
    }


        
}
