using System;

namespace JustOneProject.VariousStuff
{
    public class AttachingToAction
    {
        public Action Action;

        public void Foo()
        {
            Action += FirstAttachedAction;

            Action();

            Action += SecondAssignedAction;

            Action();
        }

        public static void SecondAssignedAction()
        {
            Console.WriteLine("Second assigned action");
        }

        public static void FirstAttachedAction()
        {
            Console.WriteLine("First attached action");
        }
    }

    public class TestAttachingFromOutside
    {
        public void Foo()
        {
            var attachingToAction = new AttachingToAction();
            attachingToAction.Action += AttachingToAction.FirstAttachedAction;

            attachingToAction.Action();

            attachingToAction.Action += AttachingToAction.SecondAssignedAction;

            attachingToAction.Action();
        }
    }
}