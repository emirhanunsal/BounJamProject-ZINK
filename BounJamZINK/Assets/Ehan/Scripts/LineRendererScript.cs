using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class LineRendererScript : MonoBehaviour
{
    private LineRenderer lr;
    private EdgeCollider2D edgeCollider;
    public int skor = 0;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private InteractPillar _interactPillar;
    [SerializeField] public List<Transform> points = new List<Transform>();
    [SerializeField] private UsedRopeCalculations usedRopeCalculations;

    [SerializeField] private UI ui;
    [SerializeField] private GameObject ropePerk;
    [SerializeField] private GameObject healthPerk;
     
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        edgeCollider = this.GetComponent<EdgeCollider2D>();

        


    }
    
    public void AddPointToLine(Transform transform)
    {
        if (usedRopeCalculations.remainingRope > 0)
        {
            AddElementIfNotLastOrSecondLast(transform);
        }
        else
        {
            Debug.Log("No more rope left");
        }
        
    }

    public void ClearPointsList()
    {
        points.Clear();
    }
    
    
    
    public Material material0; // Varsayılan materyal
    public Material material1; // İlk materyal
    public Material material2; // İkinci materyal
    public float switchInterval = 0.2f; // Materyalin ne kadar sıklıkla değiştirileceği (saniye)
    
    private float timer = 0.0f; // Zamanlayıcı
    private bool useMaterial1 = true; // Hangi materyalin kullanılacağını takip eden bool değişken

    
    void Update()
    {
        lr.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
        SetEdgeCollider(lr);
        Debug.Log(damageEnabled);
        SetOnFire();
        if (changeColors)
        {
            timer += Time.deltaTime;

            if (timer >= switchInterval)
            {
                timer = 0.0f;

                useMaterial1 = !useMaterial1;
                lr.material = useMaterial1 ? material1 : material2;
            }
        }
        else
        {
            lr.material = material0;
        }
    }
    
    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();
 
        for(int point = 0; point<lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
 
        edgeCollider.SetPoints(edges);
    }
    
    public void AddElementIfNotLastOrSecondLast(Transform newElement)
    {
        int count = points.Count;
        
        // Listenin son veya sondan bir önceki elemanını kontrol etme
        if (count > 0)
        {
            Transform lastElement = points[count - 1];

            if (lastElement == newElement)
            {
                //Debug.Log("Yeni eklemek istediğiniz eleman zaten listenin son elemanı.");
                return;
            }
        }

        if (count > 1)
        {
            Transform secondLastElement = points[count - 2];

            if (secondLastElement == newElement)
            {
                //Debug.Log("Yeni eklemek istediğiniz eleman zaten listenin sondan bir önceki elemanı.");
                return;
            }
        }

        // Yeni elemanı listeye ekle
        points.Add(newElement);
        usedRopeCalculations.CalculateNewDistance();
        
        //Debug.Log("Eleman listeye eklendi: " + newElement);
    }

    public void CheckInvalidCompleteLoop()
    {
        Debug.Log("Invalid loop fonk calisti");
        for (int i = 0; i < points.Count; i++)
        {
            Transform currentTransform = points[i];
            for (int j = i + 1; j < points.Count; j++)
            {
                if (currentTransform == points[j])
                {
                    //Debug.Log("Invalid loop bulundu " + currentTransform.name);
                    points.Clear();
                    _interactPillar.RemoveColliders();
                    return; // Tekrar eden eleman bulunduğunda işlemi sonlandır
                }
            }
        }
       // Debug.Log("Listede tekrar eden bir transform bulunamadı.");
    }

    public bool CheckValidLoop()
    {
        if (points.Count >= 3)
        {
            if (points[0] == points[points.Count - 1])
            {
                //Debug.Log("Valid loop var");
                damageEnabled = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }

    public bool damageEnabled = false;
    public bool isOnFire = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Çarpışma başladı: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy") && isOnFire)
        {
            Destroy(collision.gameObject);
            skor = skor + UnityEngine.Random.Range(0, 11);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isOnFire)
        {
           // Debug.Log("IPTE CARPISMA VAR");
           Transform transform = collision.gameObject.transform;
           int chance = UnityEngine.Random.Range(1,5);
           if (chance == 1)
           {
               Instantiate(healthPerk, transform.position, Quaternion.identity);
           }
           if (chance == 2)
           {
               Instantiate(ropePerk, transform.position, Quaternion.identity);
           }
            Destroy(collision.gameObject);
            skor = skor + UnityEngine.Random.Range(0, 11);
        }
    }


    private bool changeColors = false;
    private void SetOnFire()
    {
        if (damageEnabled)
        {
            if (_interactPillar.hit.collider != null && points.Contains(_interactPillar.hit.collider.gameObject.transform))
            {
                //Debug.Log("Damage enabled ve pillara dokunuoluyor");
                if (Input.GetKeyDown(KeyCode.F))

                {
                    changeColors = true;

                {   
                    
>
                    Debug.Log("Damage enabled ve pillara dokunuoluyor ve f basıldı");
                    isOnFire = true;
                    Invoke("ClearPointList", 10f);
                }
            }
        }
        
    }

    
    private void ClearPointList()
    {
        points.Clear();
        damageEnabled = false;
        isOnFire = false;
        changeColors = false;
        _interactPillar.RemoveColliders();
    }
}
    

    

