using System.Collections;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public enum InteractionType
    {
        SIGN,
        DOOR,
        NPC
    }
    public InteractionType type;

    public GameObject popup;

    public FadeRoutine fade;

    public GameObject map;
    public GameObject house;
    public bool isInHouse = false;
    public bool isLoading = false;

    private Vector3 in_door_pos = new Vector3(19.0699997f, 10.8500004f, 0);
    private Vector3 out_door_pos = new Vector3(18.9799995f, 6.33999968f, 0);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction_Enter(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction_Exit(other.transform);
        }
    }

    void Interaction_Enter(Transform param_player_tf)
    {
        switch (type)
        {
            case InteractionType.SIGN:
                this.popup.SetActive(true);
                break;
            case InteractionType.DOOR:
                StartCoroutine(DoorRountine(param_player_tf));
                break;
            case InteractionType.NPC:
                this.popup.SetActive(true);
                break;
        }
    }

    void Interaction_Exit(Transform param_player_tf)
    {
        this.popup.SetActive(false);
    }

    IEnumerator DoorRountine(Transform param_player_tf)
    {
        if (isLoading)
            yield break;
        else
            this.isLoading = true;

        yield return StartCoroutine(fade.Fade(2f, Color.black, true));

        this.map.SetActive(isInHouse);
        this.house.SetActive(!isInHouse);

        Vector3 temp_pos = isInHouse ? this.out_door_pos : this.in_door_pos;
        param_player_tf.position = temp_pos;

        this.isInHouse = !isInHouse;

        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(fade.Fade(2f, Color.black, false));

        this.isLoading = false;
    }
}
