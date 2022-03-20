using Internal;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skills : MonoBehaviour
{
    protected float CoolDownLeft = 0f;
    private bool _canHandThrowing = true;
    private bool _canBoneSeparation = true;
    protected bool CanBoneSeparation => _canBoneSeparation;
    public void SetCanBoneSeparation(bool value)
    {
        _canBoneSeparation = value;
    }
    protected bool CanHandThrowing => _canHandThrowing;
    public void SetCanHandThrowing(bool value)
    {
        _canHandThrowing = value;
    }
    private void Awake()
    {
        Locator.Register<Skills>(this);
    }
    protected IEnumerator CoolDowning(float coolDown, Image coolDownImage, System.Action<bool> callback)
    {
        CoolDownLeft = coolDown;
        while (CoolDownLeft > 0)
        {
            CoolDownLeft -= Time.deltaTime;
            float normalizedValue = Mathf.Clamp(CoolDownLeft / coolDown, 0.0f, 1.0f);
            coolDownImage.fillAmount = normalizedValue;
            yield return null;
        }
        callback(false);
    }
}
