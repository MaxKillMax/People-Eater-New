using UnityEngine.SceneManagement;

// �������� ���� (��� � ������� �� MenuManagment ���� ����� �������� ������)
public static class SceneManagment
{
    public static void LoadScene(int id)
    {
        SceneManager.LoadSceneAsync(id);
    }
}
