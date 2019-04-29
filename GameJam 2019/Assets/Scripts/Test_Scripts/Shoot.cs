
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    public float zForce = 0;
    public float zForceZero;
    private ColisionOffLevel colisionOffLevel;
    //Slider variable

    public Slider aim;
    public Image aim_Arrow;
	public Image aim_PlaceHolder;

    public Rigidbody rbBall;
    private bool velocityHigh;
    private bool shootBool;
    private bool shootBoolBlue;
    private bool shootBoolRed;
    private Transform ball; 

    public float minShootForce = 10f;
    public float maxShootForce = 1000f;

    private PointSystem point; 

    // Start is called before the first frame update
    void Start()
    {
        aim.value = 0;
        velocityHigh = false;
        shootBoolBlue = false;
        shootBoolRed = false;
        colisionOffLevel = GameObject.Find("Ball").GetComponent<ColisionOffLevel>();
        ball = GameObject.Find("Ball").GetComponent<Transform>(); 

        point = GameObject.Find("Game_manager").GetComponent<PointSystem>(); 
    }

    // Update is called once per frame
    void Update()
    {


        if(colisionOffLevel.GetTeamNumber() == 1)
        {
            if (rbBall.velocity.x > 0.05f)
            {
                velocityHigh = true;
            }

            if (rbBall.velocity.x < 0.2f  && velocityHigh && shootBoolBlue)
            {
                velocityHigh = false;
                shootBoolBlue = false;
                zForce = 0; 
                aim_Arrow.enabled = true;
				aim_PlaceHolder.enabled = true;
                aim.value = 0; 
                colisionOffLevel.resetGame();
            }
        } else if(colisionOffLevel.GetTeamNumber() == 0)
        {
            if (rbBall.velocity.x < -0.05f)
            {
                velocityHigh = true;
            }
            if (rbBall.velocity.x > -0.2f && velocityHigh && shootBoolRed)
            {
                velocityHigh = false;
                shootBoolRed = false;
                zForce = 0; 
                aim_Arrow.enabled = true; 
				aim_PlaceHolder.enabled = true;
                aim.value = 0; 
                colisionOffLevel.resetGame();
            }
        }


        if(!point.GetGameOver()) {

            string buttonInput = ""; 
            string buttonAngleLeft = "";
            string buttonAngleRight = "";  
            if(colisionOffLevel.GetTeamNumber() == 0) {
                buttonInput = "Fire1";
                buttonAngleLeft = "HorizontalLeft";
                buttonAngleRight = "HorizontalRight";  
            } else if(colisionOffLevel.GetTeamNumber() == 1) {
                buttonInput = "Fire2"; 
                buttonAngleLeft = "HorizontalLeft2"; 
                buttonAngleRight = "HorizontalRight2"; 
            }

            //Increases z force
            if (Input.GetButton(buttonInput))
            {
                if (zForce < maxShootForce)
                {
                    zForce += 10;
                    //Slider force react
                    aim.value = zForce;            
                } else if(zForce >= maxShootForce)
                {
                    if(!colisionOffLevel.GetBallInMotion()) {
                        colisionOffLevel.SetBallInMotion(); 
                        zForce = maxShootForce;

                        if(colisionOffLevel.GetTeamNumber() == 1)
                        {
                        shootBoolBlue = true;
                        GetComponent<Rigidbody>().AddRelativeForce(zForce, 0, 0);

                        } else if(colisionOffLevel.GetTeamNumber() == 0)
                        {
                            shootBoolRed = true;
                            GetComponent<Rigidbody>().AddRelativeForce(-zForce, 0, 0);
                        }
                        aim_Arrow.enabled = false;
                        aim_PlaceHolder.enabled = false;
                    }
                } else if(zForce < minShootForce) {
                    zForce = minShootForce; 
                }
            }
            // Add more movement features by adding rotation
            //Rotate left
            if (Input.GetKey("a"))
                {
                // rotate 1 degree left
                    transform.Rotate(0, -1, 0);
                }

            if (Input.GetButtonUp(buttonInput)){

                if(!colisionOffLevel.GetBallInMotion()) {
                    colisionOffLevel.SetBallInMotion(); 
                    if(colisionOffLevel.GetTeamNumber() == 1)
                    {
                        shootBoolBlue = true;
                        GetComponent<Rigidbody>().AddRelativeForce(zForce, 0, 0);

                    } else if(colisionOffLevel.GetTeamNumber() == 0)
                    {
                        shootBoolRed = true;
                        GetComponent<Rigidbody>().AddRelativeForce(-zForce, 0, 0);
                    }
                    aim_Arrow.enabled = false;
                    aim_PlaceHolder.enabled = false;
                }
            
            }

            if (Input.GetKey("left"))
            {
                // rotate 1 degree left
                transform.Rotate(0, -1, 0);
            }
            //Joystick
            if (Input.GetButton(buttonAngleLeft)) 
            {
                // rotate 1 degree left
                transform.Rotate(0, -1, 0);
            }
            //Joystick
            if (Input.GetButton(buttonAngleRight))
            {
                // rotate 1 degree right
                transform.Rotate(0, 1, 0);
            }

            if (Input.GetKey("d"))
            {
            // rotate 1 degree right
            transform.Rotate(0, 1, 0);
        }
        }
    }
}