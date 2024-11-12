using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door01Controller : MonoBehaviour    /* , IInteractable*/
{

    [SerializeField]
    GameObject doorOne;
    [SerializeField]
    GameObject doorTwo;

    public float openPositionX = 0.5f;  // X-sijainti, johon vetolaatikko avautuu
    public float closedPositionX = 0f;  // Oletussijainti, kun vetolaatikko on kiinni
    public float smoothTime = 0.2f;   // Aika, jonka vetolaatikon liike kest‰‰
    [SerializeField]
    private bool open = false;      // Tarkistus, onko vetolaatikko auki vai kiinni


    private void Start()
    {
        if (open)
        {
            doorOne.transform.localPosition = new Vector3(-openPositionX, doorOne.transform.localPosition.y, doorOne.transform.localPosition.y);
            doorTwo.transform.localPosition = new Vector3(openPositionX, doorOne.transform.localPosition.y, doorOne.transform.localPosition.y);
        }
        else
        {
            doorOne.transform.localPosition = new Vector3(-closedPositionX, doorOne.transform.localPosition.y, doorOne.transform.localPosition.y);
            doorTwo.transform.localPosition = new Vector3(closedPositionX, doorOne.transform.localPosition.y, doorOne.transform.localPosition.y);
        }
    }



    // Valmius interact-systeemille
    public void Interact()
    {
        if (open == false)
        {
            StartCoroutine(OpenDoubleDoor(openPositionX));
            //FindObjectOfType<AudioManager>().Play("OpenDrawer"); // Valmius ‰‰niin
            open = true;
        }
        else
        {
            StartCoroutine(OpenDoubleDoor(closedPositionX));
            //FindObjectOfType<AudioManager>().Play("CloseDrawer"); // Valmius ‰‰niin
            open = false;
        }
    }

    private IEnumerator OpenDoubleDoor(float targetPositionX)
    {
        // Hae vetolaatikon nykyinen sijainti
        Vector3 currentPosDoorOne = doorOne.transform.localPosition;
        Vector3 currentPosDoorTwo = doorTwo.transform.localPosition;
        // Luo uusi kohdesijainti vain X-akselilla
        Vector3 targetPosDoorOne = new Vector3(-targetPositionX, currentPosDoorOne.y, currentPosDoorOne.z);
        Vector3 targetPosDoorTwo = new Vector3(targetPositionX, currentPosDoorOne.y, currentPosDoorTwo.z);


        float elapsedTime = 0f;

        // Suorita liike ajan kuluessa smoothisti
        while (elapsedTime < smoothTime)
        {
            doorOne.transform.localPosition = Vector3.Lerp(currentPosDoorOne, targetPosDoorOne, elapsedTime / smoothTime);
            doorTwo.transform.localPosition = Vector3.Lerp(currentPosDoorTwo, targetPosDoorTwo, elapsedTime / smoothTime);
            elapsedTime += Time.deltaTime;
            yield return null; // Odottaa seuraavaa framea
        }

        // Varmistetaan, ett‰ ovi p‰‰tyy t‰sm‰lleen haluttuun sijaintiin
        doorOne.transform.localPosition = targetPosDoorOne;
        doorTwo.transform.localPosition = targetPosDoorTwo;

    }
}
