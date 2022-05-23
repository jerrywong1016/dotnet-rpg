namespace dotnet_rpg.Modals

{
    // this is a helper modal try to help you when error occurs, something message will pop up and indicate what's the issue is
    public class ServiceResponse<T> //wrapper class can contain any classes
    {
        public T Data {get; set;}

        public bool Success {get;set;} = true;

        public string Message {get; set;} = null;

    }
}