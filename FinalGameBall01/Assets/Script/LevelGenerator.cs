using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private float platformHeight;
    [SerializeField] private float angleStep;
    [SerializeField] private int platformAmount;
    [SerializeField] private Material goodMaterial;
    [SerializeField] private Material badMaterial;
    [SerializeField] private float rotationSpeed;

    private int objectsDestroyed = 0; 

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    [ContextMenu("GenerateLevel")]
    public void GenerateLevel()
    {
        bool hasBadPlatform = false;

        for (int i = 0; i < platformAmount; i++)
        {
            var newObj = Instantiate(platform, Vector3.up * -platformHeight * i, Quaternion.Euler(0, angleStep * i, 0), transform);

            int childCount = newObj.transform.childCount;
            for (int j = childCount - 1; j >= 0; j--)
            {
                var child = newObj.transform.GetChild(j).gameObject;
                child.tag = "good";
                child.GetComponent<Renderer>().material = goodMaterial;
            }

            if (Random.Range(0, 100) < 15)
            {
                hasBadPlatform = true;

                int randChild = Random.Range(0, childCount);
                for (int j = childCount - 1; j >= 0; j--)
                {
                    if (j == randChild)
                    {
                        continue;
                    }
                    var child = newObj.transform.GetChild(j).gameObject;
                    child.tag = "bad";
                    child.GetComponent<Renderer>().material = badMaterial;
                }
            }
        }

        if (hasBadPlatform)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    [ContextMenu("Clean")]
    public void Clean()
    {
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    
    public void ObjectDestroyed()
    {
        objectsDestroyed++;
        if (objectsDestroyed >= platformAmount) 
        {
            SceneManager.LoadScene("Winner"); 
        }
    }
}




