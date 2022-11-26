using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItemJsonUser : MonoBehaviour
{

    private List<string> dataUser;
    public void DeleteItem()
    {
        Debug.Log("DeleteItemJsonUser " + transform.name[5]); // lay vi tri trong name cua item vi tri thu 6
        int index = transform.name[5] - 48; // phai tru 48 , ly do khong biet
        dataUser = JsonUser.Instance.getUser();
        Debug.Log("DeleteItemJsonUser  name data" + dataUser[index] );

        JsonUser.Instance.DeleteUser(dataUser[index]);
        DropdownUser.Instance.updateOptions();
    }
}
