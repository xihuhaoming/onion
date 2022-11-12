using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayMoveMent : MonoBehaviour
{ 
    public float speed;
    public Vector3 playerInput;
    private float _noInputTime;
    private bool _isMoving;
    

    private Animator _anim;
    public GameObject Enemy;
    
    public Vector3 enemyPositon = new Vector3(-20, 8, 5);
    public Vector3 enemyQuaternion = new Vector3(0, 0, 60);

    public int playerHealth = 100; 
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _anim.Play("IdleLong");
        
        // Instantiate(Enemy, enemyPositon, quaternion.Euler(enemyQuaternion));
    }

    // Update is called once per frame
    void Update()
    {
        //如果按下的是空格键
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
        // 记录每一帧后增加的时间
        if (_noInputTime < 4)
        {
            _noInputTime += Time.deltaTime;
        }
        _anim.SetFloat("noInput", _noInputTime);
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );
        transform.position += playerInput * speed * Time.deltaTime;
        
        //如果noInputTime过大就赋值为0
        
        if (playerInput != Vector3.zero)
        {
            _anim.SetBool("isRunning", true);
            _noInputTime = 0;
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }
    }
}
