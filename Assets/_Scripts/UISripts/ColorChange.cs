using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    Image image;
    public List<Color> colors;
    private void Start()
    {
        image = this.GetComponent<Image>();
    }
    public void ChangeColor(int colorID)
    {
        image.color = colors[colorID];
    }
}
