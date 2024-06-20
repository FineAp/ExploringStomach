using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public float fadeOutDuration = 1.0f; // 페이드 아웃에 걸리는 시간
    private Material material;
    private Color originalColor;

    void Start()
    {
        // 오브젝트의 Material 가져오기
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        // 오브젝트의 원래 색상 저장
        originalColor = material.color;

        // 페이드 아웃 코루틴 실행
        StartCoroutine(DoFadeOut());
    }

    IEnumerator DoFadeOut()
    {
        // 페이드 아웃에 사용될 시간 변수
        float elapsedTime = 0f;

        // 현재 머티리얼의 알파 값
        float startAlpha = material.color.a;

        // 페이드 아웃 처리
        while (elapsedTime < fadeOutDuration)
        {
            // 시간 경과
            elapsedTime += Time.deltaTime;

            // 현재 시간에 따른 알파 값 계산
            float alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeOutDuration);

            // 새로운 색상 설정
            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // 머티리얼에 색상 적용
            material.color = newColor;

            yield return null;
        }

        // 페이드 아웃 완료 후 GameObject 비활성화
        gameObject.SetActive(false);
    }
}
