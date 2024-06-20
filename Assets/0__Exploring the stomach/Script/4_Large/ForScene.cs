using UnityEngine;

public class ForScene : MonoBehaviour
{
    public SceneMN scene;
    public string st;

    void Start()
    {
        Invoke(st, 10f);
    }

    void SceneChange()
    {
        scene.ToPoo();
    }

}
