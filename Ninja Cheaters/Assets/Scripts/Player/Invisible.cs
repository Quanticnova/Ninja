using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour {

    public float fadeSpeed = 0.1f;
    private float spawnTime;

    public Material BaseMat;
    public Material InvisMat;
    public Renderer rend;
    public float duration = 5;

    [SerializeField]
    private Material[] enemyMaterials;
    public bool collided;

    private ScoreManager TheScoreManager;

    public Color StartColor;
    public Color EndColor;
    public float time;
    bool goingForward;
    bool isCycling;
    Material myMaterial;
    public MeshRenderer MyMesh;

    void Start ()
    {
        BaseMat = GetComponent<Material>();//Changing mat properties
        TheScoreManager = FindObjectOfType<ScoreManager>();

        collided = false;
        MyMesh = GetComponent<MeshRenderer>();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        enemyMaterials = GetComponent<MeshRenderer>().materials;

        rend = GetComponent<Renderer>();
        //rend.material = BaseMat;
    }

    private void Awake()
    {
        goingForward = true;
        isCycling = false;
        myMaterial = GetComponent<Renderer>().material;
    }

    void Update ()
    {
        if (collided == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            SetAlpha((Time.time - spawnTime) * fadeSpeed);      
           
        }

       /* if (!isCycling)
        {
            if (goingForward)
                StartCoroutine(CycleMaterial(StartColor, EndColor, time, myMaterial));
            else
                StartCoroutine(CycleMaterial(EndColor, StartColor, time, myMaterial));
        }*/

    }

    IEnumerator CycleMaterial(Color startColor, Color endColor, float cycleTime, Material mat)
    {
        isCycling = true;
        float currentTime = 0;
        while (currentTime < cycleTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / cycleTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            mat.color = currentColor;
            yield return null;
        }
        isCycling = false;
        goingForward = !goingForward;
        if(!goingForward)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }


    void SetAlpha(float alpha)
    {
        // Change the alpha value of each materials' color
        for (int i = 0; i < enemyMaterials.Length; ++i)
        {
            Color color = enemyMaterials[i].color;
            color.a = Mathf.Clamp(alpha, 0, 1);
            enemyMaterials[i].color = color;
        }
        collided = false;
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer != gameObject.layer)//Check is attacked
        {
            if (col.gameObject.tag == "P1Weapon")
            {
                print(collided);
                collided = true;
                TheScoreManager.P1ScoreCount += 1;
            }

            if (col.gameObject.tag == "P2Weapon")
            {
                collided = true;
                TheScoreManager.P2ScoreCount += 1;
            }

            if (col.gameObject.tag == "P3Weapon")
            {
                collided = true;
                TheScoreManager.P3ScoreCount += 1;
            }

            if (col.gameObject.tag == "P4Weapon")
            {
                collided = true;
                TheScoreManager.P4ScoreCount += 1;
            }
        }
      
    }
}
