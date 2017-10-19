namespace Delegate
{
    //定义委托，它定义了可以代表的方法的类型
    public delegate void GreetingDelegate(string name);

    //新建的GreetingManager类
    public class GreetingManager
    {
        GreetingDelegate delegate1;
        public void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            delegate1 += ShowMsg;
            MakeGreeting(name);
        }


        public void ShowMsg(string name)
        {
            System.Console.WriteLine(name);
        }
    }


}