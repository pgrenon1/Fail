using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskManager : OdinSerializedSingletonBehaviour<LayerMaskManager>
{
    public LayerMask groundLayerMask;
    public LayerMask groundCheckLayerMask;
}
