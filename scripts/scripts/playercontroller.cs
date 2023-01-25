using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    public CinemachineVirtualCamera aimcamera;
    public float normalsenstivity;
    public float aimsenstivity;
    public  LayerMask aimcollidermask = new LayerMask();
    //   [SerializeField] private Transform debugtransform;
    public GameObject shootpar;
    Animator anim;


    ThirdPersonController thirdPersonController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }



    private void Update()
    {
        Vector3 mouseworldposition =  Vector3.zero;
        Vector2 screencentrepoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screencentrepoint);
        Transform hittransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycasthit, 999f, aimcollidermask))
        {
        //    debugtransform.position = raycasthit.point;
            mouseworldposition = raycasthit.point;
            hittransform = raycasthit.transform;
        }




        if (gameObject.GetComponent<StarterAssetsInputs>().aim)
        {  
            aimcamera.gameObject.SetActive(true);
            thirdPersonController.setsensivity(aimsenstivity);
            Vector3 worldaimtarget = mouseworldposition;
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            worldaimtarget.y = transform.position.y;
            Vector3 aimdirection = (worldaimtarget - transform.position).normalized;
            thirdPersonController.isRotating = false;
            transform.forward = Vector3.Lerp(transform.forward, aimdirection, Time.deltaTime*20f); 
        }
        else
        {
            aimcamera.gameObject.SetActive(false);
            thirdPersonController.setsensivity(normalsenstivity);
            thirdPersonController.isRotating = true;
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (gameObject.GetComponent<StarterAssetsInputs>().shoot)
        {
            shootpar.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            shootpar.transform.GetChild(1).GetComponent<ParticleSystem>().Play();

            if (hittransform != null)
            {
                if (hittransform.tag == "Zombie")
                {
                    Destroy(hittransform.gameObject);
                }
                else
                {
                    print(hittransform.name);
                }
            }
            

         //   gameObject.GetComponent<StarterAssetsInputs>().shoot= false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<StarterAssetsInputs>().shoot = false;
           
        }
       

    }





    }
   
   


