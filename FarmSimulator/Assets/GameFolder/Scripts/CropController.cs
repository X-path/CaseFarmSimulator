
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CropController : MonoBehaviour
{
    [SerializeField] List<GameObject> cropChilds = new List<GameObject>();
    [SerializeField] private float growthInterval = 5f; // Bitkiler kaç saniyede bir çýkacak?
    private float moveEffectDuration = 1f; // Animasyon süresi
    private float moveOffset = 0.3f; // Aþaðýdan geliþ mesafesi

    private int currentIndex = 0;
    bool isGrowth = false;

    [SerializeField] GameObject checkIcon;
    [SerializeField] GameObject harvestParticle;
    public IEnumerator GrowCrops()
    {
        while (currentIndex < cropChilds.Count)
        {
           
            if (this == null || this.gameObject == null || !this.enabled)
            {
                yield break; 
            }
            GrowNextCrop();
            yield return new WaitForSeconds(growthInterval);
        }

        isGrowth = true;
        checkIcon.SetActive(true);
        Debug.Log(isGrowth);
    }

    void GrowNextCrop()
    {
        if (currentIndex > 0 && cropChilds[currentIndex - 1] != null)
        {
            cropChilds[currentIndex - 1].SetActive(false);
        }

        if (currentIndex >= cropChilds.Count || cropChilds[currentIndex] == null)
        {
           
            return;
        }

        GameObject crop = cropChilds[currentIndex];
        crop.SetActive(true);

       
        Vector3 originalPos = crop.transform.localPosition;
        crop.transform.localPosition = new Vector3(originalPos.x, originalPos.y - moveOffset, originalPos.z);

     
        crop.transform.DOLocalMoveY(originalPos.y, moveEffectDuration)
            .SetEase(Ease.Linear);


        currentIndex++;
        
    }

    private void OnMouseDown()
    {
        if (isGrowth)
        {
            harvestParticle.SetActive(true);
            isGrowth = false;
            currentIndex = 0;
            cropChilds[^1].SetActive(false);
            checkIcon.SetActive(false);
            StartCoroutine(GrowCrops());

            FirebaseManager.Instance.ScoreIncrease(+1);
        }
    }

 


}
