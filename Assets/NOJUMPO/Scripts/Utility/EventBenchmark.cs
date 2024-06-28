using System;
using System.Diagnostics;
using UnityEngine;

public class EventBenchmark : MonoBehaviour
{
    public delegate void OnMovementInputPressed(Vector2 movementVector);
    public OnMovementInputPressed onMovementInputPressed;

    public event Action<Vector2> OnMovementPressed;

    private const int iterations = 10000000;
    private Vector2 testVector = new Vector2(1.0f, 1.0f);

    private void Start() {
        onMovementInputPressed += DelegateHandler;
        OnMovementPressed += EventHandler;

        BenchmarkDelegate();
        BenchmarkEvent();
    }

    private void DelegateHandler(Vector2 vector) {
        // Do nothing
    }

    private void EventHandler(Vector2 vector) {
        // Do nothing
    }

    private void BenchmarkDelegate() {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            onMovementInputPressed?.Invoke(testVector);
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log("Delegate invocation time: " + stopwatch.ElapsedMilliseconds + " ms");
    }

    private void BenchmarkEvent() {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            OnMovementPressed?.Invoke(testVector);
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log("Event invocation time: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}