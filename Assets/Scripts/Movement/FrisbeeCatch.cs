using UnityEngine;

public class FrisbeeCatch : MonoBehaviour
{
    public BaseMovement baseMovement;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Frisbee"))
        {
            Frisbee frisbee = other.gameObject.GetComponent<Frisbee>();
            frisbee.SetPlayerPos(baseMovement.transform);
            frisbee.SetIsCaught(true);
            baseMovement.Frisbee = frisbee;
            baseMovement.LockMove();
            
        }
    }
}
