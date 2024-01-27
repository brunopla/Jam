using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Publico : MonoBehaviour
    {
        public List<GameObject> personasPublico;
        public List<GameObject> prefabsPersonasPublico;
        public List<BoxCollider> ubicacionesPublico;
        public LanzarItem _lanzarItemScr;
        public void GenerarPublico(int cantidad)
        {
        print("generando publico");
            for (int i = 0; i < cantidad; i++)
            {
            BoxCollider ubicacion = ubicacionesPublico[Random.Range(0, ubicacionesPublico.Count)];
            Vector3 pos = new Vector3(Random.Range(ubicacion.bounds.max.x, ubicacion.bounds.min.x)
                ,0,
                Random.Range(ubicacion.bounds.max.z, ubicacion.bounds.min.z)) ;

               var persona =  Instantiate(prefabsPersonasPublico[Random.Range(0, prefabsPersonasPublico.Count)], pos, Quaternion.LookRotation(Player.instance.transform.position));
                personasPublico.Add(persona);
            }
            if(_lanzarItemScr != null)
            {
                _lanzarItemScr.PopulatePublic(personasPublico);
            }

        }
    }
