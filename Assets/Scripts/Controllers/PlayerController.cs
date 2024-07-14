using UnityEngine;


[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/PlayerController")]
public class Player : InputController
{
    public override bool RetrieveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool RetrieveUseInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
