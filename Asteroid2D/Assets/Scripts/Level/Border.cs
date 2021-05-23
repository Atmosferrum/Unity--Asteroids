using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField]
    Camera mainCam; // Объект главной Камеры

    //SceneSize sceneSize;

    //private float sceneWidth; // Ширина Сцены
    //private float sceneHeight; // Высота Сцены
    //private float sceneRightEdge; // Правый край Сцены
    //private float sceneLeftEdge; // Левый край Сцены
    //private float sceneTopEdge; // Верхний край Сцены
    //private float sceneBottomEdge; // Нижний край Сцены
    private BoxCollider2D borderBC2D; // Компонент BoxCollider2D Границ

    private void Start()
    {
        ResizeBorder();
        //GetScreenEdges();


        ////sceneSize = new SceneSize(mainCam);
    }

    /// <summary>
    /// ИЗМЕНЕНИЕ границ 
    /// </summary>
    void ResizeBorder()
    {
        //borderBC2D = GetComponent<BoxCollider2D>();
        //sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        //sceneHeight = mainCam.orthographicSize * 2;
        //borderBC2D.size = new Vector2(sceneWidth, sceneHeight);
        borderBC2D = GetComponent<BoxCollider2D>();        
        borderBC2D.size = new Vector2(GameManager.Instance.sceneSize.sceneWidth, GameManager.Instance.sceneSize.sceneHeight);
    }

    /// <summary>
    /// ПОЛУЧЕНИЕ границ Экрана
    /// </summary>
    //private void GetScreenEdges()
    //{
    //    sceneRightEdge = sceneWidth / 2;
    //    sceneLeftEdge = sceneRightEdge * -1;
    //    sceneTopEdge = sceneHeight / 2;
    //    sceneBottomEdge = sceneTopEdge * -1;
    //}

    /// <summary>
    /// ТЕЛЕПОРТАЦИЯ объекта если он вышел за пределы границ
    /// </summary>
    /// <param name="position">Актуальное положение объекта для телепортации</param>
    /// <returns></returns>
    public Vector2 Teleport(Vector2 position)
    {
        if (position.x > GameManager.Instance.sceneSize.sceneRightEdge)
            return new Vector2(GameManager.Instance.sceneSize.sceneLeftEdge, position.y);
        else if (position.x < GameManager.Instance.sceneSize.sceneLeftEdge)
            return new Vector2(GameManager.Instance.sceneSize.sceneRightEdge, position.y);
        else if (position.y > GameManager.Instance.sceneSize.sceneTopEdge)
            return new Vector2(position.x, GameManager.Instance.sceneSize.sceneBottomEdge);
        else if (position.y < GameManager.Instance.sceneSize.sceneBottomEdge)
            return new Vector2(position.x, GameManager.Instance.sceneSize.sceneTopEdge);
        else
            return position;
    }
}
