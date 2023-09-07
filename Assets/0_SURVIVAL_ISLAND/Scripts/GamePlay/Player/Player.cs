using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerStat playerStatData;
    [SerializeField]
     GameObject center;
     public Button collectBtn;
    
    
     public TestCam camFollowPlayer;
     
     public float speed;
    [SerializeField]
     FixedJoystick _joyStick;
     [SerializeField]
     Vector3 moveVector, dragOrigin;

     [SerializeField]
     float rotationSpeed = 1.5f;
    
    // public float currentDirection;

    [SerializeField]
    public List<Weapon> weapons;
    public Weapon mainWeapon;
    public List<GameObject> placeObjects;

    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStatData = new PlayerStat(0, 0,100,100, 100,100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void FixedUpdate()
    {
        // Move();
    }

    private void Move()
    {
        moveVector = Vector3.zero;
        float x = _joyStick.Horizontal;
        float z = _joyStick.Vertical;

        // currentDirection = transform.eulerAngles.y;

        if (x == 0 && z == 0)
        {
            //Debug.Log("Stand still");
        }
        else {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();

            Vector3 cameraRight = Camera.main.transform.right;
            cameraRight.y = 0f;
            cameraRight.Normalize();
            
            Vector3 movement = (cameraForward * z + cameraRight * x).normalized;

            // Apply movement to the player
            transform.position += movement * speed * Time.fixedDeltaTime;
            
            
        }
        
        
        
        
    }


    public void ChooseWeapon(int id)
    {
        mainWeapon?.gameObject.SetActive(false);
        weapons[id].gameObject.SetActive(true);
        mainWeapon = weapons[id];
    }

    public void PlaceObject()
    {
        Instantiate(placeObjects[0], transform.position + new Vector3(1.5f,1,0), Quaternion.identity);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            transform.DOMove(transform.position + Vector3.up*4, 0.2f);
        }
    }
}
