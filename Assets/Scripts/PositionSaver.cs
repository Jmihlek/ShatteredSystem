using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PositionSaver : MonoBehaviour
{
    private Move playerMove;
    private Vector3 playerPosition;
    private Quaternion playerRotation;
    private const string EvilKey = "IsEvil";
    public float NormalRadius;
    public float NormalSpeed;
    public float AngerRadius;
    public float AngerSpeed;


    private void Start()
    {
        // Поиск игрока с компонентом Move
        playerMove = FindObjectOfType<Move>();
        var cameras = FindObjectsOfType<Camera>();

        // Проверка наличия сохраненной позиции и поворота
        if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY") && PlayerPrefs.HasKey("PlayerPositionZ") &&
            PlayerPrefs.HasKey("PlayerRotationX") && PlayerPrefs.HasKey("PlayerRotationY") && PlayerPrefs.HasKey("PlayerRotationZ") && 
            PlayerPrefs.HasKey("PlayerRotationW"))
        {
            // Загрузка сохраненной позиции и поворота
            float posX = PlayerPrefs.GetFloat("PlayerPositionX");
            float posY = PlayerPrefs.GetFloat("PlayerPositionY");
            float posZ = PlayerPrefs.GetFloat("PlayerPositionZ");
            playerPosition = new Vector3(posX, posY, posZ);

            float rotX = PlayerPrefs.GetFloat("PlayerRotationX");
            float rotY = PlayerPrefs.GetFloat("PlayerRotationY");
            float rotZ = PlayerPrefs.GetFloat("PlayerRotationZ");
            float rotW = PlayerPrefs.GetFloat("PlayerRotationW");
            playerRotation = new Quaternion(rotX, rotY, rotZ, rotW);

            // Перемещение игрока в сохраненную позицию и поворот
            playerMove.transform.position = playerPosition;
            playerMove.transform.rotation = playerRotation;
            // Поиск ближайшей камеры с компонентом "Move"
            Camera closestCamera = FindClosestCamera(playerPosition);
            if (closestCamera != null)
            { 
                foreach (var item in cameras)
                    item.gameObject.SetActive(false);   

                // Действия с ближайшей камерой
                // Например, установка ее в качестве активной камеры
                closestCamera.gameObject.SetActive(true);
            }

            var needHideObjs = KwezDistroer.LoadArray();
            foreach (var obj in FindObjectsOfType<KwezDistroer>().Where(t => t.ID != 0))
            {
                if (needHideObjs.Contains(obj.ID))
                {
                    Debug.Log($"Destroy ID: {obj.ID}");
                    obj.gameObject.SetActive(false);
                }

            }
            var needShowObjs = KwezCreator.LoadArray();
            foreach (var obj in FindObjectsOfType<KwezCreator>(true).Where(t => t.ID != 0))
                if (needShowObjs.Contains(obj.ID))
                    obj.gameObject.SetActive(true);

            var monster = FindObjectOfType<AI_Ray>(true);
            monster.gameObject.SetActive(true);
            var navAgent = monster.GetComponent<NavMeshAgent>();

            if (PlayerPrefs.HasKey(EvilKey))
            {
                navAgent.speed = AngerSpeed;
                navAgent.radius = AngerRadius;
            }
            else
            {
                navAgent.speed = NormalSpeed;
                navAgent.radius = NormalRadius;
            }
        }
        else
        {
            FindObjectOfType<AI_Ray>(true).gameObject.SetActive(false);
        }

    }

    private Camera FindClosestCamera(Vector3 targetPosition)
    {
        Camera[] cameras = FindObjectsOfType<Camera>(true);
        Camera closestCamera = null;
        float closestDistance = Mathf.Infinity;

        foreach (Camera camera in cameras)
        {
            float distance = Vector3.Distance(camera.transform.position, targetPosition);
            if (distance < closestDistance)
            {
                closestCamera = camera;
                closestDistance = distance;
            }
        }

        return closestCamera;
    }

    [ContextMenu("Reset Saved Variables")]
    public void ResetSavedVariables()
    {
        // Удаление всех сохраненных переменных
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("PlayerPositionZ");

        PlayerPrefs.DeleteKey("PlayerRotationX");
        PlayerPrefs.DeleteKey("PlayerRotationY");
        PlayerPrefs.DeleteKey("PlayerRotationZ");
        PlayerPrefs.DeleteKey("PlayerRotationW");
        
        PlayerPrefs.DeleteKey("NumberArray");
        PlayerPrefs.DeleteKey("IsEvil");

        Debug.Log("Saved variables reset.");
    }
}
