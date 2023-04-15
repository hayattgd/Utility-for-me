using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [Serializable]
    public class SpritesheetPart
    {
        public Sprite sprite;
        public float interval = 1;
    }

    [Serializable]
    public class Spritesheet
    {
        public string name;
        public List<SpritesheetPart> parts;
    }
}