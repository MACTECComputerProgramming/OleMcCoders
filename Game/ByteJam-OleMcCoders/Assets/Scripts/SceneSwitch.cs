using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void VRTest()
    {
        SceneManager.LoadScene("VR Test");
    }
    /*public void SceneName()
    {
        SceneManager.LoadScene("SceneName");
    }
    */

}
