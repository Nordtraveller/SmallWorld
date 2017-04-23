using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    //public static int numberOfUnits = 0;
    public int hitPoints = 5;
    Animator anim;
    public bool selected = false;
    private bool clickSelect = false;
    public float moveSpeed;
    public float rotationSpeed = 0.001f;
    public Vector2 destination;
    public double maxPositionAndDestinationOffset;
    public double rotationToleration = 0.01;
    public bool hasResource = false;
    public FoodScript foodOnBack = null;
    private int resources = 0;

    [SerializeField]
    private SpriteRenderer dziecko;

    private bool active = false; // ant is moving OR just selected
    private Vector2 direction;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible && Input.GetMouseButton(0))
        {
            if(!clickSelect)
            {   
                Vector2 camPosition = Camera.main.WorldToScreenPoint(transform.position);
                camPosition.y = CameraScript.InvertY(camPosition.y);
                selected = (CameraScript.selection.Contains(camPosition) && gameObject.tag == "Black");
            }
        }

        if (this.tag == "Black")
        {
            if (selected)
            {
                dziecko.enabled = true;
            }
            else
            {
                dziecko.enabled = false;
            }
        }

            if (Input.GetMouseButtonUp(1) && selected)
            {
                destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                active = true;
            }

            ControlGameObjectMovement();
        }

    private void ControlGameObjectMovement()
    {

        if (active)
        {
            direction = (destination - (Vector2)(gameObject.transform.position)).normalized;

            if ((destination - (Vector2)(gameObject.transform.position)).magnitude < maxPositionAndDestinationOffset)
                active = false;

            if (active) gameObject.GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
            else gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle + 90), rotationSpeed * Time.deltaTime);
            anim.SetBool("Idle", false);
            anim.SetBool("Move", true);       
        }
        else
        {
            anim.SetBool("Move", false);
            anim.SetBool("Idle", true);
        }
    }

    public void DecreaseHP(int dmg)
    {
        hitPoints -= dmg;
        Debug.Log("Damage Applied");
        if (hitPoints <= 0)
          Destroy(this.gameObject);      
    }

    public void AddResources(int value)
    {
        resources += value;
    }

    public int TakeResources()
    {
        int r = resources;
        resources = 0;
        hasResource = false;
        Destroy(foodOnBack.gameObject);
        foodOnBack = null; 
        return r;
    }

    private void OnMouseDown()
    {
        if(gameObject.tag == "Black")
        {
            clickSelect = true;
            selected = true;
        }
    }

    private void OnMouseUp()
    {
        if(clickSelect)
        {
            selected = true;
        }
        clickSelect = false;
    } 

    public void GoToPoint(Vector2 destination)
    {
        this.destination = destination;
        active = true;
    }

}
