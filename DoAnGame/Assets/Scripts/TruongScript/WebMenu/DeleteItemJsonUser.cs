using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItemJsonUser : MonoBehaviour
{

    private List<string> dataUser;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void DeleteItem()
    {
        Debug.Log("" + transform.name[5]);
        int index = transform.name[5] - 48;
        dataUser = JsonUser.Instance.getUser();
        Debug.Log(dataUser[index]);

        JsonUser.Instance.DeleteUser(dataUser[index]);
        DropdownUser.Instance.updateOptions();
    }
}
