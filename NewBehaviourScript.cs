using UnityEngine;

public class SimpleScene : MonoBehaviour
{
    public int objectCount = 10;
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float groundSize = 20f;
    public float cameraAngle = 45f;
    public Vector3 cameraPosition = new Vector3(0f, 5f, -10f);

    // Start is called before the first frame update
    void Start()
    {
        
        Camera.main.backgroundColor = Color.cyan;

       
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.rotation = Quaternion.Euler(cameraAngle, 0f, 0f);

       
        GameObject ground = CreateGround();
        SetColor(ground, Color.red);

        
        float minX = -groundSize / 10;
        float maxX = groundSize / 10;
        float minY = minSize / 10;
        float maxY = groundSize / 10;
        float minZ = -groundSize / 10;
        float maxZ = groundSize / 10;

        
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

            if (Random.value < 0.5f)
            {
                // Create a green square
                GameObject square = CreateSquare(position, Random.Range(minSize, maxSize));
                SetColor(square, Color.green);
            }
            else
            {
                // Create a green circle
                GameObject circle = CreateCircle(position, Random.Range(minSize, maxSize));
                SetColor(circle, Color.green);
            }
        }

        
        CreateCubePyramid(new Vector3(0f, 1f, 0f),2f, 3);

       
        transform.Rotate(Vector3.up * Time.deltaTime * 10);
    }

    GameObject CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.position = new Vector3(0, 0, 0);
        ground.transform.localScale = new Vector3(groundSize, 1f, groundSize);
        return ground;
    }

    GameObject CreateSquare(Vector3 position, float size)
    {
        GameObject square = GameObject.CreatePrimitive(PrimitiveType.Cube);
        square.transform.position = position;
        square.transform.localScale = new Vector3(size, size, size);
        return square;
    }

    GameObject CreateCircle(Vector3 position, float radius)
    {
        GameObject circle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle.transform.position = position;
        circle.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
        return circle;
    }

    void SetColor(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    void CreateCubePyramid(Vector3 basePosition, float cubeSize, int pyramidHeight)
    {
        for (int i = 0; i < pyramidHeight; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Vector3 position = basePosition + new Vector3(j * cubeSize, i * cubeSize, 0f);
                CreateSquare(position, cubeSize);
            }
        }
    }

}
