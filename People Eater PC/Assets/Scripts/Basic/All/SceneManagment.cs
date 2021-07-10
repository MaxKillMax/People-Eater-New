using UnityEngine.SceneManagement;

// Загрузка сцен (тут в отличие от MenuManagment есть некая гибкость метода)
public static class SceneManagment
{
    public static void LoadScene(int id)
    {
        SceneManager.LoadSceneAsync(id);
    }
}
