using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject[] Panels;

    public void OpenPanel(int index)
    {
        GameObject p = null;
        for (int i = 0; i < Panels.Length; i++)
        {
            if (i != index)
            {
                Panels[i].SetActive(false);
            }
            else
            {
                p = Panels[i];
            }
        }
        p.SetActive(true);
    }
}
