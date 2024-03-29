using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAttack : MonoBehaviour
{
    private GameObject shadow;
    public GameObject projectile;
    private bool initiateAttack = true;
    public float timeBetweenAttacks;
    // Start is called before the first frame update
    void Start()
    {
        shadow = this.transform.Find("shadow").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }

        if (initiateAttack)
        {
            initiateAttack = false;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        shadow.SetActive(true);
        __staticInfoClass.crystalProjectileDirection = new Vector2(1, 0).normalized;
        GameObject newProjectile1 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        __staticInfoClass.crystalProjectileDirection = new Vector2(1, -1).normalized;
        GameObject newProjectile2 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        __staticInfoClass.crystalProjectileDirection = new Vector2(0, -1).normalized;
        GameObject newProjectile3 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        __staticInfoClass.crystalProjectileDirection = new Vector2(-1, -1).normalized;
        GameObject newProjectile4 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        __staticInfoClass.crystalProjectileDirection = new Vector2(-1, 0).normalized;
        GameObject newProjectile5 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        __staticInfoClass.crystalProjectileDirection = new Vector2(-1, 1).normalized;
        GameObject newProjectile6 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        __staticInfoClass.crystalProjectileDirection = new Vector2(0, 1).normalized;
        GameObject newProjectile7 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        __staticInfoClass.crystalProjectileDirection = new Vector2(1, 1).normalized;
        GameObject newProjectile8 = Instantiate(projectile, this.transform.position, Quaternion.identity);
        shadow.SetActive(false);
        initiateAttack = true;
    }
}
