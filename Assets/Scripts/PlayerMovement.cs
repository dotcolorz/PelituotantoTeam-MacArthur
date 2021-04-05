using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent playerAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        PrintInstruction();
    }

    void Update()
    {
        //jos hiiren vasenta klikkiÅEpainetaan ja hiiri ei ole pelinsis‰isen gameobjectin p‰‰llÅEkutsutaan "GetInteraction"
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            GetInteraction();
        
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.destination = interactionInfo.point;
                playerAgent.stoppingDistance = 0;
            }
        }
    }
   

    void PrintInstruction()
    {
        Debug.Log("Welcome to Team MacArthur's game.");  
    }

    
    

   

}