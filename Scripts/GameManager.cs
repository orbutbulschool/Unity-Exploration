using UnityEngine;

public class GameManager : MonoBehaviour
{
    public player player;
    public int lives = 3;

    public void PlayerDied(){
        this.lives --;
        if (this.lives < 0){
            GameOver();
        }else{
        Invoke(nameof(PlayerRespawn), 3.0f);
        }
    }

    public void PlayerRespawn(){
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(turnOnCollisions),3.0f);


    }

    private void turnOnCollisions(){
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }


    public void GameOver(){
        //TODO
    }
}

