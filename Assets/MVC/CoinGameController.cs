using UnityEngine;

public class CoinGameController : MonoBehaviour
{
    [SerializeField] CoinGameModel _model;  // Model is just a data container, all the variables
                                            // that we need in our class could be in the model.
                                            // Actually, all the variables that represent the 
                                            // current state of our game, for example, the amount
                                            // of coins. Something that we want to persist(save) 
                                            // when the application is closed and recover when
                                            // open the game again.
    [SerializeField] CoinGameView _view;    // The View is what the player can see.
                                            // Meshes, Buttons, Texts, Particles

    void Start()
    {
        _view.WorkButton.onClick.AddListener(Work);
    }

    public void Work()
    {
        // In this case our business logic is simply 
        // to add coins, but notice that our Controller
        // is agnostic to data and view, he is just worried
        // in actions, about solving problems.

        // He is not  worried in how or where is the data stored
        // neither how the player see those things, he
        // just is just transforming data and sending the new state
        // to the model and the view.

        _model.Coins++;                     // Update Data (What the player can't see)
        _view.UpdateCoins(_model.Coins);    // Update View (What the player can see)
    }
}
