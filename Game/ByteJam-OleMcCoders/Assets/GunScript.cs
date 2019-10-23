
using UnityEngine;
using System.Collections; 
public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float firerate = 15f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false; 

    public Camera fpscam;

    private float nextTimeToFire = 0f;

    void Start ()
    {
        currentAmmo = maxAmmo; 
    }
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo == 0)
        {
            StartCoroutine(Reload());
            return;
        }

       if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / firerate;
            Shoot();
        }
   }    

    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false; 
    }
    void Shoot()
    {
        currentAmmo--;
        Debug.Log(currentAmmo);
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
