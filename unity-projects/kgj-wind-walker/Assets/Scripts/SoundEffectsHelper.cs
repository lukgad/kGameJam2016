using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour {

	/// <summary>
  /// Singleton
  /// </summary>
  public static SoundEffectsHelper Instance;

  public AudioClip runningSound;
  public AudioClip jumpSound;

  void Awake()
  {
    // Register the singleton
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

	public void MakeRunnningSound()
  {
		//MakeSound(runningSound, Camera.main.transform.position);
  }



  /// <summary>
  /// Play a given sound
  /// </summary>
  /// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip, Vector3 position)
  {
    // As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, position);
  }
}
