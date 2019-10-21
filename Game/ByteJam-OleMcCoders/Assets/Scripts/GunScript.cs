
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;


    public Camera fpscam;
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
   }    
    public void Shoot()
    {
        RaycastHit hit;
       if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
           if(target != null)
            {
                target.TakeDamage(damage);
            }


        }
    }
}
