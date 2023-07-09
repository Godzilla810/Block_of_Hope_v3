using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Queue<string> sentences;
    public GameObject dialogBox;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI describeText;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog){
        dialogBox.SetActive(true);

        itemText.text = dialog.item;

        sentences.Clear();

        foreach(string word in dialog.describe){
            sentences.Enqueue(word);
        }
        DisplayNextSentence();
    }

    private void EndDialog(){
        Debug.Log("end");
        dialogBox.SetActive(false);
    }

    public void DisplayNextSentence(){
        Debug.Log("Next");
        string word = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeByWords(word));
    }

    IEnumerator TypeByWords (string word){
        describeText.text = "";
        foreach (char letter in word.ToCharArray()){
            describeText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        EndDialog();
    }


}
