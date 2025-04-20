using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] prefabs;



    private void Update()
    {
        Invoke("spawnerFunction", 2f);
    }


    public void spawnerFunction()
    {
        Instantiate(prefabs[Random.Range(0, 7)]);
    }

}
