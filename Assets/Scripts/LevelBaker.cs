using UnityEngine.AI;
using UnityEngine;

public class LevelBaker : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;


	// Use this for initialization
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            UpdateNavMesh();
        }
	}

    //Should be called before the wave starts but after the timer is done
    private void UpdateNavMesh()
    {
        surface.BuildNavMesh();
    }

    private void OnEnable()
    {
        //Sub to the correct Event
    }
    private void OnDisable()
    {
        //Unsub to the correct Event
    }
}
