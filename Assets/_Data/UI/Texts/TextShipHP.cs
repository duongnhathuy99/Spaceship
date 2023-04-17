using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHP : BaseText
{
    protected virtual void FixedUpdate() 
    {
        UpdateShipHP();
    }
    protected virtual void UpdateShipHP()
    {
        int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
        int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;
        text.SetText(hp + "/" + hpMax);   
    }
}
