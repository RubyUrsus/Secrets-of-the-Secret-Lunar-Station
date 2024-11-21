using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHelmetTrigger : MonoBehaviour
{
    GameObject helmetUI;
    [SerializeField]
    GameObject helmetPrefab;
    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    Transform targetPosition;
    bool helmetSpawned;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        helmetUI = GameObject.FindGameObjectWithTag("HelmetUI");
        helmetSpawned = false;
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject && helmetSpawned == false)
        {
            SoundManager.Instance.PlayHelmetSound();
            inventory.SethelmetBool();
            GameObject go = Instantiate(helmetPrefab, other.transform.position + Vector3.up * 2, transform.rotation);
            StartCoroutine(MoveToPosition(go, targetPosition.position));
            helmetSpawned = true;
        }
        Destroy(gameObject, 10f);
    }

    IEnumerator MoveToPosition(GameObject obj, Vector3 targetPos)
    {
        while (Vector3.Distance(obj.transform.position, targetPos) > 0.01f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Varmista, että objekti on täsmälleen kohdesijainnissa
        obj.transform.position = targetPos;
    }
}
