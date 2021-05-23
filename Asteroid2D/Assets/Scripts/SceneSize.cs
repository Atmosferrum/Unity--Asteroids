using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SceneSize
{
    public float sceneWidth; // Ширина Сцены
    public float sceneHeight; // Высота Сцены
    public float sceneRightEdge; // Правый край Сцены
    public float sceneLeftEdge; // Левый край Сцены
    public float sceneTopEdge; // Верхний край Сцены
    public float sceneBottomEdge; // Нижний край Сцены

    public SceneSize(Camera mainCam)
    {        
        sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        sceneHeight = mainCam.orthographicSize * 2;
        sceneRightEdge = sceneWidth / 2;
        sceneLeftEdge = sceneRightEdge * -1;
        sceneTopEdge = sceneHeight / 2;
        sceneBottomEdge = sceneTopEdge * -1;
    }
}
