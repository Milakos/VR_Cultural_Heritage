using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronHandlerAfterAnimation : MonoBehaviour
{
    [SerializeField] private float timeElapsed;
    [SerializeField] private GameObject SmeltedIngot;
    public MeshRenderer ren;
    private void Awake()
    {
        SmeltedIngot.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public IEnumerator WaitTimeUntilDestory() 
    {
        SmeltedIngot.SetActive(true);
        yield return new WaitForSeconds(timeElapsed);
        ren.enabled = false;
        Destroy(this.gameObject);
    }
}
