using UnityEngine;

public class PogPixels3DCamera : MonoBehaviour
{
    public bool shouldRenderToScreen = false;

    internal PogPixels3DRenderQuad targetQuad;

    void Start()
    {
        // Get the main camera.
        var mainCamera = Camera.main.GetComponent<PogPixels3DMainCamera>();

        // Should this camera be rendered to the screen?
        if (shouldRenderToScreen)
        {
            // Set this camera's target quad to the main camera's target quad.
            targetQuad = mainCamera.renderQuad;
        }
    }

    void Update()
    {
        // Should this camera write its output to a render quad?
        if (targetQuad != null)
        {
            var renderTexture = targetQuad.GetRenderTexture();

            var camera = GetComponent<Camera>();

            if (camera.targetTexture != renderTexture)
            {
                camera.targetTexture = renderTexture;
            }
        }
    }
}
