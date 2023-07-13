
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;

    private float value;
    private void Start()
    {
         mixer.GetFloat("Volume",out value);
        volumeSlider.value = value;
    }
    public void SetVoLume()
    {
        mixer.SetFloat("Volume",volumeSlider.value);
    }
   public void  LoadLevel(int index)
    {
        SceneManager.LoadScene(index);  
    }
  
}
