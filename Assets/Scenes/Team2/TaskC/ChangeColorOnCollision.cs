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
