using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour {

   public GameObject wireTaskPanel;
   public List<Color> wireColors = new List<Color>();
   public List<Wire> leftWires = new List<Wire>();
   public List<Wire> rightWires = new List<Wire>();

   public Wire CurrentDraggedWire;
   public Wire CurrentHoveredWire;

   public bool IsTaskCompleted = false;

   private List<Color> availableColors;
   private List<int> availableLeftWireIndex;
   private List<int> availableRightWireIndex;
   private void Start() {
      availableColors = new List<Color>(wireColors);
      availableLeftWireIndex = new List<int>();
      availableRightWireIndex = new List<int>();

      for (int i = 0; i < leftWires.Count; i++) {
         availableLeftWireIndex.Add(i);
      }

      for (int i = 0; i < rightWires.Count; i++) {
         availableRightWireIndex.Add(i);
      }

      while (availableColors.Count > 0 &&
             availableLeftWireIndex.Count > 0 &&
             availableRightWireIndex.Count > 0) {
         Color pickedColor =
          availableColors[Random.Range(0, availableColors.Count)];

         int pickedLeftWireIndex = Random.Range(0,
                                   availableLeftWireIndex.Count);
         int pickedRightWireIndex = Random.Range(0,
                                   availableRightWireIndex.Count);
         leftWires[availableLeftWireIndex[pickedLeftWireIndex]]
                                           .SetColor(pickedColor);
         rightWires[availableRightWireIndex[pickedRightWireIndex]]
                                           .SetColor(pickedColor);

         availableColors.Remove(pickedColor);
         availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
         availableRightWireIndex.RemoveAt(pickedRightWireIndex);
     }

      StartCoroutine(CheckTaskCompletion());
   }

   public void ClosePanel() {
     FindObjectOfType<LevelManager>().MinigameComplete();
     FindObjectOfType<MinigameController>().LayerDefault();
     wireTaskPanel.SetActive(false);

   }

   public void OpenPanel() {
     wireTaskPanel.SetActive(true);
   }

   private IEnumerator CheckTaskCompletion() {
      while (!IsTaskCompleted) {
         int successfulWires = 0;

         for (int i = 0; i < rightWires.Count; i++) {
            if (rightWires[i].IsSuccess) { successfulWires++; }
         }
         if (successfulWires >= rightWires.Count) {
            ClosePanel();
         }
         else {
            Debug.Log("TASK INCOMPLETED");
         }

         yield return new WaitForSeconds(0.5f);
     }
   }
}
