/// <summary>
/// This script allows objects that possess this script to change to a random
/// color upon colliding with another object.
/// </summary>
using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour {
  private void OnCollisionEnter(Collision collision) {
    Color randomlySelectedColor = GetRandomColor();
    GetComponent<Renderer>().material.color = randomlySelectedColor;
  }

  private Color GetRandomColor() {
    return new Color(UnityEngine.Random.Range(0f, 1f),
                     UnityEngine.Random.Range(0f, 1f),
                     UnityEngine.Random.Range(0f, 1f));
  }
}
