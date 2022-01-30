using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skills : MonoBehaviour
{
    protected float _coolDownLeft = 0f;

    protected IEnumerator CoolDowning(float coolDown, Image coolDownImage, System.Action<bool> callback)
    {
        _coolDownLeft = coolDown;
        while (_coolDownLeft > 0)
        {
            _coolDownLeft -= Time.deltaTime;
            float normalizedValue = Mathf.Clamp(_coolDownLeft / coolDown, 0.0f, 1.0f);
            coolDownImage.fillAmount = normalizedValue;
            yield return null;
        }
        callback(true);
    }
}
