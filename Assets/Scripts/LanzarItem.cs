using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarItem : MonoBehaviour
{
    [SerializeField] private List<GameObject> _personasPublico;
    [SerializeField] private GameObject[] _itemsPrefabs = new GameObject[3];
    public void PopulatePublic(List<GameObject> list)
    {
        _personasPublico = list;
        StartCoroutine(Lanzamiento());
    }

    IEnumerator Lanzamiento()
    {
        yield return new WaitForSeconds(4);
        int randomIndex = Random.Range(0, _personasPublico.Count);
        Instantiate(_itemsPrefabs[Random.Range(0, 3)], _personasPublico[randomIndex].transform.position + Vector3.up, Quaternion.identity);
        StartCoroutine(Lanzamiento());
    }
}