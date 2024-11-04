using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public GameObject duckPrefab;
    public int rows = 4;
    public int columns = 8;
    public float duckSpeed = 2f;
    public float screenWidth = 16f;  // Largeur de l'écran, ajustable selon l'échelle

    private GameObject[,] ducks; // Tableau pour stocker les canards

    void Start()
    {
        ducks = new GameObject[rows, columns];

        // Génération automatique des lignes de canards
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = new Vector3(col - columns / 2, row + 3, 0);
                ducks[row, col] = Instantiate(duckPrefab, position, Quaternion.identity);
                ducks[row, col].transform.SetParent(transform);
            }
        }
    }

    void Update()
    {
        // Déplacement des canards ligne par ligne
        for (int row = 0; row < rows; row++)
        {
            float direction = (row % 2 == 0) ? 1 : -1; // Direction alternée pour chaque ligne
            for (int col = 0; col < columns; col++)
            {
                if (ducks[row, col] != null) // Vérifier que le canard n'est pas détruit
                {
                    // Déplacer le canard
                    ducks[row, col].transform.Translate(Vector2.right * direction * duckSpeed * Time.deltaTime);

                    // Vérifier si le canard dépasse les bords de l'écran
                    float xPosition = ducks[row, col].transform.position.x;
                    if (xPosition > screenWidth / 2)
                    {
                        ducks[row, col].transform.position = new Vector3(-screenWidth / 2, ducks[row, col].transform.position.y, 0);
                    }
                    else if (xPosition < -screenWidth / 2)
                    {
                        ducks[row, col].transform.position = new Vector3(screenWidth / 2, ducks[row, col].transform.position.y, 0);
                    }
                }
            }
        }
    }
}
