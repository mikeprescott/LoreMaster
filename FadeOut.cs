using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	private bool isTiming = true;

	private float TimeCounter = 0.0f;
	private float TimeBarrier = 2.0f;
	private float FadeTimeCounter = 0.0f;
	private float FadeDuration = 0.5f;
	private float FadePercentage = 0.0f;

	public SpriteRenderer spriteRenderer;
	public Color color = Color.white;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTiming) {
			TimeCounter += Time.deltaTime;
			if (TimeCounter > TimeBarrier) {
				FadeTimeCounter = TimeCounter - TimeBarrier;
				if (FadeTimeCounter <= FadeDuration) {				
					FadePercentage = FadeTimeCounter / FadeDuration;
					color.r = 1.0f - FadePercentage;
					color.g = 1.0f - FadePercentage;
					color.b = 1.0f - FadePercentage;
					spriteRenderer.color = color;
				} else {
					this.Next();
				}
			}
		}
	}

	void Next(){
		isTiming = false;
		Debug.Log("Finished");
		Application.LoadLevel("EnterSeed");
	}
}
