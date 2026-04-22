using UnityEngine;

public class Ball : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>(); 
        if (lineRenderer != null)
        {
            lineRenderer.enabled = false; 
            lineRenderer.widthMultiplier = .2f; 

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude < .05f)
        {
            GameManager.Instance.ball_moving = false;
        }
        
    }

    private void OnMouseDown()
    {
        if (lineRenderer != null)
        {
            lineRenderer.enabled = true; 
            lineRenderer.SetPosition(0, transform.position); 
        }
    }

    private void OnMouseDrag() 
    {
        if (lineRenderer != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0.0f)); 
        }

    }

    private void OnMouseUp() 
    {
        if (lineRenderer.enabled) 
        {
           
            lineRenderer.enabled = false;
            GameManager.Instance.ball_moving = true ;
            float length = Vector3.Distance(lineRenderer.GetPosition(1), lineRenderer.GetPosition(0));
            rb.AddForce(-((lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).normalized) * length, ForceMode2D.Impulse);
            GameManager.Instance.ChangeShots();


        }
    }

}
