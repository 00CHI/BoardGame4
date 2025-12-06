using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    Button spriteButton;
    SpriteAtlas inferenceAtlas;

    Image inferenceImage;


    int spriteNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        inferenceAtlas = Resources.Load<SpriteAtlas>("04_Atlas/Inference_Atlas");
        spriteButton = GetComponent<Button>();
        inferenceImage = GetComponent<Image>();
        spriteButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        spriteNum++;
        //Debug.Log(spriteNum);


        if (spriteNum >= inferenceAtlas.spriteCount)
        {
            spriteNum = 0;
        }

        //else if (spriteNum < inferenceAtlas.spriteCount)
        //{
        //    spriteNum = 0;
        //}

        inferenceImage.sprite = SpriteReturn($"{spriteNum}");
        
        if (inferenceImage.sprite == null)
        {
            inferenceImage.sprite = SpriteReturn("5");
        }

    }

    public Sprite SpriteReturn(string spriteName)
    {
        return inferenceAtlas.GetSprite(spriteName);
    }
}
