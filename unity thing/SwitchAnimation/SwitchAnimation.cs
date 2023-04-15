using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

public class SwitchAnimation : MonoBehaviour
{
    public SpriteRenderer render;
    public List<Spritesheet> spritesheet;

    [HideInInspector]
    public bool isPlaying;

    bool abandon;

    public int GetAnimationFromName(string name)
    {
        for(int i = 0; i < spritesheet.Count; i++)
        {
            if (spritesheet[i].name == name)
            {
                return i;
            }
        }

        return -1;
    }

    public void StopAnimation()
    {
        StopAllCoroutines();
        isPlaying= false;
    }

    public void Play(int index)
    {
        StartCoroutine(PlayPart(spritesheet[index], 0));
    }

    IEnumerator PlayPart(Spritesheet anim, int index)
    {
        isPlaying = true;

        render.sprite = anim.parts[index].sprite;

        yield return new WaitForSeconds(anim.parts[index].interval);

        if (index+1 < anim.parts.Count && !abandon)
        {
            StartCoroutine(PlayPart(anim, index+1));
        }
        else
        {
            isPlaying = false;
        }
    }
}
