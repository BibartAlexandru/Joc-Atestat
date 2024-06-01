using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerY : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] float fastness;
    [SerializeField] float minYValue;
    [SerializeField] float maxYValue;
    [SerializeField] Vector2 neutralPosOffset;
    private Vector2 upPosOffset;
    private Vector2 downPosOffset;
    private Camera thisCamera;
    private bool facingUp;
    private bool facingDown;
    private bool playerAnyControlsFacingDown;
    private bool playerAnyControlsFacingUp;
    private bool playerAnyControlsIsFalling;
    private bool isHoldingButtonDown;
    private bool isHoldingButtonUp;
    private float timeHeldButton;
    public bool edgeScrolling;
    public Player playerScript;
    public float fallingYFastness;
    private float currentFallingYFastness;
    private bool once = false;


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
                upPosOffset.y += 2f;
                downPosOffset.y -= 2f;
                thisCamera = GetComponent<Camera>();
                currentFallingYFastness = fallingYFastness;
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
            endPos.z = startPos.z;//z ul ramane ala al camerei
            endPos.x = startPos.x;
            facingDown = false;
            facingUp = false;
            if (playerScript.core.Movement.currentVelocity.y >= 0f)
                playerAnyControlsIsFalling = false;
            else
                playerAnyControlsIsFalling = true;
            //Debug.Log(Input.mousePosition.y.ToString());
            /*
            if (playerScript.inputHandler.rawMovementInput.y > 0.5f)
            {
                playerAnyControlsFacingDown = false;
                playerAnyControlsFacingUp = true;
            }
            else if(playerScript.inputHandler.rawMovementInput.y < -0.5f)
            {
                playerAnyControlsFacingDown = true;
                playerAnyControlsFacingUp = false;
            }
      
            if (edgeScrolling == true)
            {
                if (Input.mousePosition.y > 720f)
                {
                    endPos.y = player.transform.position.y + upPosOffset.y;
                    facingUp = true;
                    //Debug.Log("Sus");
                }
                else if (Input.mousePosition.y < 360f)
                {
                    endPos.y = player.transform.position.y + downPosOffset.y;
                    facingDown = true;
                    //Debug.Log("Jos");
                }
                else
                {
                    //Debug.Log("Neutral");
                    endPos.y = player.transform.position.y + neutralPosOffset.y;
                }
            }

            if (playerAnyControlsFacingDown)
            {
                if (isHoldingButtonDown == true)
                {
                    if (timeHeldButton >= 1f)
                    {
                        endPos.y = player.transform.position.y + downPosOffset.y - 2f;
                        facingDown = true;
                    }
                    timeHeldButton += Time.deltaTime;
                }
                else
                {
                    isHoldingButtonDown = true;
                    timeHeldButton = 0;
                }
            }
            else
                isHoldingButtonDown = false;

            if (playerAnyControlsFacingUp)
            {
                if (isHoldingButtonUp == true)
                {
                    if (timeHeldButton >= 1f)
                    {
                        endPos.y = player.transform.position.y + upPosOffset.y;
                        facingUp = true;
                    }
                    timeHeldButton += Time.deltaTime;
                }
                else
                {
                    isHoldingButtonUp = true;
                    timeHeldButton = 0;
                }
            }
            else
                isHoldingButtonUp = false;

            /*if (playerAnyControlsFacingDown) {
                endPos.y = player.transform.position.y + downPosOffset.y-2f;
                facingDown = true;
            }
            else if (playerAnyControlsFacingUp) {
                endPos.y = player.transform.position.y + upPosOffset.y;
                facingUp = true;
            }
            */
            if (playerAnyControlsIsFalling)//Daca cade playerul 
            {
                //Debug.Log("CADEEE!!!");  //daca cade se uita mai in jos
                endPos.y = player.transform.position.y + neutralPosOffset.y- 2f;//mai rapid
                if (endPos.y < minYValue)
                    endPos.y = minYValue;
                if (endPos.y > maxYValue)
                    endPos.y = maxYValue;
                /*if (playerScript.core.movement.currentVelocity.y < -20f && !once)
                {
                    //currentFallingYFastness += 0.2f;
                    once = true;
                    neutralPosOffset.y -= 5f;
                    currentFallingYFastness += 6f;
                }
                */
                transform.position = Vector3.Lerp(startPos, endPos, (currentFallingYFastness) * Time.deltaTime);
            }
            else {
                /*
                currentFallingYFastness = fallingYFastness;
                neutralPosOffset.y = 0f;
                once = false;
                */
                    if(facingDown == false && facingUp == false)
                    {
                        endPos.y = player.transform.position.y + neutralPosOffset.y; //Se muta yul dupa el in mod normal
                        if (endPos.y < minYValue)
                            endPos.y = minYValue;
                        if (endPos.y > maxYValue)
                            endPos.y = maxYValue;
                    transform.position = Vector3.Lerp(startPos, endPos, fastness * Time.deltaTime);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(startPos, endPos, fastness * Time.deltaTime);
                    }
            }
        }
    }
}
