using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject ultBulletPrefab;

    [SerializeField] float fireCd;
    private float fireTimer;
    
    [SerializeField] Image chargeBar;
    [SerializeField] float chargeAmount;
    private float currentCharge =0;

    void Start()
    {
        fireTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateChargeBar();
        fireTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0)){
            if (fireTimer <= 0){
                if (currentCharge < chargeAmount) { currentCharge++; }
                Shoot();
                fireTimer = fireCd;
            }
        }
        if (Input.GetMouseButtonUp(0)&&(currentCharge>=chargeAmount)){
            ShootUlt();
            currentCharge = 0;
        }
    }
    private void updateChargeBar(){
        if (currentCharge < chargeAmount) {chargeBar.color= new Color32(33, 128, 231, 255);}
        else { chargeBar.color = new Color32(247, 166, 2, 255); }
        chargeBar.fillAmount = (currentCharge / chargeAmount ) + 0.08f;
    }
    private void Shoot(){
        GameObject bullet=Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
       // bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,10),ForceMode.Impulse);
    }
    private void ShootUlt()
    {
        GameObject bullet = Instantiate(ultBulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 30), ForceMode.Impulse);
    }
}
