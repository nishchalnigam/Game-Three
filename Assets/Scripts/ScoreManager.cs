using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public CanvasRenderer UICanvasRenderer;
    public Image uiImage;
    public List<Sprite> sprites;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        if (Target.instance == null)
        {
            Instantiate(target);
        }

    }

    // Update is called once per frame
    void Update()
    {
        uiImage.sprite = sprites[Target.instance.getHealth()];

    }


}
