using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RainbowLettersEffect : MonoBehaviour
{
    [SerializeField]
    Gradient gradientText;

    [SerializeField]
    float gradientSpeed = .001f;
    TMP_Text m_TextComponent;
    float totalTime;

    void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
    }

    void Start()
    {
        StartCoroutine(AnimateVertexColors());
    }

    IEnumerator AnimateVertexColors()
    {
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        int currentCharacter = 0;

        Color32[] newVertexColors;
        Color32 c0 = m_TextComponent.color;

        while (true)
        {
            int characterCount = textInfo.characterCount;

            if (characterCount == 0)
            {
                yield return new WaitForSeconds(.25f);
                continue;
            }

            int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;

            newVertexColors = textInfo.meshInfo[materialIndex].colors32;

            int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;

            if (textInfo.characterInfo[currentCharacter].isVisible)
            {
                // c0 = new Color32(
                //     (byte)UnityEngine.Random.Range(0, 255),
                //     (byte)UnityEngine.Random.Range(0, 255),
                //     (byte)UnityEngine.Random.Range(0, 255),
                //     (byte)UnityEngine.Random.Range(0, 255)
                // );
                float offset = currentCharacter / characterCount;
                c0 = gradientText.Evaluate((totalTime + offset) % 1);
                totalTime += Time.deltaTime;

                newVertexColors[vertexIndex + 0] = c0;
                newVertexColors[vertexIndex + 1] = c0;
                newVertexColors[vertexIndex + 2] = c0;
                newVertexColors[vertexIndex + 3] = c0;

                m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }

            currentCharacter = (currentCharacter + 1) % characterCount;

            yield return new WaitForSeconds(gradientSpeed);
        }
    }
}
