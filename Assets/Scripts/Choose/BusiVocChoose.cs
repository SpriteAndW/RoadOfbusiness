using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusiVocChoose : IChoose
{


    public override void Execute()
    {
        Business.Instance.ChangeCredit(200);
    }
}
