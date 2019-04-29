
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGamle : MonoBehaviour
{

    public float zForce = 0;
    private ColisionOffLevel colisionOffLevel;
    //Slider variable

    public Slider aim;
    public Image aim_Arrow;

    public Rigidbody rbBall;
    private bool velocityHigh;
    private bool shootBool;
    

    /// <summary>
    /// Add force during key holddown to charge a shot before firing.
    /// </summary>

    //Minimum and Maximum force. Change shootForce both in script and inspector, if change is needed
    // public float minShootForce = zForce;



    public float maxShootForce = 1000f;






    // Time is set to 3/4 of a second to get from zero to full power
    /*  public float maxChargeTime = 0.75f;




      // Input buttons are string values
      private string shoot;

      //How much force do we have?
      private float currentForce;

      //calculate how fast we charge
      private float chargeSpeed;

      //Fired yes or no?
      private bool shot;


      private void OnEnable()
      {
          currentForce = minShootForce;
          aim.value = minShootForce;
      }

  */
    // Start is called before the first frame update
    void Start()
    {
        
        aim.value = 0;
        velocityHigh = false;
        shootBool = false;
        colisionOffLevel = GameObject.Find("Ball").GetComponent<ColisionOffLevel>();

        //       shoot = "Fire"; //Check project settings and input to see the fire1 button

        //Calculate chargespeed
        //       chargeSpeed = (maxShootForce - minShootForce) / maxChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(rbBall.velocity.x < -0.5f)
        {
            velocityHigh = true;
        }
        if (rbBall.velocity.x > -0.5f && velocityHigh && shootBool)
        {
            shootBool = false;
            colisionOffLevel.resetGame();
        }
        //Every time we need to fire, we set the default values of the slider as well
        /*       aim.value = minShootForce;


               if (currentForce >= maxShootForce && !shot)
               {

                   // at max charge, but not finished
                   currentForce = maxShootForce;
                   Fire1 ();
               }
               else if (Input.GetButtonDown(shoot)){

                   //When the button is first pressed...
                   shot = false;
                   currentForce = minShootForce;
               }
               else if (Input.GetButton(shoot) && !shot)
               {

                   //Are we holding the button?
                   currentForce += chargeSpeed + Time.deltaTime;
                   aim.value = currentForce;
               }
               else if (Input.GetButtonUp(shoot) && !shot)
               {

                   //Released the button but have not yet fired
                   Fire1();

               }
       */


        //Increases z force
        if (Input.GetKey("z") && zForce <= maxShootForce)
        {

            zForce += 5;
            //Slider force react
            aim.value = zForce;



        }




        // Add more movement features by adding rotation

        //Rotate left
        if (Input.GetKey("a"))
        {
            // rotate 1 degree left
            transform.Rotate(0, -1, 0);


        }
        if (Input.GetButton("Fire1"))
        {
            aim_Arrow.enabled = true;
            zForce += 5;
            //Slider force react
            aim.value = zForce;
            


        }


        if (Input.GetButtonUp("Fire1"))
        {


            //Ball reacts to click by moving in an X Y Z related to the ball.
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);

            //Enable Arrow when standing still
            aim_Arrow.enabled = false;

        }

        if (Input.GetKey("left"))
        {

            // rotate 1 degree left
            transform.Rotate(0, -1, 0);

        }
        //Joystick
        if (Input.GetButton("HorizontalLeft"))
        {

            // rotate 1 degree left
            transform.Rotate(0, -1, 0);


        }
        //Joystick
        if (Input.GetButton("HorizontalRight"))
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

    // activated when left mouse button is clicked on the ball
    void OnMouseDown()
    {
        shootBool = true;
        //Ball reacts to click by moving in an X Y Z related to the ball.
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);

        //Enable Arrow when standing still
        aim_Arrow.enabled = false;
    }

    /*   private void Fire1()
       {
           //LAUNCH!!!
           shot = true;
           {
               //Ball reacts to click by moving in an X Y Z related to the ball.
               GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);

               //Enable Arrow when standing still
               aim_Arrow.enabled = false;
           }
       }
   */
}

