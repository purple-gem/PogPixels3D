using UnityEngine;

public class PogPixels3DMainCamera : MonoBehaviour
{
    public int width = 320;
    public int height = 180;
    public PogPixels3DRenderQuad renderQuadPrefab;

    internal PogPixels3DRenderQuad renderQuad;

    // Start is called before the first frame update
    void Start()
    {
        // Create a new RenderQuad
        renderQuad = Instantiate(renderQuadPrefab, transform);

        renderQuad.name = "PogPixels3DRenderQuad";
    }

    // Update is called once per frame
    void Update()
    {
        // Set the render quad's dimensions to camera's desired resolution.
        renderQuad.width = width;
        renderQuad.height = height;
    }
}
