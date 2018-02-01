using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeTelas  {

    public static void mudarTela(int qual) {

        switch (qual) {
            case 0:
                SceneManager.LoadScene(qual);
                break;
            case 1:
                SceneManager.LoadScene(qual);
                break;
            case 2:
                SceneManager.LoadScene(qual);
                break;
            case 3:
                SceneManager.LoadScene(qual);
                break;
        }
    }
}
