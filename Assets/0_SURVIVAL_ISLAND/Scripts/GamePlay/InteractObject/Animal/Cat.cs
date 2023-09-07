using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Cat : Animal
{
    [Header("Cat")]
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private float  moveSpeed, deltaCheckAttack;
    
    [SerializeField] float moveRadius ; // Maximum distance from the origin position
    [SerializeField] float moveInterval = 5f; // Time interval for random movement
    [SerializeField] float rotationSpeed = 2f; // Speed at which the animal rotates

    private Vector3 originPosition;
    private float timeSinceLastMove;

    private void Start()
    {
        m_animator.Play("Cat_idle");
        originPosition = transform.position;
        timeSinceLastMove = moveInterval; // Initialize to trigger movement immediately
    }

    private void Update()
    {
        timeSinceLastMove += Time.deltaTime;

        if (timeSinceLastMove >= moveInterval)
        {
            // Check if the animal is too far from the origin position
            float distanceFromOrigin = Vector3.Distance(transform.position, originPosition);

            if (distanceFromOrigin > moveRadius)
            {
                // Return to the origin position
                _agent.SetDestination(originPosition);
            }
            else
            {
                // Generate a random direction
                Vector3 randomDirection = Random.insideUnitSphere * moveRadius;

                // Calculate the new destination
                Vector3 newDestination = originPosition + randomDirection;

                // Set the new destination for the NavMeshAgent
                _agent.SetDestination(newDestination);
            }

            // Reset the timer
            timeSinceLastMove = 0f;
        }

        
    }
  


    // tamj ko dung
    // IEnumerator RandomNumber()
    // {
    //     while (true)
    //     {
    //         randomNum = Random.Range(1, 5);
    //         if (randomNum == 1)
    //         {
    //             transform.DORotate(new Vector3(0, 0, 0), 1);
    //         }
    //         else if (randomNum == 2)
    //         {
    //             transform.DORotate(new Vector3(0, 90, 0), 1);
    //         }else if (randomNum == 3)
    //         {
    //             transform.DORotate(new Vector3(0, 180, 0), 1);
    //         }else if (randomNum == 4)
    //         {
    //             transform.DORotate(new Vector3(0, 270, 0), 1);
    //         }
    //         
    //         yield return new WaitForSeconds(10);
    //     }
    // }
    
    private void OnEnable()
    {
        itemsGenerate = new List<Item>();
        Item item1 = new Item(typeItems[0], Random.Range(1, 3), icons[0]);
        // Item item2 = new Item(typeItems[1], Random.Range(1, 3), icons[1]);
        // Item item3 = new Item(typeItems[2], Random.Range(1, 3), icons[2]);
        
        itemsGenerate.Add(item1);
        // itemsGenerate.Add(item2);
        // itemsGenerate.Add(item3);
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            var gController = GameController.instance;
            gController.attackObj = this;
            
            // change center color
            GamePlayUI.instance.centerImg.color = Color.red;
            
            gController.hpBarObj.DisplayBar(remainHp, maxHp);
            Debug.Log("targeted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            var gController = GameController.instance;
            gController.tarGetObj = null;
            gController.hpBarObj.HideBar();
            
            // change center color
            GamePlayUI.instance.centerImg.color = Color.white;
        }
    }
}
