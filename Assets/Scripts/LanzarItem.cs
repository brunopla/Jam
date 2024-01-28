using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LanzarItem : MonoBehaviour
{
    [SerializeField] private List<GameObject> _personasPublico;
    [SerializeField] private GameObject[] _itemsPrefabs = new GameObject[3];
    public void PopulatePublic(List<GameObject> list)
    {
        _personasPublico = list;
        //StartCoroutine(Lanzamiento());
    }
    /// <summary>
    /// Hace que el publico lance un item de forma aleatoria
    /// </summary>
    public void Lanzar () => StartCoroutine(Lanzamiento());
    IEnumerator Lanzamiento()
    {
        yield return new WaitForSeconds(4);
        int randomIndex = Random.Range(0, _personasPublico.Count);
        NPC target = _personasPublico[randomIndex].GetComponent<NPC>();
        target.animator.Play("tirar");
        // poner sonido de lanzamiento
        Instantiate(_itemsPrefabs[Random.Range(0, _itemsPrefabs.Count())],target.transform.position + Vector3.up, Quaternion.identity);
    }
}
