using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAnimatorController : EnemyAnimationController
{
    [SerializeField]private EagleController eagleController;

    private void Start() {
        eagleController.OnDeath += enemyController_OnDeath;
    }
}
