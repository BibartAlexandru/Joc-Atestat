using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerX : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] float fastness;
    [SerializeField] Vector2 neutralPosOffset;
    [SerializeField] float minXValue;
    [SerializeField] float maxXValue;
    private Vector2 upPosOffset;
    private Vector2 downPosOffset;
    private Camera thisCamera;
    public Player playerScript;

    bool isPlayerFacingRight;

    private void Awake()
    {
     
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                upPosOffset = neutralPosOffset;
                downPosOffset = neutralPosOffset;
                upPosOffset.y += 1;
                downPosOffset.y -= 8;
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            }
        }
    }

    private void LateUpdate()
    {
        if (player != null && playerScript != null)   
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = player.transform.position;
            if (endPos.x < minXValue)
                endPos.x = minXValue;
            if (endPos.x > maxXValue)
                endPos.x = maxXValue;
            endPos.z = startPos.z;//z ul ramane ala al camerei
            if (playerScript.core.Movement.facingDirection == 1)
                isPlayerFacingRight = true;
            else
                isPlayerFacingRight = false;
            if (isPlayerFacingRight)  //Daca se uita la dr pozitia la care trebuie sa ajunga camera o sa fie mai la dreapta
                endPos.x += neutralPosOffset.x;              //cu posOffset pixeli sau unitati sau ce is alea
            else
                endPos.x += -neutralPosOffset.x;
            endPos.y = startPos.y;
            transform.position = Vector3.Lerp(startPos, endPos, fastness * Time.deltaTime); //In momentul asta y de inceput e acelasi adica se misca doar pe x  
        }
    }
}
