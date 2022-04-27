using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFactory : MonoBehaviour
{
    [SerializeField] GameObject _brick;
    // Start is called before the first frame update
    void Start()
    {
        MakeBrickss();
    }
public void MakeBrickss() {
for(int i=0; i<8; i++) {
for (int j = 0; j < 2; j++) {
  GameObject brick = Instantiate(_brick, new Vector3((i-3.2f)*1.8f, (j+1)*1.2f, 0), Quaternion.identity);
}
}
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
