using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class Extensions 
{
    public static T GetRandomElement<T>(this List<T> list, bool removeFromList = false)
    {
        var index = Random.Range(0, list.Count);

        var element = list[index];

        if (removeFromList)
            list.RemoveAt(index);

        return element;
    }

    public static void AddUnique<T>(this List<T> list, T element)
    {
        if (list.Contains(element))
            return;

        list.Add(element);
    }

    public static void OrderByDistance(this RaycastHit[] hitInfos)
    {
        hitInfos.Sort((x, y) => x.distance.CompareTo(y.distance));
    }

    public static void SetNavigationMode(this Selectable selectable, Navigation.Mode mode)
    {
        var nav = selectable.navigation;
        nav.mode = mode;
        selectable.navigation = nav;
    }

    public static void SetDefaultExplicitNavigation(this Selectable selectable)
    {
        var nav = selectable.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnUp = selectable.FindSelectableOnUp();
        nav.selectOnDown = selectable.FindSelectableOnDown();
        nav.selectOnLeft = selectable.FindSelectableOnLeft();
        nav.selectOnRight = selectable.FindSelectableOnRight();
        selectable.navigation = nav;
    }

    public static void SetNavigation(this Selectable selectable, Selectable onUp, Selectable onDown, Selectable onLeft, Selectable onRight)
    {
        var nav = selectable.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnUp = onUp;
        nav.selectOnDown = onDown;
        nav.selectOnLeft = onLeft;
        nav.selectOnRight = onRight;
        selectable.navigation = nav;
    }

    public static void SetNavigationUp(this Selectable selectable, Selectable onUp)
    {
        var nav = selectable.navigation;
        nav.selectOnUp = onUp;
        selectable.navigation = nav;
    }

    public static void SetNavigationDown(this Selectable selectable, Selectable onDown)
    {
        var nav = selectable.navigation;
        nav.selectOnDown = onDown;
        selectable.navigation = nav;
    }

    public static void SetNavigationLeft(this Selectable selectable, Selectable onLeft)
    {
        var nav = selectable.navigation;
        nav.selectOnLeft = onLeft;
        selectable.navigation = nav;
    }

    public static void SetNavigationRight(this Selectable selectable, Selectable onRight)
    {
        var nav = selectable.navigation;
        nav.selectOnRight = onRight;
        selectable.navigation = nav;
    }
}

public static class Utils
{
    [MenuItem("Fail/Clear Save Data")]
    public static void ClearSaveData()
    {
        var filePath = Path.Combine(Application.persistentDataPath, Index.Instance.SaveFileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public static bool IsPlayerGameObject(GameObject gameObject)
    {
        var player = gameObject.GetComponentInParent<PlayerController>();
        return player != null;
    }

    public static Vector3 GetMeanVector(Vector3[] positions)
    {
        if (positions.Length == 0)
            return Vector3.zero;
        float x = 0f;
        float y = 0f;
        float z = 0f;
        foreach (Vector3 pos in positions)
        {
            x += pos.x;
            y += pos.y;
            z += pos.z;
        }
        return new Vector3(x / positions.Length, y / positions.Length, z / positions.Length);
    }

    public static void DrawRay(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction * 100f);
    }

    public static int CompareRayCastHit(RaycastHit x, RaycastHit y)
    {
        return x.distance.CompareTo(y.distance);
    }

    public static Vector3 GetGroundNormalAtPosition(Vector3 position, float distance = 10f)
    {
        var groundNormal = Vector3.up;

        Ray ray = new Ray(position + Vector3.up * 0.1f, -Vector3.up);
        DrawRay(ray);

        RaycastHit[] hitInfos = Physics.RaycastAll(ray, distance, LayerMaskManager.Instance.groundLayerMask);

        hitInfos.OrderByDistance();

        if (hitInfos.Length > 0)
            groundNormal = hitInfos[0].normal;

        return groundNormal;
    } 

    public static List<T> GetComponentsInRadius<T>(Vector3 position, float distance, int layerMask, bool requireLineOfSight = false) where T : Component
    {
        List<T> results = new List<T>();

        var colliders = Physics.OverlapSphere(position, distance, layerMask);
        foreach (var collider in colliders)
        {
            Vector3 delta = (collider.transform.position - position);
            if (requireLineOfSight)
            {
                RaycastHit[] hitInfos = Physics.RaycastAll(position, delta, delta.magnitude, layerMask);

                hitInfos.OrderByDistance();
                
                if (hitInfos[0].collider != collider)
                    continue;
            }

            var component = collider.GetComponentInParent<T>();
            if (component != null)
                results.Add(component);
        }

        return results;
    }

    public static T GetComponentInCone<T>(Vector3 position, Vector3 direction, float distance, float maxAngle, int layerMask, bool requireLineOfSight = false) where T : Component
    {
        T closest = null;
        var closestDistance = float.MaxValue;
        var maxDistance = closestDistance;

        var componentsInRadius = GetComponentsInRadius<T>(position, distance, layerMask, requireLineOfSight);
        foreach (var component in componentsInRadius)
        {
            var delta = component.transform.position - position;
            var angle = Vector3.Angle(direction, delta);

            if (angle > maxAngle)
                continue;

            if (delta.magnitude > maxDistance || delta.magnitude > closestDistance)
                continue;

            closest = component;
            closestDistance = delta.magnitude;
        }

        return closest;
    }

    public static Texture2D TextureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }

    public static bool BootstrapIsLoaded()
    {
        return GameManager.Instance != null;
    }

    public static bool SceneIsLoaded(int buildIndex)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.buildIndex == buildIndex)
                return true;
        }

        return false;
    }

    public static void LoadSceneEditor(string path, OpenSceneMode mode)
    {
        var scene = EditorSceneManager.OpenScene(path, mode);
        SceneManager.SetActiveScene(scene);
    }

    public static int GetIndexOfLoadedScene(int sceneBuildIndex)
    {
        var sceneCount = 0;
#if UNITY_EDITOR
        sceneCount = EditorSceneManager.sceneCount;
#else
		sceneCount = SceneManager.SceneCount;
#endif
        for (int i = 0; i < sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.buildIndex == sceneBuildIndex)
                return i;
        }

        return -1;
    }
}
