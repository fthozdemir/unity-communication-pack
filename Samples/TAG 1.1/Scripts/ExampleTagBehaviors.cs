
using UnityEngine;
using TuioUnity.Tuio11.Tag;
using UnityEngine.Events;

public class ExampleTagBehaviors : MonoBehaviour
{
    public void OnSampleTagStart(Tag tag)
    {
        Debug.Log("No: " + tag.getId() + " Started in " + tag.getPosition());
    }
    public void OnSampleTagUpdate(Tag tag)
    {
        Debug.Log(tag.gameObject.name + "Updated and angle is " + tag.getAngle());
    }
    public void OnSampleTagDestroy(Tag tag)
    {
        Debug.Log("Sample Tag Destroyed");
    }

    public void DoSomeThing()
    {
        Debug.Log("I dont need tag to do Wild Things");
    }
}
