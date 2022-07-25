using System;
using UniRx;
using UnityEngine;

public static class AnimationExtension {
    public static IDisposable DOScalePingPong(this Transform transform, Vector3 scaleOffet, float rate, float duration) {
        Vector3 initScale = transform.localScale;
        Vector3 scale = transform.localScale;
        var update = Observable.EveryUpdate()
            .TakeWhile(x => duration > 0)
            .DoOnCancel(() => transform.localScale = initScale)
            .Subscribe(_ => {
                duration -= Time.deltaTime;
                var progress = (Mathf.PingPong(Time.time, rate)) / rate;
                scale = initScale + (scaleOffet * progress);
                transform.localScale = scale;
            }, () => transform.localScale = initScale);
        return update;
    }
}
