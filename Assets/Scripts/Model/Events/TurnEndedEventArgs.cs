using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndedEventArgs : EventArgs { }
public delegate void TurnEnded(object sender, TurnEndedEventArgs args);
