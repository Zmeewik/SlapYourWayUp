using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSctipt : MonoBehaviour
{

    private float chargeTimer = 0f;
    private float chargeTime = 0.2f;

    [SerializeField] private GameObject movableObject;
    [SerializeField] private GameObject rotatableObject;
    private IMovable player;
    private IRotatable cameraObject;
    [SerializeField] private Punch punchScr;


    void Start()
    {
        //Getting IMovable ref
        var scr = movableObject.GetComponent<IMovable>();
        if(scr != null)
            player = scr;
        
        //Getting IRotatable ref'
        var scrRot = rotatableObject.GetComponent<IRotatable>();
        if(scrRot != null)
            cameraObject = scrRot;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Handle movement
        //Camera movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if(cameraObject != null)
            cameraObject.DeltaRotation(new Vector2(mouseX, mouseY));

        //Movememnt
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        if(player != null)
            player.OnMove(new Vector2(moveX, moveZ).normalized);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(player != null)
                player.OnJump();
        }

        //Handle hit
        //Retention of mouse click
        //Start LMC
        if (Input.GetMouseButton(0))
        {
            chargeTimer += Time.deltaTime;
            if(punchScr != null)
                punchScr.PunchHandle(chargeTimer, false);
        }
        //End LMC
        if (Input.GetMouseButtonUp(0)) // Отпускание ЛКМ
        {
            if(chargeTimer < chargeTime)
            {
                //Weak hit
                chargeTimer = 0;
                if(punchScr != null)
                    punchScr.PunchHandle(chargeTimer, true);
            }
            else
            {
                //Strong hit
                chargeTimer = 0;
                if(punchScr != null)
                    punchScr.PunchHandle(chargeTimer, true);
            }
        }


        //Handle esc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Pause
        }
    }
}
