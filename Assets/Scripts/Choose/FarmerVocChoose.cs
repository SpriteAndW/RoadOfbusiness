using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerVocChoose : IChoose
{


    public override void Execute()
    {
        Business.Instance.ChangeCredit(100);
    }
}
