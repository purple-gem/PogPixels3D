using UnityEngine;

public class PogPixels3DRenderQuad : MonoBehaviour
{
    public int width = 320;
    public int height = 180;
    public int depth = 24;

    public Material material;

    private RenderTexture renderTexture;

    public RenderTexture GetRenderTexture()
    {
        return renderTexture;
    }

    private void SetResolution(int width=320, int height=180, int depth=24)
    {
        this.width = width;
        this.height = height;
        this.depth = depth;

        if (renderTexture == null ||
                width != renderTexture.width ||
                height != renderTexture.height ||
                depth != renderTexture.depth)
        {
            // Create a new render texture and replace the current one with it.
            RegenerateRenderTexture();

            // Refresh the quad's texture.
            RefreshTexture();
        }
    }

    private void RefreshResolution()
    {
        SetResolution(width, height, depth);
    }

    private void RefreshMaterial()
    {
        // Acquire the current mesh renderer.
        var meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer.material != material)
        {
            // Acquire the current mesh renderer.
            meshRenderer = GetComponent<MeshRenderer>();

            // Set the mesh renderer's material to this quad's material.
            meshRenderer.material = material;
        }
    }

    private void RefreshTexture()
    {
        // Update the material's main texture to the current render texture.
        material.mainTexture = renderTexture;

        RefreshMaterial();
    }

    private void RegenerateRenderTexture()
    {
        // Create a new render texture and replace the current one with it.
        renderTexture = new RenderTexture(width, height, depth);

        renderTexture.wrapMode = TextureWrapMode.Clamp;
        renderTexture.filterMode = FilterMode.Point;
    }

    void Start()
    {
        RefreshResolution();
    }

    void Update()
    {
        RefreshResolution();
    }
}
