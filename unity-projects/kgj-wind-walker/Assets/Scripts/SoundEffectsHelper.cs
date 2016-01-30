using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour {

  public static SoundEffectsHelper Instance;

  public AudioClip runningSound;
  public AudioClip jumpSound;

  void Awake()
  {
    if (Instance != null)
    {
      Debug.LogError("Multiple instances of SoundEffectsHelper!");
    }
    Instance = this;
  }

  public void MakeJumpSound()
  {
		MakeSound(jumpSound, Camera.main.transform.position);
  }
		
	private void MakeSound(AudioClip originalClip, Vector3 position)
  {

		//AudioSource.PlayClipAtPoint(originalClip, position);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (originalClip);
  }
}
